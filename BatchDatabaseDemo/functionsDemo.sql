--SQL functions demo

--setup
create table products
(
	id serial primary key,
	productName varchar,
	productPrice decimal
);

insert into products (productName, productPrice) values
('Apple', 1.99),
('Orange', 2.30),
('Banana', 0.99),
('Grapes', 2.50),
('Apple', 3.50);

select * from products;

--aggregate functions
select avg(productPrice) from products;

select count(*) numOfProducts from products;

select count(distinct productName) numOfUniqueProducts from products;