CREATE DATABASE Aposentadoria 

CREATE TABLE StatusAP (
--COD = ID
 Cod INT PRIMARY KEY IDENTITY,
 Nome VARCHAR(40),
 Aposentado BIT NOT NULL
);

--Ele se comporta como um tipo inteiro, porém com o intervalo de valores
--possíveis restrito a 0 e 1 (e NULL, se não for usada uma restrição NOT
--NULL ao criar o campo). 

--qualquer valor diferente de zero será interpretado como um.

INSERT INTO StatusAP VALUES
('João', 1),
('Marta', 0),
('Renan', 0),
('Fábio', 0),
('Ana', 0),
('Amélia', 1);

--fazemos nossa primeira consulta para saber quais usuários estão aposentados:

SELECT Nome
FROM StatusAP
WHERE Aposentado = 1;

--palavras-chave TRUE e FALSE são interpretados respectivamente como os bits 1 e 0

INSERT INTO StatusAP VALUES
('Renata', 'TRUE'),
('Monica', 'FALSE');

SELECT*FROM StatusAP;