using DemoProjectMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProjectMVC.DbCon
{
    public class DemoProjectMVCDbContext:DbContext


    {

        public DemoProjectMVCDbContext(DbContextOptions<DemoProjectMVCDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
       

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Officer> Officers { get; set; }


        //internal void Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //internal void Delete(object entity)
        //{
        //    throw new NotImplementedException();
        //}

        //internal object Find(int? id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
