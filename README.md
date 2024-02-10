# API e MVC 

Desenvolvi para a GTI Solutions uma API escalável e segura em resposta ao desafio proposto. Todos os seus retornos para comunicação com outros sistemas são padronizados. Além disso, utilizei o Entity Framework para o mapeamento e criação do banco de dados.

O projeto foi dividido em camadas, como Application, Domain, Infra e Shared. Adotei diversos padrões de projetos, como o padrão Repository, Unit of Work e Command. Para possibilitar uma escalabilidade ainda melhor, também adicionei validações utilizando a biblioteca Flunt, o que nos permitiu padronizar até mesmo os detalhes de erro nas requisições.

O projeto MVC foi desenvolvido como uma interface de usuário para interagir com a API. Ele se concentra em operações CRUD (Create, Read, Update, Delete) para clientes e seus endereços associados. Dada a estrutura em que um endereço está intimamente ligado a um cliente, foi implementado um CRUD combinado para simplificar a gestão.

## Demonstração 

Tela de cadastro de um cliente
![image](https://github.com/ezequiel-lima/GTI-API-e-MVC/assets/81567476/a4be56e3-b7f2-4c34-bbb7-5c84a936ebea)

Endpoints
![image](https://github.com/ezequiel-lima/GTI-Api/assets/81567476/88df38b6-0c11-4bbd-a6c2-ebbfe0a6ca1d)

Retorno padronizado
![image](https://github.com/ezequiel-lima/GTI-Api/assets/81567476/dc14fb65-7623-4499-90a3-a8fdbadfa823)

