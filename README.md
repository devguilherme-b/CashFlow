# 📘 Projeto - CashFlow

![Status](https://img.shields.io/badge/status-em%20desenvolvimento-yellow)
![Versão](https://img.shields.io/badge/vers%C3%A3o-1.0-blue)

**Autor**: [Guilherme Barbosa](https://github.com/devguilherme-b)

## Sobre o projeto

Esta **API** foi desenvolvida para o registro de despesas, permitindo que os usuários informem dados como título, data e hora, descrição, valor e forma de pagamento. Todas as informações são armazenadas de forma segura em um banco de dados **MySQL**.

A aplicação utiliza a stack **.NET com C#**, estruturada com base em **Domain-Driven Design (DDD)**, princípios **SOLID** e práticas modernas de validação com **FluentValidation**. Conta com **exceptions customizadas**, com mensagens de erro traduzidas automaticamente para quatro idiomas: Inglês, Francês, Português do Brasil e Português de Portugal. A definição do idioma é feita dinamicamente por meio de **middlewares e filtros de requisição**, com base nas configurações do dispositivo do usuário.

A API também oferece uma documentação interativa via **Swagger**, facilitando a exploração e testes dos endpoints por desenvolvedores.

### Features

- **CRUD completo**: Permitindo a criação, consulta, edição e delete de despesas;
- **Geração de relatórios**: Exporta relatórios detalhados para **PDF e Excel**, oferecendo uma análise visual e eficaz das despesas;

- **RESTful API com Documentação Swagger**: Interface documentada que facilita a integração e o teste por parte dos desenvolvedores.;
- **Domain-Driven Design (DDD)**: Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
- **Testes de Unidade**: Testes abrangentes com FluentAssertions para garantir a funcionalidade e a qualidade.

### Construído com

![badge-dot-net]
![badge-windows]
![badge-visual-studio]
![badge-mysql]
![badge-swagger]
##  Diagrama de dependências

<div align="center">
   <img src="src/CashFlow.Communication/Assets/imgs/Dependency-diagram.png" alt="Diagrama de dependência do projeto" height="200">
</div>

#### Entendendo o diagrama:

Cada seta representa uma **dependência** entre projetos.
Um projeto **independente** é aquele que **não possui dependências externas**, ou seja, **apenas recebe setas** e **não aponta** para outros.


## Créditos

Este software é fruto de um projeto prático presente na **Formação C#** da [Rocketseat](https://www.rocketseat.com.br/). Durante o curso, foram abordados diversos tópicos essenciais para desenvolvedores .NET Backend, e cada conhecimento foi aplicado neste projeto.

Agradecimentos especiais para:

**Rocketseat** – Referência em educação para desenvolvedores.  
**Wellison Arley** – Professor e guia técnico durante o desenvolvimento do projeto.


## 📬 Meios de Contato

- **Email**: [devguilhermebarbos@gmail.com](mailto:devguilhermebarbos@gmail.com)  
- **LinkedIn**: [linkedin.com/in/devguilhermebarbosa](https://linkedin.com/in/devguilhermebarbosa)  
- **GitHub**: [github.com/devguilherme-b](https://github.com/devguilherme-b)

<!-- Badges -->
[badge-dot-net]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-windows]: https://img.shields.io/badge/Windows-0078D4?logo=windows&logoColor=fff&style=for-the-badge
[badge-visual-studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?logo=visualstudio&logoColor=fff&style=for-the-badge
[badge-mysql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=for-the-badge