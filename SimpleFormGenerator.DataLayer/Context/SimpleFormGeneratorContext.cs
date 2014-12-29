using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SimpleFormGenerator.DomainClasses;

namespace SimpleFormGenerator.DataLayer.Context
{
    public class SimpleFormGeneratorContext : DbContext, IUnitOfWork
    {
        public SimpleFormGeneratorContext()
            : base("SimpleFormGenerator")
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Value> Values { get; set; }


        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public int SaveAllChanges()
        {
            return base.SaveChanges();
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public IList<T> GetRows<T>(string sql, params object[] parameters) where T : class
        {
            return Database.SqlQuery<T>(sql, parameters).ToList();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Value>()
                .HasRequired(d => d.Form)
                .WithMany()
                .HasForeignKey(d => d.FormId)
                .WillCascadeOnDelete(false);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing); //فقط تعريف شده تا يك برك پوينت در اينجا قرار داده شود براي آزمايش فراخواني آن
        }
    }
}