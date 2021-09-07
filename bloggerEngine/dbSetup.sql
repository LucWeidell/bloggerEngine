CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS blogs(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  title varchar(255) NOT NULL COMMENT 'Blog Title',
  body varchar(1200) NOT NULL COMMENT 'Blog Body',
  published TINYINT comment 'Is Published',
  imgUrl varchar(255) COMMENT 'Cover Img for blog',
  creatorId varchar(255) NOT NULL COMMENT 'Creator Id',

  FOREIGN KEY (creatorId)
    REFERENCES accounts(id)
    ON DELETE CASCADE
) default charset utf8 COMMENT '';







