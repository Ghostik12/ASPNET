
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCStartApp.Models.Db
{
    [Table("UserRequest")]
    public class UserRequest
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
