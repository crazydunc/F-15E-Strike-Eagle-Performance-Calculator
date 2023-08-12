using System.Xml;

namespace F_15E_Strike_Eagle_Performance_Calculator.Core
{
    internal static class ParseXml
    {
        public static List<CF_DTS.Waypoint> LoadCombatFliteXml(string file)
        {
            try
            {
                var xmlDoc = new XmlDocument();

                xmlDoc.Load(file);
                List<CF_DTS.Waypoint> waypointsList = new List<CF_DTS.Waypoint>();

                var waypointNodes = xmlDoc.SelectNodes("//Waypoint");
                if (waypointNodes != null)
                    foreach (XmlNode waypointNode in waypointNodes)
                    {
                        var nameNode = waypointNode.SelectSingleNode("Name");
                        var latitudeNode = waypointNode.SelectSingleNode("Position/Latitude");
                        var longitudeNode = waypointNode.SelectSingleNode("Position/Longitude");
                        var altitudeNode = waypointNode.SelectSingleNode("Position/Altitude");
                        var typeNode = waypointNode.SelectSingleNode("Type"); // Check for Type element

                        if (nameNode != null && latitudeNode != null && longitudeNode != null && altitudeNode != null)
                        {
                            var waypoint = new CF_DTS.Waypoint
                            {
                                Sequence = waypointsList.Count + 1,
                                Name = /*nameNode.InnerText.Replace("\r\n", " "),*/ "WPT " + (waypointsList.Count + 1),
                                Latitude = GeoWorker.ConvertToFormattedLatitude(
                                    Convert.ToDouble(latitudeNode.InnerText)),
                                Longitude =
                                    GeoWorker.ConvertToFormattedLongitude(Convert.ToDouble(longitudeNode.InnerText)),
                                Elevation = GeoWorker.ConvertMetersToFeet(Convert.ToDouble(altitudeNode.InnerText)),
                                Target = typeNode != null && typeNode.InnerText == "Strike", // Check for "Strike" type
                                IsCoordinateBlank = false // Set this value as needed
                            };

                            waypointsList.Add(waypoint);
                        }
                    }

                return waypointsList;
            }
            catch (Exception exception)
            {
                Log.WriteLog("Error Reading CF File. Please send Dunc the CF XML as well as the logs.");
                Log.WriteLog(exception.ToString());
                return null;
            }
        }
    }
}
