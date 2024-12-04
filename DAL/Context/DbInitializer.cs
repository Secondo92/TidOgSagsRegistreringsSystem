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
            var comp1 = new Company("Company1");
            var employee1 = new Employee("123456-1234", "Davide Nuccio", Dep1.DepartmentName);


            context.Departments.Add(new Department("HR", 2));
            context.Departments.Add(new Department("Sales", 3));
            context.Departments.Add(new Department("Marketing", 4));

            comp1.Employees.Add(employee1);
            


            context.Companies.Add(comp1);


            employee1.DepartmentName = Dep1.DepartmentName;
            context.Employees.Add(employee1);

            context.Cases.Add(new Case(1, "Headline1", "Description1", Dep1.DepartmentNumber));
            




            /*
            context.TimeRegistrations.Add(new TimeRegistration()
            {
                Employee = context.Employees.Find(1),
                Case = context.Cases.Find(1),
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1)
            });
            */
            

            context.SaveChanges();
        }

    private void dummy()
        {
            string result = System.Data.Entity.SqlServer.SqlFunctions.Char(65);
        }
    }
}