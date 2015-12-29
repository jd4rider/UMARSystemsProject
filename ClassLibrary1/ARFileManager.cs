using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveARFiles
{
    public class ARFileManage
    {
        public static void findDateMonth()
        {
            DateTime now = DateTime.Now;

            string shortMonth = now.ToString("MMM");
            string fromPath = @"\\mtransfer.gs.umt.edu\transfers\bs\stuAR\";

            string[][] filePathRelation =
            {
                new string[] {"mbrf*", "ms030*", "mbdpp*", "mb360*", "mbstar*" },
                new string[] {}
            };
                        
            
        }
            
       
    }
}
