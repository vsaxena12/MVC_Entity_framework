create database MVC_EntityFrameWork
use MVC_EntityFrameWork

create database SampleProjectNew
use SampleProjectNew

ALTER TABLE Orders
ADD FOREIGN KEY (PersonID) REFERENCES Persons(PersonID);

select * from [user];

insert into [user] values (1,'Varun','Varun141092$','Manager');