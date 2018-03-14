using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class tbl_sokongan
    {
        #region tbl
        //        CREATE TABLE `sokongan` (
        //    `id` INT(11) NOT NULL AUTO_INCREMENT,
        //    `appinfo_id` INT(11) NULL DEFAULT NULL,
        //    `makkebun_id` INT(11) NOT NULL,
        //    `kelulusan` VARCHAR(70) NULL DEFAULT NULL,
        //    `tarikh_lulus` DATE NULL DEFAULT NULL,
        //    `lot_lulus` VARCHAR(50) NULL DEFAULT NULL,
        //    `luas` DOUBLE NULL DEFAULT NULL,
        //    `sara_hidup` VARCHAR(5) NULL DEFAULT NULL,
        //    `rmk` VARCHAR(10) NOT NULL,
        //    `catatan` TEXT NULL,
        //    `created` DATETIME NULL DEFAULT NULL,
        //    `createdby` VARCHAR(100) NULL DEFAULT NULL,
        //    `agregat` DOUBLE NULL DEFAULT NULL,
        //    `luas_laksana` DOUBLE NOT NULL,
        //    `terkini` INT(11) NOT NULL,
        //    PRIMARY KEY (`id`),
        //    UNIQUE INDEX `makkebun_id_2` (`makkebun_id`),
        //    INDEX `appinfo_id` (`appinfo_id`),
        //    INDEX `makkebun_id` (`makkebun_id`)
        //)
        //COLLATE='latin1_swedish_ci'
        //ENGINE=MyISAM
        //AUTO_INCREMENT=24632
        //;

        #endregion

        public int id { get; set; }
        public int appinfo_id { get; set; }
        public int makkebun_id { get; set; }
        public string kelulusan { get; set; }
        public DateTime tarikh_lulus { get; set; }
        public string lot_lulus { get; set; }
        public decimal luas { get; set; }
        public string sara_hidup { get; set; }
        public string rmk { get; set; }
        public string catatan { get; set; }
        public DateTime created { get; set; }
        public string createdby { get; set; }
        public decimal agregat { get; set; }
        public decimal luas_laksana { get; set; }
        public int terkini { get; set; }

    }
}
