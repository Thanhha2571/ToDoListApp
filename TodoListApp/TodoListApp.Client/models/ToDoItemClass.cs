
namespace TodoListApp.Client.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public Category Category { get; set; }
        public DateTime? Deadline { get; set; }
    }

}