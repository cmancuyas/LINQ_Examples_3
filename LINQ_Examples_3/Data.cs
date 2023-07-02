﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples_3
{
    public class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee()
            {
                Id = 1,
                FirstName = "Kobe",
                LastName = "Mancuyas",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 1,
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Id = 2,
                FirstName = "Sio",
                LastName = "Jeong",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 2,
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Id = 3,
                FirstName = "Aran",
                LastName = "Jeong",
                AnnualSalary = 40000.1m,
                IsManager = false,
                DepartmentId = 2,
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Id = 4,
                FirstName = "Keena",
                LastName = "Song",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 2,
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Id = 5,
                FirstName = "Saena",
                LastName = "Jeong",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 2,
            };
            employees.Add(employee);

            employee = new Employee()
            {
                Id = 6,
                FirstName = "Chris",
                LastName = "Mancuyas",
                AnnualSalary = 100000.2m,
                IsManager = false,
                DepartmentId = 3,
            };
            employees.Add(employee);

            return employees;
        }

        public static List<Department> GetDepartments(IEnumerable<Employee> employees)
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources",
                Employees = from emp in employees
                            where emp.DepartmentId == 1
                            select emp
            };

            departments.Add(department);

            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance",
                Employees = from emp in employees
                            where emp.DepartmentId == 2
                            select emp
            };

            departments.Add(department);

            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology",
                Employees = from emp in employees
                            where emp.DepartmentId == 3
                            select emp
            };

            departments.Add(department);

            return departments;
        }
    }
}
