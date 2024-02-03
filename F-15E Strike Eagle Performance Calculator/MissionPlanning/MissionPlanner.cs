using F_15E_Strike_Eagle_Performance_Calculator.Imports;

namespace F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;

internal class MissionPlanner
{
    public static MissionDataCard CurrentMissionDataCard;
    public static bool hold;

    public void MissionInitialisation(List<Waypoint> missionWaypoints)
    {
        hold = true;
        CurrentMissionDataCard = new MissionDataCard();
        CurrentMissionDataCard.MissionLegs = CalculateMissionLegs(missionWaypoints);
        foreach (var leg in CurrentMissionDataCard.MissionLegs)
        {
            CurrentMissionDataCard.MissionDistance += leg.LegDistance;
            CurrentMissionDataCard.AAROnload += leg.LegFuelAdded;
        }

        CurrentMissionDataCard.BingoFuel = 2500 + CurrentMissionDataCard.MissionDistance * 15 / 2;
        CurrentMissionDataCard.JokerFuel = 2500 + CurrentMissionDataCard.MissionDistance * 15 / 2 + 1500;
        hold = false;
    }


    private static List<MissionLegs> CalculateMissionLegs(List<Waypoint> waypoints)
    {
        try
        {
            var missionLegs = new List<MissionLegs>();
            var aircraftWeightAtStart = F15EStrikeEagle.GrossWeight;
            var dragIndex = F15EStrikeEagle.TotalDragIndex;
            var fuelWeight = F15EStrikeEagle.TotalFuel;
            for (var i = 0; i < waypoints.Count - 1; i++)
            {
                var fromWaypoint = waypoints[i];
                var toWaypoint = waypoints[i + 1];

                var distance = WaypointConversion.WaypointCalculateDistance(fromWaypoint.Latitude,
                    fromWaypoint.Longitude, toWaypoint.Latitude, toWaypoint.Longitude);
                if (toWaypoint.Elevation > 20000) toWaypoint.Elevation = 20000;
                var missionLeg = new MissionLegs
                {
                    Id = i + 1,
                    FromWaypoint = fromWaypoint,
                    ToWaypoint = toWaypoint,
                    LegAltitude = toWaypoint.Elevation,
                    LegDragIndex = dragIndex,
                    LegFuelAdded = 0,
                    LegDistance = Math.Round(distance, 1),
                    LegStartAircraftWeight = aircraftWeightAtStart
                };
                missionLeg.LegSpeed = (fromWaypoint.Ktas == 0) ? 450 : fromWaypoint.Ktas;
                if (toWaypoint.Target) missionLeg.LegTarget = true;
                missionLeg.LegFuel = CalculateLegFuel(missionLeg);
                if (missionLeg.Id == 1) missionLeg.LegFuel += 1488; // Startup and Taxi
                missionLeg.LegEndAircraftWeight = aircraftWeightAtStart - (int)missionLeg.LegFuel;
                aircraftWeightAtStart = missionLeg.LegEndAircraftWeight;
                missionLeg.LegFuelRemainEnd = fuelWeight - (int)missionLeg.LegFuel;
                fuelWeight = missionLeg.LegFuelRemainEnd;
                dragIndex = missionLeg.LegDragIndex;
                missionLegs.Add(missionLeg);
            }

            return missionLegs;
        }
        catch (Exception a)
        {
            Log.WriteLog(a.ToString());
            return null;
        }
    }

    public static int CalculateLegFuel(MissionLegs leg)
    {
        var time = leg.LegDistance / leg.LegSpeed + Convert.ToDouble(leg.LegDelay) / 60;
        FuelFlowDataRetriever getFuel = new();
        var poundPerHour =
            getFuel.RetrieveFuelFlow(leg.LegAltitude, (int)leg.LegDragIndex, (int)leg.LegSpeed,
                leg.LegStartAircraftWeight);
        return (int)(time * poundPerHour);
    }
}