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
                        new User { UserName = "altay", Image = "p11.webp", Name = "Altay Turan", Email = "altayturan@gmail.com", Password = "545454", VerificationCode = "872402",IsVerified= true },
                        new User { UserName = "baykutay", Image = "p2.png", Name = "Baykutay Turan", Email = "baykutayturan@gmail.com", Password = "545454",VerificationCode = "872400",IsVerified= true },
                        new User { UserName = "sevval", Image = "sevval.png", Name = "Şevval Sevinç", Email = "sevvalmert@gmail.com", Password = "meşe0611",VerificationCode = "872410",IsVerified= true }
                    );
                    context.SaveChanges();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new Tag { Text = "Web Geliştirme", Url = "web-programlama", Color = TagColors.warning },
                        new Tag { Text = "Kitap", Url = "kitap", Color = TagColors.warning },
                        new Tag { Text = "Gündem", Url = "frontend", Color = TagColors.success },
                        new Tag { Text = "Dizi/Film", Url = "dizi-film", Color = TagColors.primary },
                        new Tag { Text = "Oyun", Url = "oyun", Color = TagColors.secondary }
                    );
                    context.SaveChanges();
                }
                if (!context.Posts.Any())
                {
                    context.SaveChanges();
                }
            }
        }
    }
}