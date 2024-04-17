# Clínica Médica - Sistema de Gerenciamento

O **Clínica Médica** é um projeto Fullstack desenvolvido para oferecer um sistema completo de gerenciamento para clínicas médicas. Com uma gama de funcionalidades, desde o cadastro de pacientes até o agendamento de consultas, o sistema visa facilitar o dia a dia dos profissionais da saúde.

Assista ao vídeo abaixo para ver a aplicação em execução.

[![Texto alternativo](https://img.youtube.com/vi/T-OAnHipSos/0.jpg)](https://www.youtube.com/watch?v=T-OAnHipSos)

## Funcionalidades Implementadas

- **FrontEnd Responsivo:** Desenvolvido utilizando HTML, CSS, JavaScript, WebPages Razor e Bootstrap.
- **CRUD de Pacientes:** Permite o cadastro, edição, visualização e exclusão de informações dos pacientes.
- **CRUD de Médicos:** Gerencia o cadastro e as informações dos médicos da clínica.
- **CRUD de Atendimentos:** Registra as consultas e procedimentos realizados na clínica.
- **CRUD de Serviços:** Permite o cadastro e gerenciamento dos serviços oferecidos pela clínica.
- **Confirmação de Agendamento:** Sistema de notificação via E-mail e integração com o Google Agenda para confirmação de agendamentos.
- **Background Service:** Notificação automática aos pacientes no dia anterior à consulta.

## Tecnologias Utilizadas

- **ASP.NET Core 7:** Framework web para desenvolvimento de aplicações .NET.
- **Entity Framework Core:** Biblioteca para persistência e consulta de dados.
- **SQL Server:** Banco de dados relacional para armazenamento de informações.

## Padrões, Conceitos e Arquitetura Utilizados

- **Arquitetura MVC:** Organização do projeto seguindo o padrão Model-View-Controller.
- **Fluent Validation:** Utilizado para validação de dados de entrada.
- **Padrão Repository:** Implementação para acesso aos dados de forma isolada.
- **Middleware:** Para tratamento de exceções e erros.
- **InputModel e ViewModel:** Para manipulação dos dados de entrada e exibição.
- **DTO’s:** Transferência de dados entre camadas da aplicação.
- **IEntityTipeConfiguration:** Configuração de entidades no banco de dados.
- **Unit Of Work:** Gerenciamento de transações.
- **HostedService:** Para execução de serviços em segundo plano.
- **Domain Event:** Comunicação entre domínios.
- **Arquitetura Limpa:** Organização e estruturação do projeto de acordo com boas práticas.



---

Com o **Clínica Médica**, a gestão de uma clínica médica se torna mais eficiente e organizada. Desde o cadastro inicial até o acompanhamento dos pacientes, o sistema oferece uma solução completa para profissionais da saúde.
