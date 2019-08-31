create database estoque;
use estoque;
create table usuario(login varchar(45),
					senha varchar(45),
                    nome varchar(100),
                    telefone varchar(9),
                    email varchar(45),
                    cargo enum('Almoxerifado', 'Gerente'),
                    primary key(login));
create table funcionario(idFuncionario bigint unsigned,
						nome varchar(100),
                        cargo varchar(45),
                        primary key(idFuncionario));
create table projeto(idProjeto bigint unsigned,
					nome varchar(100),
                    prazoEstimado datetime,
                    dataInicio datetime,
                    estado enum('Andamento', 'Finalizado'),
                    primary key(idProjeto));
create table participa(projetoCod bigint unsigned,
						funcionarioCod bigint unsigned,
                        foreign key(projetoCod) references projeto(idProjeto),
                        foreign key(funcionarioCod) references funcionario(idFuncionario));
create table material(idMaterial bigint unsigned,
						nome varchar(100),
                        preco double, 
                        unidade varchar(45),
                        primary key(idMaterial));
create table alocacao_possui(quantidade bigint unsigned,
							materialCod bigint unsigned,
                            projetoCod bigint unsigned,
                            foreign key(materialCod) references material(idMaterial),
                            foreign key(projetoCod) references projeto(idProjeto));
create table projeto_finalizado(dataFim datetime,
								codProjeto bigint unsigned,
                                primary key(codProjeto), 
                                foreign key(codProjeto) references projeto(idProjeto));
