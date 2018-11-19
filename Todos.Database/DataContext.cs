namespace Todos.Database.Schema
{
    using System.Data.Entity;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base(@"data source=178.128.114.26;initial catalog=Todos;persist security info=True;user id=sa;password=MinhAn@2003;multipleactiveresultsets=True;application name=EntityFramework")
        {
        }

        public virtual DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}