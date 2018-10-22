

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tb_performance
-- ----------------------------
DROP TABLE IF EXISTS `tb_performance`;
CREATE TABLE `tb_performance`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `job_id` int(11) NOT NULL,
  `node_id` int(11) NOT NULL,
  `cpu` float NOT NULL,
  `memory` float NOT NULL COMMENT '内存MB',
  `installdirsize` float NOT NULL COMMENT '线程数',
  `updatetime` bigint(20) NOT NULL,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 210 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
