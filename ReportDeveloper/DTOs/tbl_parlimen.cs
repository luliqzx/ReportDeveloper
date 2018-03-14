using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportDeveloper.DTOs
{
    class tbl_parlimen
    {
        #region tbl
        //        CREATE TABLE `parlimen` (
        //    `id` INT(11) NOT NULL AUTO_INCREMENT,
        //    `negeri` VARCHAR(100) NOT NULL,
        //    `kawasan` VARCHAR(100) NOT NULL,
        //    PRIMARY KEY (`id`),
        //    INDEX `id` (`id`),
        //    INDEX `id_2` (`id`),
        //    INDEX `id_3` (`id`)
        //)
        //COLLATE='latin1_swedish_ci'
        //ENGINE=MyISAM
        //AUTO_INCREMENT=235
        //;

        #endregion

        public int id { get; set; }
        public string negeri { get; set; }
        public string kawasan { get; set; }

    }
}
