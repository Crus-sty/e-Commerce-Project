CREATE USER 'frontend'@'%' IDENTIFIED BY '(iCodeFrontEnd123!)';
CREATE USER 'backend1'@'%' IDENTIFIED BY '(weCodeBackEnd123!)';
CREATE USER 'backend2'@'%' IDENTIFIED BY '(weCodeBackEnd123!)';

REVOKE ALL PRIVILEGES ON ecommercedb.* FROM 'backend2'@'%';
GRANT SELECT, INSERT, UPDATE, INDEX, DELETE ON ecommercedb.* TO 'backend2'@'%';


SHOW GRANTS;

SELECT User, Host
FROM mysql.user;

FLUSH PRIVILEGES;

SELECT user, host
FROM mysql.user;

SHOW GRANTS FOR 'backend2'@'%';