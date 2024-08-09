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
                        new User { UserName = "altay", Image = "p1.jpg", Name = "Altay Turan", Email = "altayturan@gmail.com", Password = "545454", VerificationCode = "872402",IsVerified= true },
                        new User { UserName = "baykutay", Image = "p2.jpg", Name = "Baykutay Turan", Email = "baykutayturan@gmail.com", Password = "545454" }
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
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Aspernatur debitis illo, mollitia nihil labore consequatur, dolorem eum maxime architecto accusantium ipsum voluptatem saepe ea praesentium iure? Soluta nesciunt aut dolorum. Accusamus architecto voluptatum quis quae praesentium nisi, deleniti asperiores dolores suscipit corrupti dicta, blanditiis quas earum autem delectus sit sed perferendis inventore quidem optio maxime? Magnam, doloribus accusamus! Sequi, autem?Assumenda placeat aliquam dolore ratione qui maiores adipisci fugiat fuga, in eveniet, reiciendis incidunt dicta ex. Consequuntur atque officiis similique eius quas architecto eos quis vero, minus molestiae nulla cum! Odit asperiores ullam veniam sapiente necessitatibus accusamus quisquam explicabo pariatur iusto saepe inventore aspernatur sequi harum veritatis magnam optio eos neque, qui cumque. Unde atque cumque soluta, corrupti quod quam? Nemo vel impedit, quibusdam distinctio id voluptatem atque suscipit aut quidem itaque quisquam repellat. In incidunt tempore, esse cum quisquam rem doloribus, fugiat illum laudantium delectus deserunt id, sunt sint!",
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
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Aspernatur debitis illo, mollitia nihil labore consequatur, dolorem eum maxime architecto accusantium ipsum voluptatem saepe ea praesentium iure? Soluta nesciunt aut dolorum. Accusamus architecto voluptatum quis quae praesentium nisi, deleniti asperiores dolores suscipit corrupti dicta, blanditiis quas earum autem delectus sit sed perferendis inventore quidem optio maxime? Magnam, doloribus accusamus! Sequi, autem?Assumenda placeat aliquam dolore ratione qui maiores adipisci fugiat fuga, in eveniet, reiciendis incidunt dicta ex. Consequuntur atque officiis similique eius quas architecto eos quis vero, minus molestiae nulla cum! Odit asperiores ullam veniam sapiente necessitatibus accusamus quisquam explicabo pariatur iusto saepe inventore aspernatur sequi harum veritatis magnam optio eos neque, qui cumque. Unde atque cumque soluta, corrupti quod quam? Nemo vel impedit, quibusdam distinctio id voluptatem atque suscipit aut quidem itaque quisquam repellat. In incidunt tempore, esse cum quisquam rem doloribus, fugiat illum laudantium delectus deserunt id, sunt sint!",
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
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Aspernatur debitis illo, mollitia nihil labore consequatur, dolorem eum maxime architecto accusantium ipsum voluptatem saepe ea praesentium iure? Soluta nesciunt aut dolorum. Accusamus architecto voluptatum quis quae praesentium nisi, deleniti asperiores dolores suscipit corrupti dicta, blanditiis quas earum autem delectus sit sed perferendis inventore quidem optio maxime? Magnam, doloribus accusamus! Sequi, autem?Assumenda placeat aliquam dolore ratione qui maiores adipisci fugiat fuga, in eveniet, reiciendis incidunt dicta ex. Consequuntur atque officiis similique eius quas architecto eos quis vero, minus molestiae nulla cum! Odit asperiores ullam veniam sapiente necessitatibus accusamus quisquam explicabo pariatur iusto saepe inventore aspernatur sequi harum veritatis magnam optio eos neque, qui cumque. Unde atque cumque soluta, corrupti quod quam? Nemo vel impedit, quibusdam distinctio id voluptatem atque suscipit aut quidem itaque quisquam repellat. In incidunt tempore, esse cum quisquam rem doloribus, fugiat illum laudantium delectus deserunt id, sunt sint!",
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
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Aspernatur debitis illo, mollitia nihil labore consequatur, dolorem eum maxime architecto accusantium ipsum voluptatem saepe ea praesentium iure? Soluta nesciunt aut dolorum. Accusamus architecto voluptatum quis quae praesentium nisi, deleniti asperiores dolores suscipit corrupti dicta, blanditiis quas earum autem delectus sit sed perferendis inventore quidem optio maxime? Magnam, doloribus accusamus! Sequi, autem?Assumenda placeat aliquam dolore ratione qui maiores adipisci fugiat fuga, in eveniet, reiciendis incidunt dicta ex. Consequuntur atque officiis similique eius quas architecto eos quis vero, minus molestiae nulla cum! Odit asperiores ullam veniam sapiente necessitatibus accusamus quisquam explicabo pariatur iusto saepe inventore aspernatur sequi harum veritatis magnam optio eos neque, qui cumque. Unde atque cumque soluta, corrupti quod quam? Nemo vel impedit, quibusdam distinctio id voluptatem atque suscipit aut quidem itaque quisquam repellat. In incidunt tempore, esse cum quisquam rem doloribus, fugiat illum laudantium delectus deserunt id, sunt sint!",
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
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Aspernatur debitis illo, mollitia nihil labore consequatur, dolorem eum maxime architecto accusantium ipsum voluptatem saepe ea praesentium iure? Soluta nesciunt aut dolorum. Accusamus architecto voluptatum quis quae praesentium nisi, deleniti asperiores dolores suscipit corrupti dicta, blanditiis quas earum autem delectus sit sed perferendis inventore quidem optio maxime? Magnam, doloribus accusamus! Sequi, autem?Assumenda placeat aliquam dolore ratione qui maiores adipisci fugiat fuga, in eveniet, reiciendis incidunt dicta ex. Consequuntur atque officiis similique eius quas architecto eos quis vero, minus molestiae nulla cum! Odit asperiores ullam veniam sapiente necessitatibus accusamus quisquam explicabo pariatur iusto saepe inventore aspernatur sequi harum veritatis magnam optio eos neque, qui cumque. Unde atque cumque soluta, corrupti quod quam? Nemo vel impedit, quibusdam distinctio id voluptatem atque suscipit aut quidem itaque quisquam repellat. In incidunt tempore, esse cum quisquam rem doloribus, fugiat illum laudantium delectus deserunt id, sunt sint!",
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
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Aspernatur debitis illo, mollitia nihil labore consequatur, dolorem eum maxime architecto accusantium ipsum voluptatem saepe ea praesentium iure? Soluta nesciunt aut dolorum. Accusamus architecto voluptatum quis quae praesentium nisi, deleniti asperiores dolores suscipit corrupti dicta, blanditiis quas earum autem delectus sit sed perferendis inventore quidem optio maxime? Magnam, doloribus accusamus! Sequi, autem?Assumenda placeat aliquam dolore ratione qui maiores adipisci fugiat fuga, in eveniet, reiciendis incidunt dicta ex. Consequuntur atque officiis similique eius quas architecto eos quis vero, minus molestiae nulla cum! Odit asperiores ullam veniam sapiente necessitatibus accusamus quisquam explicabo pariatur iusto saepe inventore aspernatur sequi harum veritatis magnam optio eos neque, qui cumque. Unde atque cumque soluta, corrupti quod quam? Nemo vel impedit, quibusdam distinctio id voluptatem atque suscipit aut quidem itaque quisquam repellat. In incidunt tempore, esse cum quisquam rem doloribus, fugiat illum laudantium delectus deserunt id, sunt sint!",
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