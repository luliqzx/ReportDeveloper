using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    public class tbl_makkebun
    {
        #region tbl
        //       CREATE TABLE `makkebun` (
        //    `id_makkebun` INT(11) NOT NULL AUTO_INCREMENT,
        //    `appinfo_id` INT(11) NOT NULL,
        //    `addr1` VARCHAR(100) NULL DEFAULT NULL,
        //    `addr2` VARCHAR(100) NULL DEFAULT NULL,
        //    `addr3` VARCHAR(100) NULL DEFAULT NULL,
        //    `daerah` VARCHAR(30) NOT NULL COLLATE 'latin1_general_ci',
        //    `dun` VARCHAR(100) NOT NULL COLLATE 'latin1_general_ci',
        //    `parlimen` INT(11) NULL DEFAULT NULL,
        //    `poskod` VARCHAR(5) NULL DEFAULT NULL,
        //    `negeri` VARCHAR(20) NULL DEFAULT NULL COLLATE 'latin1_general_ci',
        //    `nolot` VARCHAR(20) NULL DEFAULT NULL,
        //    `hakmiliktanah` VARCHAR(30) NOT NULL,
        //    `tncr` VARCHAR(30) NOT NULL,
        //    `luasmatang` DOUBLE NULL DEFAULT NULL,
        //    `tebang` VARCHAR(5) NULL DEFAULT NULL,
        //    `tarikhtebang` VARCHAR(20) NULL DEFAULT NULL,
        //    `nolesen` VARCHAR(50) NULL DEFAULT NULL,
        //    `syarattanah` VARCHAR(22) NOT NULL,
        //    `pemilikan` VARCHAR(10) NULL DEFAULT NULL,
        //    `pengurusan` VARCHAR(20) NULL DEFAULT NULL,
        //    `luaslesen` DOUBLE NULL DEFAULT NULL,
        //    `catatan` TEXT NULL,
        //    `created` DATETIME NULL DEFAULT NULL,
        //    `createdby` VARCHAR(100) NULL DEFAULT NULL,
        //    PRIMARY KEY (`id_makkebun`),
        //    INDEX `appinfo_id` (`appinfo_id`),
        //    INDEX `appinfo_id_2` (`appinfo_id`),
        //    INDEX `id_makkebun` (`id_makkebun`),
        //    INDEX `daerah` (`daerah`),
        //    INDEX `parlimen` (`parlimen`)
        //)
        //COLLATE='latin1_swedish_ci'
        //ENGINE=MyISAM
        //AUTO_INCREMENT=26077
        //;
        #endregion

        public int id_makkebun { get; set; }
        public int appinfo_id { get; set; }
        public string addr1 { get; set; }
        public string addr2 { get; set; }
        public string addr3 { get; set; }
        public string daerah { get; set; }
        public string dun { get; set; }
        public int parlimen { get; set; }
        public string poskod { get; set; }
        public string negeri { get; set; }
        public string nolot { get; set; }
        public string hakmiliktanah { get; set; }
        public string tncr { get; set; }
        public string luasmatang { get; set; }
        public string tebang { get; set; }
        public string tarikhtebang { get; set; }
        public string nolesen { get; set; }
        public string syarattanah { get; set; }
        public string pemilikan { get; set; }
        public string pengurusan { get; set; }
        public decimal luaslesen { get; set; }
        public string catatan { get; set; }
        public DateTime created { get; set; }
        public string createdby { get; set; }


    }
}
