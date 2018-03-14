using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class tbl_appinfo
    {
        #region tbl
        //        CREATE TABLE `appinfo` (
        //    `id` INT(11) NOT NULL,
        //    `refno` VARCHAR(100) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `nama` VARCHAR(100) NOT NULL COLLATE 'latin1_swedish_ci',
        //    `type_id` INT(11) NOT NULL,
        //    `icno` VARCHAR(100) NOT NULL COLLATE 'latin1_general_ci',
        //    `nolesen` VARCHAR(30) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `bangsa` VARCHAR(30) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `addr1` VARCHAR(100) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `addr2` VARCHAR(100) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `addr3` VARCHAR(100) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `bandar` VARCHAR(100) NOT NULL COLLATE 'latin1_general_ci',
        //    `daerah` VARCHAR(30) NOT NULL COLLATE 'latin1_general_ci',
        //    `dun` VARCHAR(100) NOT NULL COLLATE 'latin1_general_ci',
        //    `parlimen` INT(11) NULL DEFAULT NULL,
        //    `poskod` VARCHAR(5) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `negeri` VARCHAR(20) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `hometel` VARCHAR(20) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `officetel` VARCHAR(20) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `hptel` VARCHAR(20) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `faks` VARCHAR(20) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `email` VARCHAR(50) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `kelompok` VARCHAR(5) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `created` DATETIME NULL DEFAULT NULL,
        //    `createdby` VARCHAR(100) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `appdate` VARCHAR(50) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `semak_tapak` VARCHAR(1) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `keputusan` VARCHAR(20) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `sts_bck` INT(11) NOT NULL,
        //    `status` INT(11) NOT NULL,
        //    `date_approved` DATETIME NOT NULL,
        //    `approved_by` VARCHAR(255) NOT NULL COLLATE 'latin1_general_ci',
        //    `sop` TINYINT(4) NOT NULL,
        //    `status_bantuan` VARCHAR(4) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    PRIMARY KEY (`id`),
        //    INDEX `keputusan` (`keputusan`),
        //    INDEX `semak_tapak` (`semak_tapak`),
        //    INDEX `refno` (`refno`),
        //    INDEX `id` (`id`),
        //    INDEX `id_2` (`id`),
        //    INDEX `icno_2` (`icno`),
        //    FULLTEXT INDEX `icno` (`icno`)
        //)
        //COLLATE='latin1_general_ci'
        //ENGINE=MyISAM
        //;

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
    }
}
