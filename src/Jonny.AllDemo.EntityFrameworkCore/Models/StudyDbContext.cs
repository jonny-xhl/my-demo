using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Jonny.AllDemo.EntityFrameworkCore.Models
{
    public class StudyDbContext:DbContext
    {
        public StudyDbContext() { }

        public StudyDbContext(DbContextOptions<StudyDbContext> options) : base(options){}


        public DbSet<Users> Users { get; set; }
        /// <summary>
        /// 模型创建的进行时候配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            {
                var entries=ChangeTracker.Entries();
                
                TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            }
            return base.SaveChanges();
        }
    }
}
