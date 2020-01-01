using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudmusicPlayList2CSV
{
    class Song
    {
        public string name { get; set; }

        public Album al { get; set; }

        public List<Artist> ar { get; set; }

        //This part won't be used at present
        /*
        public int pst { get; set; }

        public int t { get; set; }
       
        public List<string> alia { get; set; }

        public float pop { get; set; }

        public int st { get; set; }

        public object rt { get; set; }

        public int fee { get; set; }

        public int v { get; set; }

        public object crbt { get; set; }

        public string cf { get; set; }

        public int dt { get; set; }
        */

        public string GetArtists()
        {
            string ar = "";
            foreach (Artist art in this.ar)
            {
                ar += art.name + "/";
            }
            ar = ar.Substring(0, ar.Length - 1);
            return ar;
        }
    }
}
