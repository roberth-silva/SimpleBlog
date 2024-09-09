# Teste prático para a vaga de desenvolvedor .Net

# Candidato: Roberth Silva

## Resumo da aplicação:

- O sistema foi desenvolvido usando o framework .net8, com o padrão arquitetural MVC e o componente Entity Framework como principal ferramenta para persistência de dados.
- Por questões de simplicidade e facilidade para o momento da execução/validação, o banco de dados escolhido foi o SQLite (base de dados já incluída no projeto).
- Para as notificações ao usuário, foi utilizado o SignalR como o componente de websocket. As notificações só acontecem logo após a crição de novos posts.
- Para autenticação e autorização do usuário foi utilizado a biblioteca Identity do .Net.
- Princípios SOLID (SRP e DIP) foram utilizandos dentro da arquitetura da solução, com o objetivo de melhorar a organização e entendimento do código.

## Funcionamento da aplicação:

- O sistema consite em um cadastro simples de Posts (conteúdos compostos por título e mensagem). O usuário apenas precisa entrar com a informação do título e conteúdo do post, no entanto informações como Id do post, id do usuário e data de criação também são registrados na base de dados.
- É possível que usuários não cadastrados visualizem a listagem de posts, mas ações como criação, edição e exclusão de posts só podem ser efetuadas por usuários cadastrados e devidamente logados no sistema.
- Assim como os posts, a base de dados também armazena informações do usuário, dessa forma é possível cadastrar novos usuários (funcionanlidade obrigatória para o gerencimento dos posts).
- Usuários só poderão excluir os seus próprios posts. Posts criados por outros usuários só podem ser visualizados.
- As notificações são ativadas após o sucesso da criação do post, e somente nesse momento. O SignalR é acionado e este dispara uma notificação de 3 segundos, com a informação do título do novo post.
- Ainda sobre notificações, existe um badged no canto superior direito da tela exibindo o número de novos posts criados (não número total de posts), que volta a 0 após usuário mudar de tela.

## Instruções para execução:

O sistema precisa da base de dados local (BlogDb.db, que já está inclusa no projeto) para correta execução. Caso o arquivo não exista no projeto será necessário gerar novamente a base de dados, segue as instruções:
- No Visual Studio, abrir a janela Package Manager Console
- A partir do projeto `SimpleBlog.Infraestruture`:
	- Executar o comando `add-migration initdb` para criação das migrations
	- Executar o comando `update-database` para criação do arquivo do banco de dados
	
Para outras dúvidas, estou à disposição.

>roberth410@gmail.com

>(98) 98852-9825
