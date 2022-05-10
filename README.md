# BrasilCashAPI
Este é um projeto solicitado pela empresa BrasilCash! 


## Apresentação: 
Olá! Me chamo Robson Monteiro, e sou estagiário em desenvolvimento de sistemas! Atualmente estagiando ná empresa AjinSoft em Barueri.
Tenho bons conhecimentos em front-end como:

### Html, Css, JavaScript, Typescript e Angular. 

E também, tenho conhecimentos em back-end, como:

### C# e Java.

## Sobre a API:

Está é uma API de cadastro simples. Cadastro este com uma relação entre duas entidades, principal (Cliente) e dependente (Endereço), com relação de um para um entre si.

Foram implementados alguns metodos além dos solicitados, para complementar melhor os requisitos. 

Por padrão, os projetos em C# trazem consigo o swagger, que facilita muito o uso e compreensão da API, seus caminhos e relações entre entidades. Para acessar o swagger, basta 
entrar neste link logo após de executar a API no C#:

https://localhost:5001/swagger/index.html

imagem de exemplo:

![exemploAPI](https://user-images.githubusercontent.com/88908479/167623593-b7a01bcb-7bc9-4bb1-aed4-f2b6294b596b.jpg)


## Observações:

Estou um pouco enferrujado, devido a estar trabalhando com muita frequência com front-end. Então, de já peço a compreensão dos mesmos se acaso algo não estiver no padrão,
ou a gosto. Fiz está api com empenho, e com pouco tempo disponivel devido demanda.

De já, agradeço pela oportunidade de participar do desafio! Uma boa semana á todos.


## Partilhando conhecimentos e dificuldades no desafio:

Tive dificuldade de inicio, em configurar o LocalDB, pois nunca havia utilizado.

Tive problemas antes de usar o AddNewtonsoftJson, pois sempre me deparava com um erro ao tratar o dado que vinha da api viacep. Porem, lendo algumas documentações
e soluções, consegui chegar em um resultado.

Tive problemas com a relação entre entidades. Ao fazer um post, sempre conseguia enviar as duas entidades juntas. Más ná hora de consumi-las, Elas não tinham relação.
Então, criei um modulo a parte para ADDRESS, junto com um contexto, para montar a entidade nos metodos get. (Tive está dificuldade mesmo criando uma relação com chave primaria
e estrangeira). 

## Conhecimentos novos adquiridos com o desafio:

Fluent Validation, AddNewtonsoftJson, LocalDB.











