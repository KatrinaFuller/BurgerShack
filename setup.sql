USE burgershack99;

CREATE TABLE items
(
  id VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(255) NOT NULL,
  price DECIMAL(9,2) NOT NULL,

  PRIMARY KEY(id)
);