CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS contractors(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'Primary Key',
  create_time DATETIME COMMENT 'Create Time',
  update_time DATETIME COMMENT 'Update Time',
  name TEXT NOT NULL COMMENT 'The Name Of the Contractors',
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) DEFAULT CHARSET UTF8 COMMENT '';