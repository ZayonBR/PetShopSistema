-- 1. Criação do Banco de Dados
CREATE DATABASE PetshopDB;
GO

USE PetshopDB;
GO

-- 2. Tabela Usuario (Antiga tabela Cliente, renomeada para englobar os Admins também)
CREATE TABLE Usuario (
    cd_usuario INT IDENTITY(1,1) PRIMARY KEY,
    nm_usuario VARCHAR(100) NOT NULL,
    ds_email VARCHAR(100) UNIQUE NOT NULL,
    ds_senha VARCHAR(256) NOT NULL, -- Espaço suficiente para a senha criptografada
    cd_telefone VARCHAR(20) NOT NULL,
    
    -- Endereço (Preparado para a API ViaCEP)
    cd_CEP VARCHAR(10) NOT NULL,
    nm_rua VARCHAR(150) NOT NULL,   -- Adicionado conforme a regra do projeto
    nm_bairro VARCHAR(100) NOT NULL,
    nm_cidade VARCHAR(100) NOT NULL,
    sg_estado CHAR(2) NOT NULL,
    
    -- Controle de Acesso
    cd_tipoUsuario VARCHAR(20) NOT NULL DEFAULT 'Cliente' -- Ex: 'Cliente' ou 'Admin'
);
GO

-- 3. Tabela Pet
CREATE TABLE Pet (
    cd_pet INT IDENTITY(1,1) PRIMARY KEY,
    nm_pet VARCHAR(100) NOT NULL,
    ds_especie VARCHAR(50) NOT NULL,
    ds_raca VARCHAR(50),
    qt_idade INT,
    
    -- Chave Estrangeira: Relacionamento com o dono (Usuario)
    cd_usuario INT NOT NULL, 
    CONSTRAINT FK_Pet_Usuario FOREIGN KEY (cd_usuario) REFERENCES Usuario(cd_usuario)
);
GO

-- 4. Tabela Servico
CREATE TABLE Servico (
    cd_servico INT IDENTITY(1,1) PRIMARY KEY,
    nm_servico VARCHAR(100) NOT NULL,
    vl_preco DECIMAL(10,2) NOT NULL
);
GO

-- 5. Tabela Agendamento
CREATE TABLE Agendamento (
    cd_agendamento INT IDENTITY(1,1) PRIMARY KEY,
    
    -- Data e Hora unificadas em um único campo para facilitar a integração com o C#
    dt_agendamento DATETIME NOT NULL, 
    cd_statusAgendamento VARCHAR(20) DEFAULT 'Pendente',
    
    -- Chaves Estrangeiras
    cd_pet INT NOT NULL,
    cd_servico INT NOT NULL, -- Adicionado para registrar qual serviço foi escolhido
    
    -- Relacionamentos
    CONSTRAINT FK_Agendamento_Pet FOREIGN KEY (cd_pet) REFERENCES Pet(cd_pet),
    CONSTRAINT FK_Agendamento_Servico FOREIGN KEY (cd_servico) REFERENCES Servico(cd_servico)
    
    -- Nota: O cd_cliente foi removido daqui pois o banco já sabe quem é o dono acessando a tabela Pet
);
GO

-- Inserindo Serviços
INSERT INTO Servico (nm_servico, vl_preco) VALUES 
('Banho e Tosa - Porte Pequeno', 60.00),
('Consulta Veterinária', 150.00);

-- Inserindo um Usuário (Cliente) de teste
INSERT INTO Usuario (nm_usuario, ds_email, ds_senha, cd_telefone, cd_CEP, nm_rua, nm_bairro, nm_cidade, sg_estado, cd_tipoUsuario)
VALUES ('João Silva', 'joao@email.com', 'senha_hasheada_aqui', '11999999999', '11740000', 'Rua Exemplo', 'Centro', 'Itanhaém', 'SP', 'Cliente');

-- Inserindo um Pet para esse Cliente (Considerando que o ID do João foi 1)
INSERT INTO Pet (nm_pet, ds_especie, ds_raca, qt_idade, cd_usuario)
VALUES ('Rex', 'Cachorro', 'Poodle', 3, 1);

-- Criando um Agendamento
INSERT INTO Agendamento (dt_agendamento, cd_pet, cd_servico)
VALUES ('2026-05-25 14:30:00', 1, 1);


SELECT 
    A.cd_agendamento AS 'Nº Agendamento',
    A.dt_agendamento AS 'Data e Hora',
    U.nm_usuario AS 'Cliente',
    P.nm_pet AS 'Pet',
    P.ds_especie AS 'Espécie',
    S.nm_servico AS 'Serviço',
    S.vl_preco AS 'Valor (R$)',
    A.cd_statusAgendamento AS 'Status'
FROM 
    Agendamento A
INNER JOIN Pet P ON A.cd_pet = P.cd_pet
INNER JOIN Usuario U ON P.cd_usuario = U.cd_usuario
INNER JOIN Servico S ON A.cd_servico = S.cd_servico
ORDER BY 
    A.dt_agendamento ASC;