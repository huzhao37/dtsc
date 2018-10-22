

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tb_zip
-- ----------------------------
DROP TABLE IF EXISTS `tb_zip`;
CREATE TABLE `tb_zip`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `job_id` int(11) NOT NULL,
  `version` int(11) NOT NULL,
  `zipfilename` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `zipfile` longblob NOT NULL,
  `time` bigint(20) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 21 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
