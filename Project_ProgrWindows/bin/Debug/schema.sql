DROP TABLE IF EXISTS `products`;
DROP TABLE IF EXISTS `categories`;

CREATE TABLE `categories` (
	`category_id` INT(9) AUTO_INCREMENT,
	`name` VARCHAR(128) NOT NULL,
	PRIMARY KEY `category_id` (`category_id`)
);


CREATE TABLE `products` (
	`product_id` INT(9) AUTO_INCREMENT,
	`name` VARCHAR(128) NOT NULL,
	`price` DECIMAL(11, 4),
	`sku` VARCHAR(128) NOT NULL,
	`category_id` INT(9) NOT NULL,
	`status` SMALLINT(2) NOT NULL,
	`stock_qty` INT(6) UNSIGNED NOT NULL DEFAULT 0,
	PRIMARY KEY `product_id` (`product_id`),
	UNIQUE `sku` (`sku`),
	FOREIGN KEY `cat_id` (`category_id`) REFERENCES `categories` (`category_id`) ON DELETE CASCADE
);

-- Add some data...
INSERT INTO categories VALUES (null, 'Telefoane');
INSERT INTO categories VALUES (null, 'Tablete');

INSERT INTO products VALUES (null, "iPhone 5S APPLE 16GB, 4\", 8MP, Wi-Fi, Black", 2890.15, "IPHONE5S-BLACK", 1, 1, 35),
(null, "iPhone 5S APPLE 16GB, 4\", 8MP, Wi-Fi, White", 2890.15, "IPHONE5S-WHITE", 1, 1, 52),
(null, "Tableta ALLVIEW Viva Q7 Life, Wi-Fi, 7.0\", 8GB", 390.50, "TABALLQ7LIFEWH", 2, 2, 7);