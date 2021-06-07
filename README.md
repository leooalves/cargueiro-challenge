# Code Challenge - Q1

## Contexto

O ano é 2654, a Terra se tornou o principal pólo comercial de recursos para as novas colônias fora do Sistema Solar.

Após a descoberta da tecnologia que possibilitou longas viagens interestelares em tempo recorde (100 AL/H - cem anos-luz por hora), no século 23, o estabelecimento de novos entrepostos humanos em locais antes considerados inalcançáveis se tornou possível. 

O exemplo mais proeminente do sucesso da expansão humana pela Via Láctea é a base avançada de mineração no Sistema Kepler-186. Especificamente localizada no exoplaneta Kepler-186f, a 500 anos-luz do planeta Terra.

## Demanda


A Federação Unida das Colônias da Terra (FUCT), com sede na América Latina, precisa saber, em períodos mensais, a quantidade e o custo dos materiais recebidos da base avançada de mineração em Kepler-186f.

O Sindicato dos Mineiros de Kepler (SMK186) utiliza uma REST API, hospedada nos servidores galácticos da FUCT, para informar, semana a semana, a quantidade de minérios que estarão disponíveis para transporte (ver nas informações adicionais do desafio o endpoint utilizado pelo SMK186).

Para essa missão, a FUCT disponibilizará 30 cargueiros, conforme a tabela T1 abaixo:

| Quantidade | Classe | Capacidade (em toneladas) | Tipo de mineral compatível<br>(consultar tabela T2) |
|---|---|---|---|
| 15     | I      | 5                         | D                                                             |
| 10         | II     | 3                         | A                                                             |
| 3          | III    | 2                         | C                                                             |
| 2          | IV     | 0,5                       | B ou C                                                        |


*Tabela T1: Cargueiros disponíveis.*


| Mineral | Característica                | Preço ($)              |
|---|---|---|
| A       | Inflamável 🔥                  | $ 5.000,00 / 10^3 kg   |
| B       | Risco Biológico ☣             | $ 10.000,00 / 10^-3 kg |
| C       | Refrigerado 🧊                 | $ 3.000,00 / 10^-1 kg  |
| D       | Sem características especiais | $ 100,00 / 10^2 kg     |


*Tabela T2: Minérios e suas características*


Para atender essa necessidade a gerência deseja registrar as saídas e os retornos dos cargueiros, em formulário eletrônico, que deve solicitar:
1. O tipo do cargueiro;
2. A data e hora da saída e retorno, e;
3. Se retorno, registrar a quantidade e o tipo dos minerais obtidos.
<br/><br/>

A visualização das cargas recebidas (retornos) deverá ser por meio de uma tabela (*grid*) paginada, que deverá mostrar no máximo 10 itens por página, devendo ser filtrável por mês/ano, indicando:
1. O tipo de minério obtido;
2. Data e hora do recebimento da carga;
3. Valor total da carga.

Deverão ser exibidos, abaixo dessa tabela, mais 2 conjuntos de informações: **o total gasto** com **cada tipo de minério**, além do **índice de ociosidade dos cargueiros**, por classe, pelo período filtrado pelo usuário.

## Observações

Seguindo as regras do Codex Interestelar do Comércio, sancionado no ano de 2520, nenhum cargueiro poderá registrar saída antes das 08:00 AM (GMT), não havendo regulamentação para os horários de retorno. Importante observar que qualquer movimentação comercial interestelar é proibida aos domingos.
<br/><br/>
Todos os cargueiros, **especialmente os de classe IV**, possuem ordens para **sempre** priorizar a capacidade de carga para os minérios de valor mais alto.
<br/><br/>

## O que é esperado do desafio?

Gostaríamos de ver uma solução *backend* desenvolvida em ASP.NET Core com [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0).

O *frontend* pode ser elaborado com [Vue.js](https://vuejs.org/) ou [Angular](https://angular.io/), priorizando sempre as versões mais recentes e que faça uso do [TypeScript](https://www.typescriptlang.org/).

Ao iniciar a aplicação, ela deverá gerar uma carga de dados automática e em tempo de execução das saídas e retornos dos transportes para o período de, no mínimo, um ano, respeitando as regras supramencionadas.

### Bônus
- Mecanismo de login com padrão OAuth.
- Utilização do padrão CQRS.
- Publicação da solução do desafio na internet.
- Testes unitários.
- DDD / Clean Architecture.

## Informações Adicionais

O desafio pode ter deixado algumas informações implícitas ou omitido alguns detalhes.

A especificação Open API para obter as informações dos minérios disponíveis por semana/mês/ano pode ser acessada em [https://fuct-smk186-code-challenge.cblx.com.br/swagger/](https://fuct-smk186-code-challenge.cblx.com.br/swagger/). O endereço para as requisições é o mesmo, mas sem o caminho `/swagger`.

