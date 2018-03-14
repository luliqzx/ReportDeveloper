using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class tbl_pembayaran
    {
        #region tbl
        //        CREATE TABLE `pembayaran` (
        //    `id` INT(11) NOT NULL AUTO_INCREMENT,
        //    `appinfo_id` VARCHAR(111) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `tujuan` VARCHAR(100) NULL DEFAULT NULL,
        //    `no_cek` VARCHAR(50) NULL DEFAULT NULL,
        //    `amaun` DOUBLE(10,2) NULL DEFAULT NULL,
        //    `tarikh_cek` DATE NULL DEFAULT NULL,
        //    `bulan` VARCHAR(11) NOT NULL,
        //    `tahun` VARCHAR(11) NOT NULL,
        //    `tarikh_cek_hantar` VARCHAR(20) NULL DEFAULT NULL,
        //    `penerima` VARCHAR(150) NULL DEFAULT NULL,
        //    `bank` VARCHAR(50) NULL DEFAULT NULL,
        //    `no_akaun` VARCHAR(50) NULL DEFAULT NULL,
        //    `catatan` TEXT NULL,
        //    `created` DATETIME NULL DEFAULT NULL,
        //    `createdby` VARCHAR(100) NULL DEFAULT NULL,
        //    `id_po` INT(11) NOT NULL,
        //    `no_po` VARCHAR(20) NULL DEFAULT NULL,
        //    `no_invois` VARCHAR(20) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `tarikh_invois` VARCHAR(20) NULL DEFAULT NULL,
        //    `id_century` VARCHAR(25) NOT NULL,
        //    `id_pembayaran` INT(20) NOT NULL,
        //    `sts_byr` INT(2) NOT NULL,
        //    `sts_upload` INT(11) NOT NULL COMMENT '1 = upload',
        //    `date_payment` DATE NOT NULL,
        //    `batch` VARCHAR(100) NOT NULL,
        //    `no_rujukan` VARCHAR(30) NOT NULL COLLATE 'latin1_general_ci',
        //    `date_upload` DATE NOT NULL,
        //    `icno` VARCHAR(15) NOT NULL COLLATE 'latin1_general_ci',
        //    `no_siri_kupon` VARCHAR(100) NOT NULL,
        //    PRIMARY KEY (`id`),
        //    INDEX `appinfo_id` (`appinfo_id`),
        //    INDEX `tujuan` (`tujuan`),
        //    INDEX `icno` (`icno`),
        //    INDEX `amaun` (`amaun`)
        //)
        //COLLATE='latin1_swedish_ci'
        //ENGINE=MyISAM
        //AUTO_INCREMENT=284222
        //;

        #endregion
        public int id { get; set; }
        public int appinfo_id { get; set; }
        public string tujuan { get; set; }
        public string no_cek { get; set; }
        public decimal amaun { get; set; }
        public DateTime tarikh_cek { get; set; }
        public string bulan { get; set; }
        public string tahun { get; set; }
        public string tarikh_cek_hantar { get; set; }
        public string penerima { get; set; }
        public string bank { get; set; }
        public string no_akaun { get; set; }
        public string catatan { get; set; }
        public DateTime created { get; set; }
        public string createdby { get; set; }
        public int id_po { get; set; }
        public string no_po { get; set; }
        public string no_invois { get; set; }
        public string tarikh_invois { get; set; }
        public string id_century { get; set; }
        public int id_pembayaran { get; set; }
        public int sts_byr { get; set; }
        public int sts_upload { get; set; }
        public DateTime date_payment { get; set; }
        public string batch { get; set; }
        public string no_rujukan { get; set; }
        public DateTime date_upload { get; set; }
        public string icno { get; set; }
        public string no_siri_kupon { get; set; }

    }
}
