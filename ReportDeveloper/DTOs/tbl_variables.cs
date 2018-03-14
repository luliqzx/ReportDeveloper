using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class tbl_variables
    {
        #region tbl
        //        CREATE TABLE `variables` (
        //    `code` VARCHAR(30) NOT NULL COLLATE 'latin1_general_ci',
        //    `value` VARCHAR(50) NOT NULL COLLATE 'latin1_general_ci',
        //    `type` VARCHAR(50) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `parent` VARCHAR(5) NULL DEFAULT NULL COLLATE 'latin1_general_ci'
        //)
        //COLLATE='latin1_general_ci'
        //ENGINE=MyISAM
        //;

        #endregion

        public string code { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public string parent { get; set; }

    }
}
