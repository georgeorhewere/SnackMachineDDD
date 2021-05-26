using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnackMachine.ORM
{
    public class SnackMachineDbContext : DbContext
    {
        private readonly string connectionString = "Data Source=Hp/Druidsdba;initial catalog=SnackMachineDb;User ID=storeuser;Password=storeuser1; Connect Timeout=120;";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }
    }
}
