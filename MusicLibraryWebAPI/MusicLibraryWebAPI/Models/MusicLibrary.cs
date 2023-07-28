using System.ComponentModel.DataAnnotations;

namespace MusicLibraryWebAPI.Models
{
    public class MusicLibrary
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
    }
}
