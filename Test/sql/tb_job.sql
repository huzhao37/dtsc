

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tb_job
-- ----------------------------
DROP TABLE IF EXISTS `tb_job`;
CREATE TABLE `tb_job`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `single` bit(1) NOT NULL DEFAULT b'0',
  `datamap` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `node_id` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `state` bit(1) NOT NULL DEFAULT b'0',
  `version` int(11) NOT NULL,
  `runcount` int(11) NOT NULL,
  `createtime` bigint(20) NOT NULL,
  `lastedstart` bigint(20) NOT NULL,
  `lastedend` bigint(20) NOT NULL,
  `nextstart` bigint(20) NOT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `cron` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
