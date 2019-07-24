namespace WebApp.Models
{
    public class WebsiteViewModel
    {
        public int WebsiteId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public WebsiteViewModel()
        {
            WebsiteId = 0;
        }
    }
}