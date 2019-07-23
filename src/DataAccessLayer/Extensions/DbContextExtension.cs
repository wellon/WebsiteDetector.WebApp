using DataAccessLayer.EF;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Extensions
{
    public static class DbContextExtension
    {
        public static void AddTestData(this DataContext context)
        {
            context.Websites.Add(new Website { Id = 1, Name = "Google", Url = "https://google.com" });
            context.Websites.Add(new Website { Id = 2, Name = "Yandex", Url = "https://yandex.ru" });
            context.Websites.Add(new Website { Id = 3, Name = "VK666", Url = "https://vk666.ru" });

            context.SaveChanges();
        }
    }
}