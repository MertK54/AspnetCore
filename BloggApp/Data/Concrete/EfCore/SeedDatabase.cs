using BloggApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BloggApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {//bir hizmet kapsamı (service scope) oluşturur. Hizmet kapsamları, bağımlılıkları belirli bir yaşam döngüsü içinde yönetmek için kullanılır. AsyncScope, asenkron işlemler için kullanışlıdır.
            var context = app.ApplicationServices.CreateAsyncScope().ServiceProvider.GetService<BlogContext>();
            //oluşturulan kapsam (scope) içinden BlogContext hizmetini alır
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "altay", Image = "p1.jpg", Name = "Altay Turan", Email = "altayturan@gmail.com", Password = "5454" },
                        new User { UserName = "baykutay", Image = "p2.jpg", Name = "Baykutay Turan", Email = "baykutayturan@gmail.com", Password = "5454" }
                    );
                    context.SaveChanges();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "web programlama", Url = "web-programlama", Color = TagColors.warning },
                        new Tag { Text = "backend", Url = "backend", Color = TagColors.warning },
                        new Tag { Text = "frontend", Url = "frontend", Color = TagColors.success },
                        new Tag { Text = "php", Url = "php", Color = TagColors.primary },
                        new Tag { Text = "fullstack", Url = "fullstack", Color = TagColors.secondary }
                    );
                    context.SaveChanges();
                }
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post
                        {
                            Title = "Asp.net Core",
                            Content = "Asp.net core dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Url = "aspnet-core",
                            Image = "1.jpeg",
                            UserId = 1,
                            Comments = new List<Comment> {
                                new Comment {Text = "iyi bir kurs", PublishedOn = new DateTime(), UserId = 1},
                                new Comment {Text = "öğretici ama mikrofonda sorun var", PublishedOn = new DateTime(), UserId = 2}
                                 }
                        },
                        new Post
                        {
                            Title = "Php",
                            Content = "Php dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.jpeg",
                            Url = "php",
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "Django",
                            Content = "Django dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-19),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "3.jpeg",
                            Url = "django",
                            UserId = 2
                        },
                        new Post
                        {
                            Title = "Node.js",
                            Content = "Node.js dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-16),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "2.jpeg",
                            Url = "nodejs",
                            UserId = 2
                        },
                        new Post
                        {
                            Title = "React",
                            Content = "React dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpeg",
                            Url = "react",
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "Docker",
                            Content = "Docker dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-12),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "2.jpeg",
                            Url = "docker",
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}