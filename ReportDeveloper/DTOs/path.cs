using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class path
    {
        #region tbl
        //id	refno	nama	type_id	icno	nolesen	bangsa	addr1	addr2	addr3	bandar	daerah	dun	parlimen	poskod	negeri	hometel	officetel	hptel	faks	email	kelompok	created	createdby	appdate	semak_tapak	keputusan	sts_bck	status	date_approved	approved_by	sop	status_bantuan	d_daerah	p_parlimen	v_negeri

        #endregion
        public int id { get; set; }
        public string refno { get; set; }
        public string nama { get; set; }
        public int type_id { get; set; }
        public string icno { get; set; }
        public string nolesen { get; set; }
        public string bangsa { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string addr3 { get; set; }
        public string bandar { get; set; }
        public string daerah { get; set; }
        public string dun { get; set; }
        public int parlimen { get; set; }
        public string poskod { get; set; }
        public string negeri { get; set; }
        public string hometel { get; set; }
        public string officetel { get; set; }
        public string hptel { get; set; }
        public string faks { get; set; }
        public string email { get; set; }
        public string kelompok { get; set; }
        public DateTime created { get; set; }
        public string createdby { get; set; }
        public string appdate { get; set; }
        public string semak_tapak { get; set; }
        public string keputusan { get; set; }
        public int sts_bck { get; set; }
        public int status { get; set; }
        public DateTime date_approved { get; set; }
        public string approved_by { get; set; }
        public string sop { get; set; }
        public string status_bantuan { get; set; }
        public string d_daerah { get; set; }
        public string p_parlimen { get; set; }
        public string v_negeri { get; set; }
    }
}
