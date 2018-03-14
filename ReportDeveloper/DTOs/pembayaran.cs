using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class pembayaran
    {
        #region tbl
        //appinfo_id	tarikh	penerima	amaun	tujuan

        #endregion

        public int appinfo_id { get; set; }
        public DateTime tarikh { get; set; }
        public string penerima { get; set; }
        public decimal amaun { get; set; }
        public string tujuan { get; set; }

    }
}
