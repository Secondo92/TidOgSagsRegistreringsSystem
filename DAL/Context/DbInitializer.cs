using DAL.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL.Context
{
    public class DbInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var Dep1 = context.Departments.Add(new Department("IT", 1));

            context.Departments.Add(new Department("HR", 2));
            context.Departments.Add(new Department("Salg", 3));
            context.Departments.Add(new Department("Marketing", 4));

            context.Cases.Add(new Case(1, "Headline1", "Description1", Dep1.DepartmentName));

            context.SaveChanges();
        }

    private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}