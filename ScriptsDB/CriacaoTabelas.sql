CREATE TABLE Categorias(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(100),
	Descricao VARCHAR(1024),
	UrlImagem VARCHAR(100)	
);

CREATE TABLE Produtos(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(100),
	Descricao VARCHAR(1024),
	UrlImagem VARCHAR(100),
	PrecoUnitario DECIMAL,
	IdCategoria int,
	FOREIGN KEY(IdCategoria) REFERENCES Categorias(Id)
);
