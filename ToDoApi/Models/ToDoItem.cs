namespace ToDoApi.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Task { get; set; } = String.Empty;
        public bool IsDone { get; set; } = false;
        public DateTime? DateCompleted { get; set; }
    }
}