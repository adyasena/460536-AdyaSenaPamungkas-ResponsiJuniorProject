create database dbadyaresponsi;

create sequence seq_karyawan
	start 1
	increment 1;

create table karyawan (
	id_karyawan integer primary key default nextval('seq_karyawan'),
	nama character varying(30),
	id_dep character(6)
);

create table departemen (
	id_dep character(6) primary key,
	nama_dep character varying(30)
);

create function tambah_karyawan
(
	_nama character varying,
	_id_dep character
)
returns int AS
'
BEGIN
	insert into karyawan
	(
		nama,
		id_dep
	)
	values
	(
		_nama,
		_id_dep
	);
	if found then
		return 1;
	else
		return 0;
	end if;
end;
'
language plpgsql;

create function lihat_karyawan()
returns table
(
	_id_karyawan integer,
	_nama character varying,
	_id_dep character
)
language plpgsql
as
'
BEGIN
	return query
	select id_karyawan, nama, id_dep from karyawan;
	
end;
';

create function ubah_karyawan
(
	_id_karyawan integer,
	_nama character varying,
	_id_dep character
)
returns int AS
'
BEGIN
	update karyawan set
		nama = _nama,
		id_dep = _id_dep
	where id_karyawan = _id_karyawan;
	if found then
		return 1;
	else
		return 0;
	end if;
end
'
language plpgsql;

create function hapus_karyawan(_id_karyawan integer)
returns int AS
'
BEGIN
	delete from karyawan
	where id_karyawan = _id_karyawan;
	if found then
		return 1;
	else
		return 0;
	end if;
end
'
language plpgsql;