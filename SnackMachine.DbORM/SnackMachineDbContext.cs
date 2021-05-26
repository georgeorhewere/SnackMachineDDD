using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackMachine.DbORM
{
    public class SnackMachineDbContext :  DbContext
    {
        private readonly string connectionString = "Data Source=Hp/Druidsdba;initial catalog=SnackMachineDb;User ID=storeuser;Password=storeuser1; Connect Timeout=120;";
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder){
            builder.UseSqlServer(connectionString);
        }
    }
}
