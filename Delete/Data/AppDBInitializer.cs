using Delete.Models;

namespace Delete.Data
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppCont>();
                context.Database.EnsureCreated();

                //Criar tarefas
                if (!context.Client.Any())
                {
                    context.Client.AddRange(new List<Client>()
                    {
                        new Client()
                        {
                            Name = "Samuel Vieira"
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

    }
}