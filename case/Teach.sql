/*
Navicat MySQL Data Transfer

Source Server         : 115
Source Server Version : 50714
Source Host           : 192.168.1.115:3306
Source Database       : Teach

Target Server Type    : MYSQL
Target Server Version : 50714
File Encoding         : 65001

Date: 2017-05-05 11:42:38
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `Goods`
-- ----------------------------
DROP TABLE IF EXISTS `Goods`;
CREATE TABLE `Goods` (
  `GoodsId` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '商品id',
  `GoodsName` varchar(100) NOT NULL COMMENT '商品名称',
  `Money` decimal(10,0) NOT NULL COMMENT '商品价格',
  `Num` int(11) NOT NULL COMMENT '商品库存',
  `Info` varchar(255) DEFAULT NULL COMMENT '商品详情',
  `CreateTime` datetime DEFAULT NULL COMMENT 'c创建时间',
  PRIMARY KEY (`GoodsId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Goods
-- ----------------------------

-- ----------------------------
-- Table structure for `Order`
-- ----------------------------
DROP TABLE IF EXISTS `Order`;
CREATE TABLE `Order` (
  `OrderId` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '订单id',
  `OrderSn` varchar(20) NOT NULL COMMENT '订单编号',
  `CreatTime` datetime NOT NULL COMMENT '创建时间',
  `UserId` int(11) NOT NULL COMMENT '用户ID',
  `OrderMoney` decimal(10,0) NOT NULL DEFAULT '0' COMMENT '订单金额',
  `Status` tinyint(4) NOT NULL DEFAULT '0' COMMENT '订单状态0未确认/1确认/2取消',
  PRIMARY KEY (`OrderId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Order
-- ----------------------------
订单
-- ----------------------------
-- Table structure for `OrderGoods`
-- ----------------------------
DROP TABLE IF EXISTS `OrderGoods`;
CREATE TABLE `OrderGoods` (
  `OrderGoodsId` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '订单商品表id',
  `OrderId` int(11) NOT NULL COMMENT '订单id',
  `GoodsId` int(11) NOT NULL COMMENT '商品id',
  `GoodsNum` int(11) NOT NULL COMMENT '商品数量',
  `AddTime` datetime NOT NULL COMMENT '添加时间',
  `GoodsPrice` decimal(10,0) NOT NULL COMMENT '商品购买时价格',
  PRIMARY KEY (`OrderGoodsId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of OrderGoods
-- ----------------------------

-- ----------------------------
-- Table structure for `Users`
-- ----------------------------
DROP TABLE IF EXISTS `Users`;
CREATE TABLE `Users` (
  `UserId` bigint(20) unsigned NOT NULL AUTO_INCREMENT COMMENT '主键',
  `UserName` varchar(100) NOT NULL COMMENT '用户名',
  `Password` varchar(200) NOT NULL COMMENT '密码',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of Users
-- ----------------------------
INSERT INTO `Users` VALUES ('1', 'admin', 'C71E4A3022C7185B', '2017-05-04 19:15:39');
INSERT INTO `Users` VALUES ('2', 'admin2', 'F9CDC81C8458E1F8', '2017-05-04 19:18:33');
INSERT INTO `Users` VALUES ('3', 'test1', '53F10618BAF557E1', '2017-05-04 19:37:35');
