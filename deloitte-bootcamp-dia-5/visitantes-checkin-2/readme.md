# Sistema de Controle de Visitantes

Este projeto consiste em uma aplicação de console desenvolvida em C# para gerenciar o fluxo de entrada e saída de visitantes em um ambiente corporativo ou de coworking. O sistema foi desenvolvido como parte das atividades práticas do Bootcamp da Deloitte em C#.

## Visão Geral

A aplicação permite o cadastro rápido de visitantes, controle de horários (check-in e check-out) e identificação de novos usuários. O foco principal foi a implementação de lógica de negócios utilizando Programação Orientada a Objetos e manipulação de listas em memória.

## Funcionalidades

O sistema oferece um menu interativo com as seguintes opções:

* **Cadastrar Visitante:** Registra ID automáticamente, nome, documento e se é a primeira visita. Inclui validação para impedir campos vazios e registra automaticamente o horário de chegada.
* **Listar Visitantes:** Exibe todos os registros ordenados por ID, mostrando o status atual (se a pessoa ainda está no local ou o horário que saiu).
* **Buscar por Nome:** Localiza visitantes específicos independentemente de letras maiúsculas ou minúsculas.
* **Registrar Saída:** Atualiza o registro do visitante inserindo o horário de saída, impedindo duplicidade de registros de saída.
* **Relatório de Primeira Visita:** Filtra e exibe apenas os visitantes que estão acessando o local pela primeira vez.

## Tecnologias e Conceitos Aplicados

* **Linguagem:** C# (.NET)
* **Paradigma:** Orientação a Objetos
* **Estruturas de Dados:** List<T> para armazenamento em memória
* **Tratamento de Exceções:** Blocos Try/Catch para garantir que entradas inválidas não quebrem a execução

## Como Executar

1.  Certifique-se de ter o .NET SDK instalado.
2.  Clone este repositório ou baixe os arquivos.
3.  Navegue até a pasta do projeto via terminal.
4.  Execute o comando:
    dotnet run

## Sobre o Autor

**Guilherme**
Desenvolvedor de software.
