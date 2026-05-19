# PetShopSistema - Backend 🐾

Este repositório contém a lógica de negócio (**BLL**), acesso a dados (**DAL**), modelos (**Models**) e utilitários (**Utils**) desenvolvidos para o sistema de gestão de um PetShop. O projeto foi estruturado seguindo uma arquitetura profissional em **3 Camadas (Multi-Tier Architecture)**, garantindo desacoplamento, segurança e facilidade de manutenção.

---

## 🏗️ Arquitetura do Projeto

O sistema está dividido em responsabilidades bem definidas, isolando o comportamento de cada componente:

1. **`PetShopSistema.Models`**: Contém as classes de entidades puras (como `Usuario.cs`, `Pet.cs` e `CepModel.cs`), representando as tabelas do banco de dados e as estruturas de dados mapeadas.
2. **`PetShopSistema.Utils`**: Centraliza serviços transversais e auxiliares do sistema:
   * **`Validadores.cs`**: Validações customizadas de dados utilizando Expressões Regulares (**Regex**).
   * **`APIServicos.cs`**: Consumo assíncrono de APIs externas (ViaCEP).
   * **`Seguranca.cs`**: Criptografia de dados sensíveis (senhas).
3. **`PetShopSistema.BLL_Business_Logic_Layer`**: O "cérebro" da aplicação. Camada responsável pelas regras de negócio, consistência e travas de segurança antes que os dados cheguem à base de armazenamento.
4. **`PetShopSystem.DAL`**: Camada de Acesso a Dados (*Data Access Layer*). Responsável estritamente pela comunicação com o SQL Server através de ADO.NET (`SqlConnection`, `SqlCommand`), execução de queries diretas e retorno de estados lógicos (`bool`) para a BLL.

---

## ⚡ Funcionalidades Destacadas

### 1. Máscaras e Validações Inteligentes (Regex)
A classe `Validadores.cs` utiliza expressões regulares avançadas para impedir a entrada de dados inconsistentes ou malformados:
* **E-mail**: Filtro sob o padrão `^[^@\s]+@[^@\s]+\.[^@\s]+$`, exigindo estrutura corporativa/padrão com arroba e domínio válidos.
* **Telefone**: Modelo adaptável `^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$` que suporta e valida números fixos e celulares com ou sem DDD mascarado.
* **CEP**: Expressão `^\d{5}-?\d{3}$` para checagem exata dos 8 dígitos obrigatórios da estrutura postal brasileira.

### 2. Integração com a API ViaCEP
Para enriquecer a experiência do utilizador final, foi implementado o consumo assíncrono da API do **ViaCEP** através do `HttpClient`:
* Quando um CEP válido é inserido, o sistema executa uma chamada em segundo plano (`async/await`) evitando o congelamento da interface gráfica.
* O JSON de resposta é deserializado via biblioteca `Newtonsoft.Json` direto para o modelo `CepModel.cs`, preenchendo automaticamente os campos de *Rua (Logradouro)*, *Bairro*, *Cidade (Localidade)* e *Estado (UF)*.

### 3. Blindagem de Segurança (SHA-256)
Nenhuma senha é armazenada em texto limpo. A `BLL` intercepta a senha do utilizador e aplica um algoritmo de hash seguro utilizando `SHA-256` antes de disparar o comando de persistência para a `DAL`.

---

## ⚙️ Tecnologias e Dependências Utilizadas

* **Linguagem**: C# (.NET Framework / .NET Core)
* **Banco de Dados**: SQL Server (ADO.NET / `System.Data.SqlClient`)
* **Processamento de JSON**: `Newtonsoft.Json` (Gerido via NuGet Package Manager)
* **Controle de Versão**: Git & GitHub

---

## 🛡️ Configuração do Escudo `.gitignore`

O repositório foi protegido utilizando regras estritas de descarte no `.gitignore` para evitar o upload de arquivos binários pesados ou dependências locais recriáveis:
* Exclusão completa das pastas de compilação local: `bin/` e `obj/`.
* Exclusão da pasta de pacotes baixados do NuGet: `packages/`.
* Exclusão de metadados temporários gerados pelo Windows/Visual Studio (ex: `.suo`, `IndexerVolumeGuid`, `WPSettings.dat`).

---

## 🚀 Como Executar ou Restaurar o Projeto

1. Clone o repositório para a sua máquina local:
   ```bash
   git clone [https://github.com/ZayonBR/PetShopSistema.git](https://github.com/ZayonBR/PetShopSistema.git)
