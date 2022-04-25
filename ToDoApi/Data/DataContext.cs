using ToDoApi.Models; 

namespace ToDoApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
