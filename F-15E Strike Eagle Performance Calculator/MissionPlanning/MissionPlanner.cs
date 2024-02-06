using F_15E_Strike_Eagle_Performance_Calculator.Imports;

namespace F_15E_Strike_Eagle_Performance_Calculator.MissionPlanning;

internal class MissionPlanner
{
    public static MissionDataCard CurrentMissionDataCard = new();
    public static bool hold;

    public void MissionInitialisation(List<Waypoint> missionWaypoints)
    {
        hold = true;
        CurrentMissionDataCard = new MissionDataCard();
        CurrentMissionDataCard.MissionLegs = CalculateMissionLegs(missionWaypoints);
        if (CurrentMissionDataCard.MissionLegs.Count == 0)
            throw new Exception("Calculation Error occurred during import");
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
                if (toWaypoint.Elevation > 45000) toWaypoint.Elevation = 45000;
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
                // Set LegDelay based on ToWaypoint's Activity
                missionLeg.LegDelay = toWaypoint.Activity == 0 ? 0 : toWaypoint.Activity;
                // Set LegSpeed based on FromWaypoint's Ktas, with a default value of 450
                missionLeg.LegSpeed = fromWaypoint.Ktas == 0 ? 450 : fromWaypoint.Ktas;
                // Set LegTarget to true if ToWaypoint is a target
                missionLeg.LegTarget = toWaypoint.Target;
                // Calculate LegFuel based on custom logic (assuming CalculateLegFuel is a method)
                var fuelOut = CalculateLegFuel(missionLeg);
                missionLeg.LegFuel = fuelOut.calculatedValue;
                missionLeg.LegFuelFlow = fuelOut.poundPerHour;
                if (missionLeg.LegFuelFlow < 3200)
                {
                    missionLeg.LegFuel = 0;
                    FuelFlowDataRetriever getData = new();

                    missionLeg.LegRemarks = getData.FindClosestValidData(missionLeg.LegStartAircraftWeight,
                        (int)missionLeg.LegDragIndex, missionLeg.LegAltitude, (int)missionLeg.LegSpeed);
                }
                else
                {
                    missionLeg.LegRemarks = string.Empty;
                }

                // Apply a special case for the first mission leg (Id == 1)
                if (missionLeg.Id == 1) missionLeg.LegFuel += 1488; // Add startup and taxi fuel
                // Calculate LegEndAircraftWeight and update aircraftWeightAtStart
                missionLeg.LegEndAircraftWeight = aircraftWeightAtStart - (int)missionLeg.LegFuel;
                aircraftWeightAtStart = missionLeg.LegEndAircraftWeight;
                // Calculate LegFuelRemainEnd and update fuelWeight
                missionLeg.LegFuelRemainEnd = fuelWeight - (int)missionLeg.LegFuel;
                fuelWeight = missionLeg.LegFuelRemainEnd;
                // Update dragIndex for the next iteration
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

    public static (int poundPerHour, int calculatedValue) CalculateLegFuel(MissionLegs leg)
    {
        var time = leg.LegDistance / leg.LegSpeed + Convert.ToDouble(leg.LegDelay) / 60;
        FuelFlowDataRetriever getFuel = new();
        var poundPerHour =
            getFuel.RetrieveFuelFlow(leg.LegAltitude, (int)leg.LegDragIndex, (int)leg.LegSpeed,
                leg.LegStartAircraftWeight);
        var calculatedValue = (int)(time * poundPerHour);

        return ((int)poundPerHour, calculatedValue);
    }
}