using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApplication.Models
{
    public class MyList
    {
        public  int Id{ get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Deadline{ get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User{ get; set; }
    }
}
