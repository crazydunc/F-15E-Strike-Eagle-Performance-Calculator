using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace F_15E_Strike_Eagle_Performance_Calculator.Imports
{
    public class CFImports
    {
        public List<CFRoute> CfRoutes { get; set; } 
    }

    public class CFRoute
    {

        public string Name { get; set; }
        public string MsnNumber { get; set; }
        public List<Waypoint> Waypoints { get; set; }

    }


}
