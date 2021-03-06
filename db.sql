create schema if not exists pets authorization postgres;

ALTER SYSTEM SET max_connections TO '500';
ALTER SYSTEM SET shared_buffers TO '1280MB'

drop table if exists pets.pet;

create table pets.pet(
    Id SERIAL,
    Name varchar not null,
    Category int not null,
    Status int not null,
    Tags varchar,
    Created timestamp not null,
    CreatedBy varchar not null,
    Modified timestamp,
    ModifiedBy varchar,
    Deleted timestamp,
    DeletedBy varchar,
    IsDelete bool default false not null
);

drop table if exists pets.photo;

create table pets.photo(
    Id uuid,
    PetId int not null,
    Url varchar not null,
    MetaData varchar not null,
    Created timestamp not null,
    CreatedBy varchar not null,
    Modified timestamp,
    ModifiedBy varchar,
    Deleted timestamp,
    DeletedBy varchar,
    IsDelete bool default false not null
);

create schema if not exists orders authorization postgres;

drop table if exists orders.order;

create table orders.order(
    Id SERIAL,
    PetId int not null,
    Quantity int not null,
    ShipDate timestamp not null,
    Status int not null,
    Complete bool not null,
    Created timestamp not null,
    CreatedBy varchar not null,
    Modified timestamp,
    ModifiedBy varchar,
    Deleted timestamp,
    DeletedBy varchar,
    IsDelete bool default false not null
);

create schema if not exists users authorization postgres;

drop table if exists users.user;

create table users.user(
   Id SERIAL,
   UserName varchar,
   FirstName varchar,
   LastName varchar,
   Email varchar,
   PasswordHash varchar,
   Salt varchar,
   Phone varchar,
   Status int not null,
   Created timestamp not null,
   CreatedBy varchar not null,
   Modified timestamp,
   ModifiedBy varchar,
   Deleted timestamp,
   DeletedBy varchar,
   IsDelete bool default false not null
);