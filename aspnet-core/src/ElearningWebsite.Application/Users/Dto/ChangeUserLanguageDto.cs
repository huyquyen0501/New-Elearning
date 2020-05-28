using System.ComponentModel.DataAnnotations;

namespace ElearningWebsite.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}