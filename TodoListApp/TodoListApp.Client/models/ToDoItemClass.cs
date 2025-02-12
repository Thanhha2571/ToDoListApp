namespace TodoListApp.Client.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Status { get; set; }
        public Category Category { get; set; }
        public DateTime? Deadline { get; set; }

        public int? PersonId { get; set; }
    }
}