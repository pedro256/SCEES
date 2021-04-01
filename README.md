# SISTEMA DE ESTOQUE ENTRADA E SAIDA DE DADOS
### O que é?
um sistema que propõe a organização do estoque de uma loja qualquer.
### Objetivo?
Implementar a aplicação desde de o núcleo back-end até a interfaces de interação com o usuário.
### Sobre as ferramentas:

 #### **backend**:
 - **C# Asp .net core 5**
 - **MySQL**
 #### frontend:
 - Angular Js

### Requisitos para usar em minha maquina:
* deve ter pelo menos Visual Studio Code ou Visual Studio
* ter o dotnet 5 instalado
* mysql instalado

**! Para usar o banco de dados usei o conceito de Code First e inserir Migrations para facilitar a persistência de dados**
#### para usar as Migrations, entre no nuget console e digite:
#### (não esqueça de iniciar o servidor mysql)

    add-migration UmNomeQualquer
    ...
    Update-database
 
 

> para mais informações de migrations com Entity Framework:
> https://www.entityframeworktutorial.net/efcore/entity-framework-core-migration.aspx

