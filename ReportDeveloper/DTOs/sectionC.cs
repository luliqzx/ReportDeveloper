using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class sectionC
    {
        //select distinct a.appinfo_id, a.nolot nolot, a.addr1, a.addr2 , c.daerah, d.kawasan,
        //    e.dun_desc, f.value, b.kelulusan, b.luas, b.tarikh_lulus
        public int appinfo_id { get; set; }
        public string nolot { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string daerah { get; set; }
        public string kawasan { get; set; }
        public string dun_desc { get; set; }
        public string value { get; set; }
        public string kelulusan { get; set; }
        public decimal luas { get; set; }
        public DateTime tarikh_lulus { get; set; }
    }
}
