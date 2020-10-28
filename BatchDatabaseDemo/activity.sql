--drop table batch;
--drop table trainers;
--drop table associates;
create table associates
(
	id serial primary key,
	associateName varchar(100) not null,
	associateState varchar(2) not null
);

create table trainers
(
	id serial primary key,
	trainerName varchar(100) not null,
	campus varchar(3) not null
);

create table batch
(
	id serial primary key,
	associateID int references associates (id),
	trainerID int references trainers (id)
);

insert into associates (associateName, associateState) values
('Michael', 'CA'),
('Brian', 'MN'),
('Lindsey', 'SC'),
('Angela', 'TX'),
('Drew', 'AZ');

insert into trainers (trainerName, campus) values
('Marielle', 'USF'),
('Pushpinder', 'UTA'),
('Nick', 'UTA'),
('Sierra', 'WVU'),
('Wezley', 'USF');

insert into batch (associateID, trainerID) values
(1,1),
(1,2),
(2,1),
(2,2),
(3,1),
(3,2),
(4,1),
(4,2),
(5,4);

--add 5 associates to the associate table
insert into associates (associateName, associateState) values
('Anthony', 'NJ'),
('Carson', 'NY'),
('Andres', 'WV'),
('John', 'KY'),
('Angela', 'NY');

--select * from associates;

--get all associates that live in a certain state
SELECT associatename from associates where associatestate= 'NY';

--get the number of associates living in each state (descending order)
SELECT associatestate, COUNT(id) numOfAssociates FROM associates GROUP BY  associatestate
ORDER BY numOfAssociates DESC ;

--get the number of associates living in each state (ascending order)
SELECT associatestate, COUNT(id) 
FROM associates
GROUP BY  associatestate
ORDER BY COUNT(id) ASC ;

--get all trainers without associates using join
select trainername, associateid from trainers 
left outer join batch on trainers.id = batch.trainerid
where associateid isnull;
--get all trainers without associates using subqueries
select trainername from trainers 
where id not in (select trainerid from batch);

--get all associates mapped to a trainer using join
select associatename, trainername from associates
inner join batch on associates.id = batch.associateid
inner join trainers on batch.trainerid = trainers.id
where trainers.trainername = 'Marielle'

--get all associates without a trainer using join
select associatename, trainerid from associates
left outer join batch on associates.id = batch.associateid
where trainerid isnull;