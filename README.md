Orientações para Instalação

Primeiramente criar as tabelas no SqlServer, com os scripts abaixo:

CREATE TABLE SELLIN.dbo.Clients (
	Id varchar(100) COLLATE Latin1_General_CI_AS NOT NULL,
	Name varchar(100) COLLATE Latin1_General_CI_AS NOT NULL,
	Email varchar(100) COLLATE Latin1_General_CI_AS NULL,
	Logo varchar(100) COLLATE Latin1_General_CI_AS NULL,
	CONSTRAINT Clients_PK PRIMARY KEY (Id)
);
 CREATE  UNIQUE NONCLUSTERED INDEX Client_Email_IDX ON dbo.Clients (  Email ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;
 CREATE  UNIQUE NONCLUSTERED INDEX Client_Id_IDX ON dbo.Clients (  Id ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ] ;



CREATE TABLE SELLIN.dbo.PublicPlace (
	Id varchar(100) COLLATE Latin1_General_CI_AS NOT NULL,
	IdClient varchar(100) COLLATE Latin1_General_CI_AS NULL,
	Name varchar(100) COLLATE Latin1_General_CI_AS NULL,
	CONSTRAINT PublicPlace_PK PRIMARY KEY (Id),
	CONSTRAINT PublicPlace_FK FOREIGN KEY (IdClient) REFERENCES SELLIN.dbo.Clients(Id) ON DELETE CASCADE ON UPDATE CASCADE
);



Configurar no arquivo CadastroClientesT\Domain\Contexts\AppDbContext.cs as credencias do banco dados


Arquitetura

Arquitetura em Camadas para o Backend:

1. Camada de Aplicação: Esta camada representa o núcleo do projeto, abrigando os controladores e serviços da API. Aqui, todas as requisições são recebidas e encaminhadas para os serviços apropriados, que executam ações específicas.

2. Camada de Domínio: Nesta camada, são implementadas as classes/modelos que são mapeadas para o banco de dados. Além disso, são definidas interfaces, constantes, DTOs (Data Transfer Objects) e enums.

3. Camada de Serviço: Considerada o "coração" do projeto, é nesta camada que todas as regras de negócio e validações são aplicadas antes da persistência dos dados no banco.

4. Camada de Infraestrutura: Esta camada é subdividida em duas partes:
   - Data: Responsável pela persistência dos dados no banco, utilizando ou não algum ORM (Object-Relational Mapping).
   - Cross-Cutting:** Uma camada independente da hierarquia convencional. Como o próprio nome sugere, esta camada transcende as demais e abriga funcionalidades que podem ser utilizadas em qualquer parte do código, como validação de CPF/CNPJ, consumo de APIs externas e implementação de medidas de segurança.
