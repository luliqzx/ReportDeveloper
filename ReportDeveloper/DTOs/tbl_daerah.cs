using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class tbl_daerah
    {
        #region tbl
        //        CREATE TABLE `daerah` (
        //    `id` INT(11) NOT NULL AUTO_INCREMENT,
        //    `kod_negeri` VARCHAR(10) NOT NULL COLLATE 'latin1_general_ci',
        //    `kod_daerah` VARCHAR(10) NOT NULL COLLATE 'latin1_general_ci',
        //    `daerah` VARCHAR(100) NOT NULL COLLATE 'latin1_general_ci',
        //    `daerah_spe` VARCHAR(100) NOT NULL COLLATE 'latin1_general_ci',
        //    PRIMARY KEY (`id`),
        //    INDEX `kod_negeri` (`kod_negeri`),
        //    INDEX `kod_daerah` (`kod_daerah`),
        //    INDEX `kod_daerah_2` (`kod_daerah`)
        //)
        //COLLATE='latin1_general_ci'
        //ENGINE=MyISAM
        //AUTO_INCREMENT=208
        //;

        #endregion

        public int id { get; set; }
        public string kod_negeri { get; set; }
        public string kod_daerah { get; set; }
        public string daerah { get; set; }
        public string daerah_spe { get; set; }
    }
}
