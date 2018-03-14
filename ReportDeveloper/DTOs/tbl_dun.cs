using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class tbl_dun
    {
        #region tbl
        //        CREATE TABLE `dun` (
        //    `id` INT(10) NOT NULL AUTO_INCREMENT,
        //    `kod_negeri` VARCHAR(10) NOT NULL COLLATE 'latin1_general_ci',
        //    `kod_dun` VARCHAR(10) NOT NULL COLLATE 'latin1_general_ci',
        //    `dun_desc` VARCHAR(100) NOT NULL COLLATE 'latin1_general_ci',
        //    PRIMARY KEY (`id`),
        //    INDEX `kod_negeri` (`kod_negeri`),
        //    INDEX `kod_daerah` (`kod_dun`),
        //    INDEX `kod_daerah_2` (`kod_dun`)
        //)
        //COLLATE='latin1_general_ci'
        //ENGINE=MyISAM
        //AUTO_INCREMENT=592
        //;

        #endregion

        public int id { get; set; }
        public string kod_negeri { get; set; }
        public string kod_dun { get; set; }
        public string dun_desc { get; set; }

    }
}
