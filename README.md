# ApiDDD.Net
Api com Identity,JWT, AutoMapper, DDD, TDD Token. Curso Dev Net Core - Valdir Ferreira Youtube

** Utilizei o Banco de dados Postgres
___________________________________________________________________
### Resumo das aulas:

Aula 1 (somente introdução)

Aula 2 

Criação das pastas e dos projetos.
(1-Api, 2- Domain, 3- Infra, 4- Entities, 5- teste)

Entidades e Enums

* No projeto entities instalar pacote:
Microsogt.Extensions.Identity.Stores

Aula 3

Domain/ interfaces/Generics e interfaceServices

Services

Infra:
Configuration / contextBase - no contextBase passar pelo DbSet as tabelas que eu quero criar pelo entityFramework.

* No projeto infra instalar pacote:
Microsoft.AspNetCore.Identity.EntityFrameworkCore

Instalar pacote do banco de dados (instalei do postgres)

      Método para mapear a chave primária da tabela do identity.
              protected override void OnModelCreating(ModelBuilder builder)
              {
                  builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
                  base.OnModelCreating(builder);
              }
___________________________________________________________________
## Anotações para banco de dados:

modelo para conexão Postgres --> optionsBuilder.UseNpgsql(ObterStringConexao());

[NotMapped] -- colcar em cima da propriedade para não ser mapeado no migration.

[Table("TB_MESSAGE")] -- colocar em cima da classe par criar a tabela pelo migration.

[Column("MSN_ID")] --colocar em cima da propriedade para criar a coluna.

    Modelo para ForeignKey:
    [ForeignKey("ApplicationUser")]
    [Column(Order = 1)]
    public string UserId { get; set; }

     public virtual ApplicationUser ApplicationUser { get; set; }
___________________________________________________________________
Curso Dev Net Core - Valdir Ferreira Youtube
https://www.youtube.com/watch?v=eBqV9Vc8zoo&list=PLP8qOphXwRnIOzXzoviI5xwxcc4-dV_pd&index=3
