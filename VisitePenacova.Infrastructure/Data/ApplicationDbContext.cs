using Microsoft.EntityFrameworkCore;
using VisitePenacova.Domain.Entities;

namespace VisitePenacova.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }
        public DbSet<Local> Locais { get; set; }
        public DbSet<ComentNum> ComentNums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Local>().HasData(
                  new Local
                  {
                      Id = 1,
                      Nome = "Vimieiro",
                      Descricao = "Praia fluvial com bandeira azul",
                      Localidade ="Vimieiro",
                      Freguesia ="São Pedro de Alva",
                      Categoria ="Praias fluviais",
                      ImageUrl = "https://placehold.co/600x400",
                  },
                new Local
                {
                    Id = 2,
                    Nome = "Mosteiro de Lorvão",
                    Descricao = "Monumento do século VI D.C",
                    Localidade = "Lorvão",
                    Freguesia = "Lorvão",
                    Categoria = "Monumentos históricos",
                    ImageUrl = "https://placehold.co/600x401",
                },
                new Local
                {
                    Id = 3,
                    Nome = "Poço Grande",
                    Descricao = "Cascata com pequena lagoa",
                    Localidade = "Mata do Maxial",
                    Freguesia = "Figueira de Lorvão",
                    Categoria = "Cascatas",
                    ImageUrl = "https://placehold.co/600x402",
                }

                );

            modelBuilder.Entity<ComentNum>().HasData(
                new ComentNum
                {
                    Coment_Num = 10,
                    LocalId = 1,
                    Comentario = "Praia bastante limpa. Irei voltar certamente!",
                },
                 new ComentNum
                 {
                     Coment_Num = 11,
                     LocalId = 1,
                     Comentario = "Água gelada!",
                 },
                  new ComentNum
                  {
                      Coment_Num = 12,
                      LocalId = 1,
                      Comentario = "Melhor praia flúvial do pais!",
                  },
                   new ComentNum
                   {
                       Coment_Num = 13,
                       LocalId = 1,
                       Comentario = "Praia com bandeira azul.",
                   },
                  new ComentNum
                  {
                      Coment_Num = 21,
                      LocalId = 2,
                      Comentario = "Um pedaço de história",
                  },
                  new ComentNum
                  {
                      Coment_Num = 22,
                      LocalId = 2,
                      Comentario = "Que órgão!",
                  },
                   new ComentNum
                   {
                       Coment_Num = 23,
                       LocalId = 2,
                       Comentario = "Vale a pena a visita!",
                   },
                   new ComentNum
                   {
                       Coment_Num = 30,
                       LocalId = 3,
                       Comentario = "Como é que isto existe?",
                   },
                  new ComentNum
                  {
                      Coment_Num = 31,
                      LocalId = 3,
                      Comentario = "Que dia bem passado! Já só penso em voltar!",
                  }
                );
        }
    }
}
