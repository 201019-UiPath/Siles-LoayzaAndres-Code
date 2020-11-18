---------------------------------------------------------------------------
--                          SQL Functions Demo                           --
---------------------------------------------------------------------------

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


---------------------------------------------------------------------------
--                   Scalar Functions with strings                       --
---------------------------------------------------------------------------
select productName, char_length(productName) from products
select productName, lower(productName) from products
select productName, upper(productName) from products
select productName, substring(productName from 1 for 3) from products


---------------------------------------------------------------------------
--                  Scalar Functions with DateTime                       --
---------------------------------------------------------------------------
drop table "table";
drop table "table2";

create table "table"
(       
        id serial primary key,
        description varchar(100),
        orderDate Timestamp not null default Now(),
				--Time HH:MM:SS
				--Date YYYY-MM-DD
		floatval float not null
);

insert into "table" (description, floatval) values
('green', 3.5843),
('red', Round(3.5843, 2));

insert into "table" (description, floatval) values
('teal', Round(2.222,0));

select * from "table";

select to_char(orderDate, 'HH:MM:SS') from "table";

create table "table2"
(       
        id serial primary key,
        description varchar(100),
        orderDate Date not null default Now()
);

insert into "table2" (description) values
('green');

insert into "table2" (description) values
('yellow');

select * from "table2";

SELECT to_char(orderDate, 'HH:MM:SS') from table2;

select Format('%s%s%s%s%s%s%s%s%s%s%s%s', 'Ba', 'rne', 'y', ' ', 'is a pe', 'do', ' my ', 'chi', 'ldho', 'od i', 's cr', 'ushed')


---------------------------------------------------------------------------
--                          Custom Functions                             --
---------------------------------------------------------------------------
CREATE FUNCTION addints(i integer,j integer) RETURNS integer AS $$
        BEGIN
                RETURN i + j;
        END;
$$ LANGUAGE plpgsql;

select * from addints(2,3);

create or replace function addints(i integer,j integer) returns integer AS $$
        BEGIN
                RETURN j + i + 50;
        END;
$$ LANGUAGE plpgsql;

select * from addints(2,3);

alter function addints(integer, integer) rename to intadd;
select * from intadd(2,10);
drop function intadd(integer,integer);


-- table as input/output
drop table products;
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

create or replace function productnames() returns table (productName varchar) 
language plpgsql as $$
begin
	return query select products.productName from products;
end;$$

select productnames();


---------------------------------------------------------------------------
--                          Aggregate Functions                          --
---------------------------------------------------------------------------
select * from products;

select avg(productPrice) from products;
select count(*) numOfProducts from products;
select count(distinct productName) numOfUniqueProducts from products;
insert into products (productName) values
('Avocado');

select count(distinct upper(productName)) from products;

---------------------------------------------------------------------------
--                            Tabular Functions                           --
---------------------------------------------------------------------------
DROP FUNCTION IF EXISTS discount_products;
DROP FUNCTION IF EXISTS steeply_discount_products;
DROP FUNCTION IF EXISTS discount_products_return_one;

CREATE FUNCTION discount_products (x int, OUT productName varchar, OUT normalPrice decimal, OUT discountedPrice decimal)
RETURNS SETOF record
AS $$
    SELECT productName, productPrice, round((100 - $1) * 0.01 * productPrice, 2) FROM products;
$$ LANGUAGE SQL;

CREATE FUNCTION steeply_discount_products (x int)
RETURNS TABLE(productName varchar, normalPrice decimal, steeplyDiscountedPrice decimal) AS $$
    SELECT productName, productPrice, round((100 - $1) * 0.01 * 0.5 * productPrice, 2) FROM products;
$$ LANGUAGE SQL;

CREATE FUNCTION discount_products_return_one (x int, OUT productName varchar, OUT normalPrice decimal, OUT discountedPrice decimal)
RETURNS record
AS $$
    SELECT productName, productPrice, round((100 - $1) * 0.01 * productPrice, 2) FROM products;
$$ LANGUAGE SQL;

SELECT * FROM discount_products(20);
SELECT * FROM steeply_discount_products(20);
SELECT * FROM discount_products_return_one(20);
