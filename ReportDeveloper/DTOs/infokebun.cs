using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class infokebun
    {
        #region tbl
        //appinfo_id	tarikh_lulus	parlimen	dun	no_lot	addr1	addr2	addr3	negeri	daerah	luas

        #endregion
        public int appinfo_id { get; set; }
        public DateTime tarikh_lulus { get; set; }
        public string parlimen { get; set; }
        public string dun { get; set; }
        public string no_lot { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string addr3 { get; set; }
        public string negeri { get; set; }
        public string daerah { get; set; }
        public decimal luas { get; set; }

    }
}
