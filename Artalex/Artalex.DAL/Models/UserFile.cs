using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class UserFile : BaseEntity
    {
        public string FileName { get; set; } // Stored file name
        public string FilePath { get; set; } // Path where the file is stored
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
