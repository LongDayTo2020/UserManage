create table role_groups
(
    id          integer generated always as identity
        primary key,
    name        varchar(255) not null,
    create_time timestamp    not null,
    create_user varchar(255) not null,
    update_time timestamp,
    update_user varchar(255)
);

comment on table role_groups is '群組';

alter table role_groups
    owner to postgres;

create table users
(
    id          integer generated always as identity
        primary key,
    name        varchar(255) not null,
    account     varchar(255) not null,
    mail        varchar(255) not null,
    phone       varchar(255) not null,
    password    varchar(255) not null,
    birthday    timestamp    not null,
    create_time timestamp    not null,
    create_user varchar(255) not null,
    update_time timestamp,
    update_user varchar(255)
);

comment on table users is '會員';

alter table users
    owner to postgres;

create table roles
(
    id          integer generated always as identity
        primary key,
    name        varchar(255),
    create_time timestamp    not null,
    create_user varchar(255) not null,
    update_time timestamp,
    update_user varchar(255)
);

comment on table roles is '角色';

alter table roles
    owner to postgres;

create table permissions
(
    id          integer generated always as identity
        primary key,
    name        varchar(255) not null,
    create_time timestamp    not null,
    create_user varchar(255) not null,
    update_time timestamp,
    update_user varchar(255)
);

comment on table permissions is '權限';

alter table permissions
    owner to postgres;

create table user_groups
(
    id          integer generated always as identity
        primary key,
    name        varchar(255),
    create_time timestamp    not null,
    create_user varchar(255) not null,
    update_time timestamp,
    update_user varchar(255)
);

comment on table user_groups is '會員組';

alter table user_groups
    owner to postgres;

create table service_units
(
    id          integer      not null
        primary key,
    name        varchar(255),
    create_time timestamp    not null,
    create_user varchar(255) not null,
    update_time timestamp,
    update_user varchar(255)
);

comment on table service_units is '營運';

alter table service_units
    owner to postgres;

create table roles_permissions_relationships
(
    role_id        integer           not null
        references roles,
    permissions_id integer           not null
        references permissions,
    is_create      integer default 0 not null,
    is_update      integer default 0 not null,
    is_read        integer default 0 not null,
    is_delete      integer default 0 not null,
    is_verify      integer default 0 not null,
    create_time    timestamp         not null,
    create_user    varchar(255)      not null,
    update_time    timestamp,
    update_user    varchar(255),
    primary key (role_id, permissions_id)
);

comment on table roles_permissions_relationships is '角色與權限關係';

comment on column roles_permissions_relationships.is_create is '新增';

comment on column roles_permissions_relationships.is_update is '更新';

comment on column roles_permissions_relationships.is_read is '讀取';

comment on column roles_permissions_relationships.is_delete is '刪除';

comment on column roles_permissions_relationships.is_verify is '驗證';

alter table roles_permissions_relationships
    owner to postgres;

create table users_role_groups_relationships
(
    user_id       integer      not null
        references users,
    role_group_id integer      not null
        references role_groups,
    create_time   timestamp    not null,
    create_user   varchar(255) not null,
    update_time   timestamp,
    update_user   varchar(255),
    primary key (user_id, role_group_id)
);

comment on table users_role_groups_relationships is '會員與角色群組關係';

alter table users_role_groups_relationships
    owner to postgres;

create table roles_role_groups_relationships
(
    role_id       integer      not null
        references roles,
    role_group_id integer      not null
        references role_groups,
    create_time   timestamp    not null,
    create_user   varchar(255) not null,
    update_time   timestamp,
    update_user   varchar(255),
    primary key (role_id, role_group_id)
);

comment on table roles_role_groups_relationships is '角色與角色群組關係';

alter table roles_role_groups_relationships
    owner to postgres;

create table user_groups_service_units_relationships
(
    user_group_id   integer      not null
        references user_groups,
    service_unit_id integer      not null
        references service_units,
    create_time     timestamp    not null,
    create_user     varchar(255) not null,
    update_time     timestamp,
    update_user     varchar(255),
    primary key (user_group_id, service_unit_id)
);

comment on table user_groups_service_units_relationships is '角色群組與營運關係';

alter table user_groups_service_units_relationships
    owner to postgres;

create table user_user_groups_relationships
(
    user_id       integer      not null
        references users,
    user_group_id integer      not null
        references user_groups,
    create_time   timestamp    not null,
    create_user   varchar(255) not null,
    update_time   timestamp,
    update_user   varchar(255),
    primary key (user_id, user_group_id)
);

comment on table user_user_groups_relationships is '會員與會員組關係';

alter table user_user_groups_relationships
    owner to postgres;


