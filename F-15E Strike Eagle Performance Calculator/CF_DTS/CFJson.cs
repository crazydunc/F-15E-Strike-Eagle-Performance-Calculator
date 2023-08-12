using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F_15E_Strike_Eagle_Performance_Calculator.CF_DTS
{
    public partial class Application
    {
        [JsonProperty("Waypoints")]
        public Waypoints Waypoints { get; set; }

        [JsonProperty("Radios")]
        public object Radios { get; set; }

        [JsonProperty("Displays")]
        public object Displays { get; set; }

        [JsonProperty("Misc")]
        public object Misc { get; set; }
    }

    public partial class Waypoints
    {
        [JsonProperty("Waypoints")]
        public List<Waypoint> WaypointsWaypoints { get; set; }

        [JsonProperty("SteerpointStart")]
        public long SteerpointStart { get; set; }

        [JsonProperty("SteerpointEnd")]
        public long SteerpointEnd { get; set; }

        [JsonProperty("OverrideRange")]
        public bool OverrideRange { get; set; }

        [JsonProperty("EnableUpload")]
        public bool EnableUpload { get; set; }

        [JsonProperty("CaptureSettings")]
        public CaptureSettings CaptureSettings { get; set; }
    }

    public partial class CaptureSettings
    {
        [JsonProperty("AppendToWaypointList")]
        public bool AppendToWaypointList { get; set; }

        [JsonProperty("OverwriteFrom")]
        public long OverwriteFrom { get; set; }

        [JsonProperty("OverwriteUntil")]
        public long OverwriteUntil { get; set; }
    }

    public partial class Waypoint
    {
        [JsonProperty("Sequence")]
        public long Sequence { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Latitude")]
        public string Latitude { get; set; }

        [JsonProperty("Longitude")]
        public string Longitude { get; set; }

        [JsonProperty("Elevation")]
        public long Elevation { get; set; }

        [JsonProperty("Target")]
        public bool Target { get; set; }

        [JsonProperty("IsCoordinateBlank")]
        public bool IsCoordinateBlank { get; set; }
    }
}


