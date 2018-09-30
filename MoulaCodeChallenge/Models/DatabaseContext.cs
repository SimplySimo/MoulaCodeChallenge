using System.Data.Entity;

namespace MoulaCodeChallenge.Models
{
    public partial class DatabaseContext : DbContext, IDbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public void MarkAsModified(Customer customer)
        {
            Entry(customer).State = EntityState.Modified;
        }

        public virtual new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
