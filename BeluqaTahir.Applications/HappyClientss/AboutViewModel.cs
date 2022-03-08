using Microsoft.AspNetCore.Http;

namespace BeluqaTahir.Applications.HappyClientss
{
    public class AboutViewModel
    {
        public int? Id { get; set; }
        public string ImagePati { get; set; }
        public string FullName { get; set; }
        public string Answer { get; set; }
        public string Description { get; set; }
        public IFormFile file { get; set; }
    }
}
