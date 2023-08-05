using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EmployeeManagement.Models
{
    public class CompanyDBContext : DbContext
    {
        public CompanyDBContext() : base("MyConnectionString") { }
        public DbSet<Employee> Employees { get; set; }

    }

}