using LINQ_Examples_3;
using LINQ_Examples_3._helper;

List<Employee> employeeList = Data.GetEmployees();
List<Department> departmentList = Data.GetDepartments(employeeList);

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                          Equality Operator - Sequence Equal                                                       *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");

//var integerList1 = new List<int> { 1, 2, 3, 4, 5, 6 };
//var integerList2 = new List<int> { 1, 2, 3, 4, 5, 6 };

//var boolSequenceEqual = integerList1.SequenceEqual(integerList2);

//Console.WriteLine(boolSequenceEqual);

var integerList1 = new List<int> { 1, 2, 3, 4, 5, 6 };
var integerList2 = new List<int> { 1, 2, 3, 4, 6, 7 };

var boolSequenceEqual = integerList1.SequenceEqual(integerList2);

Console.WriteLine(boolSequenceEqual);

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                          Equality Operator - Sequence Equal - Custom Comparer                                     *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");

var employeeListCompare = Data.GetEmployees();
bool boolSE = employeeList.SequenceEqual(employeeListCompare, new EmployeeComparer());

Console.WriteLine($"Result: {boolSE}");

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                          Concatenation Operator - Concat                                                          *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");

var integerList3 = new List<int> { 1, 2, 3, 4, 5, 6 };
var integerList4 = new List<int> { 1, 2, 3, 4, 6, 7 };

IEnumerable<int> integerListConcat = integerList3.Concat(integerList4);

foreach (var item in integerListConcat)
{
    Console.Write(item);
}
Console.WriteLine("");

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                          Concatenation Operator - Concat                                                          *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");

List<Employee> employeeList2 = new List<Employee> {
                                    new Employee { Id = 7, FirstName = "Yeji", LastName = "Hwang", AnnualSalary=60000.1m },
                                    new Employee { Id = 8, FirstName = "Ryujin", LastName = "Shin", AnnualSalary=60000.1m  },
                                };
IEnumerable<Employee> results = employeeList.Concat(employeeList2);
foreach (var item in results)
{
    Console.WriteLine($"Id: {item.Id,-5} FirstName: {item.FirstName,-10}\t LastName: {item.LastName,-10}\t Annual Salary: {item.AnnualSalary,10}");
}

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                          Aggregate Operators - Aggregate, Average, Count, Sum, Max, Min                           *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Aggregate Operators - Aggregate                              *");
Console.WriteLine("*---------------------------------------------------------------*");
decimal totalAnnualSalary = employeeList.Aggregate<Employee, decimal>(0, (totalAnnualSalary, e) =>
{
    var bonus = (e.IsManager) ? 0.04m : 0.02m;
    totalAnnualSalary = (e.AnnualSalary + (e.AnnualSalary * bonus)) + totalAnnualSalary;
    return totalAnnualSalary;
});

Console.WriteLine($"Total Annual Salary of all employee: (including bonus): {totalAnnualSalary}");

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Aggregate Operators - Aggregate - Comma Delimited            *");
Console.WriteLine("*---------------------------------------------------------------*");

string data = employeeList.Aggregate<Employee, string, string>("Employee Annual Salaries(including bonus): ",
    (s, e) =>
        {
            var bonus = (e.IsManager) ? 0.04m : 0.02m;
            s += $"{e.FirstName} {e.LastName} - {e.AnnualSalary + (e.AnnualSalary * bonus)}, ";
            return s;
        }, s => s.Substring(0, s.Length - 2)
    );

Console.WriteLine(data);

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Aggregate Operators - Average                                *");
Console.WriteLine("*---------------------------------------------------------------*");

decimal average = employeeList.Average(e => e.AnnualSalary);

Console.WriteLine($"Average Annual Salary: {average}");

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Aggregate Operators - Average - Where                        *");
Console.WriteLine("*---------------------------------------------------------------*");

decimal average2 = employeeList
                    .Where(e => e.DepartmentId == 3)
                    .Average(e => e.AnnualSalary);

Console.WriteLine($"Average Annual Salary(Technology Department): {average2}");

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Aggregate Operators - Count                                  *");
Console.WriteLine("*---------------------------------------------------------------*");

int countEmployees = employeeList.Count();
Console.WriteLine($"Number of employees: {countEmployees}");

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Aggregate Operators - Count - Where                          *");
Console.WriteLine("*---------------------------------------------------------------*");
int countEmployees2 = employeeList
                        .Where(e => e.DepartmentId == 3)
                        .Count();
Console.WriteLine($"Number of employees(Technology Department): {countEmployees2}");

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Aggregate Operators - Sum                                    *");
Console.WriteLine("*---------------------------------------------------------------*");
decimal result1 = employeeList.Sum(e => e.AnnualSalary);
Console.WriteLine($"Total annual salaries: {result1}");

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Aggregate Operators - Max                                    *");
Console.WriteLine("*---------------------------------------------------------------*");
decimal result2 = employeeList.Max(e => e.AnnualSalary);
Console.WriteLine($"Employee with highest Annual Salary: {result2}");

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Aggregate Operators - Min                                    *");
Console.WriteLine("*---------------------------------------------------------------*");
decimal result3 = employeeList.Min(e => e.AnnualSalary);
Console.WriteLine($"Employee with Minimum Annual Salary: {result3}");

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                          Generation Operators - DefaultIfEmpty, Empty, Range, Repeat                              *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Generation Operator - DefaultIfEmpty(No Value)               *");
Console.WriteLine("*---------------------------------------------------------------*");
List<int> intList = new List<int>();
var newList = intList.DefaultIfEmpty();

Console.WriteLine(newList.ElementAt(0));
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Generation Operator - DefaultIfEmpty(new employee)           *");
Console.WriteLine("*---------------------------------------------------------------*");
List<Employee> employees = new List<Employee>();
var newList2 = employees.DefaultIfEmpty(new Employee { Id = 0 });

var result4 = newList2.ElementAt(0);
if (result4.Id == 0)
{
    Console.WriteLine($"The list is empty");
}
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Generation Operator - DefaultIfEmpty(99999)                  *");
Console.WriteLine("*---------------------------------------------------------------*");
List<int> intList2 = new List<int>();
var newList3 = intList.DefaultIfEmpty(99999);

Console.WriteLine(newList3.ElementAt(0));

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Generation Operator - Empty                                  *");
Console.WriteLine("*---------------------------------------------------------------*");

//IEnumerable<Employee> emptyEmployee = Enumerable.Empty<Employee>();
List<Employee> emptyEmployeeList = Enumerable.Empty<Employee>().ToList();

emptyEmployeeList.Add(
    new Employee
    {
        Id = 7,
        FirstName = "Sio",
        LastName = "Jeong",
        AnnualSalary = 50000.1m
    });
foreach (var item in emptyEmployeeList)
{
    Console.WriteLine($"{item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
}

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Generation Operator - Range                                  *");
Console.WriteLine("*---------------------------------------------------------------*");

var intCollection = Enumerable.Range(25, 20);

foreach (var item in intCollection)
{
    Console.WriteLine(item);
}

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Generation Operator - Repeat                                 *");
Console.WriteLine("*---------------------------------------------------------------*");
var strCollection = Enumerable.Repeat<string>("Chris Pogi", 10);
foreach (var item in strCollection)
{
    Console.WriteLine(item);
}

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                          Set Operators - Distinct, Except, Intersect, Union                                       *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Set Operators - Distinct                                     *");
Console.WriteLine("*---------------------------------------------------------------*");

List<int> list = new List<int> { 1, 2, 1, 2, 3, 4, 1, 2, 7, 8, 7 };
var results2 = list.Distinct();

foreach (var item in results2)
{
    Console.WriteLine(item);
}

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Set Operators - Except(int)                                  *");
Console.WriteLine("*---------------------------------------------------------------*");
IEnumerable<int> collection1 = new List<int> { 1, 2, 3, 4 };
IEnumerable<int> collection2 = new List<int> { 3, 4, 5, 6 };

var results3 = collection1.Except(collection2);

foreach (var item in results3)
{
    Console.WriteLine(item);
}

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Set Operators - Except(employee) - EmployeeComparer          *");
Console.WriteLine("*---------------------------------------------------------------*");

List<Employee> employeeList3 = new List<Employee>();

employeeList3.Add(new Employee
{
    Id = 1,
    FirstName = "Kobe",
    LastName = "Mancuyas",
    AnnualSalary = 60000.3m,
    IsManager = true,
    DepartmentId = 1,
});

var results4 = employeeList.Except(employeeList3, new EmployeeComparer());
foreach (var item in results4)
{
    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
}

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Set Operators - Union                                        *");
Console.WriteLine("*---------------------------------------------------------------*");

List<Employee> employeeList4 = new List<Employee>();

employeeList4.Add(new Employee
{
    Id = 1,
    FirstName = "Kobe",
    LastName = "Mancuyas",
    AnnualSalary = 60000.3m,
    IsManager = true,
    DepartmentId = 1,
});

var results5 = employeeList.Union(employeeList4, new EmployeeComparer()); //Comparer is needed to prevent multiple common records
foreach (var item in results5)
{
    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
}

Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                   Partitioning Operators - Skip, SkipWhile, Take, TakeWhile                                       *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Partitioning Operators - Skip                                *");
Console.WriteLine("*---------------------------------------------------------------*");
var results6 = employeeList.Skip(2);
foreach (var item in results6)
{
    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
}

Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Partitioning Operators - SkipWhile                           *");
Console.WriteLine("*---------------------------------------------------------------*");
//will skip while condition is true
var results7 = employeeList.SkipWhile(e => e.AnnualSalary >= 30000);
foreach (var item in results7)
{
    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
}
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Partitioning Operators - Take                                *");
Console.WriteLine("*---------------------------------------------------------------*");
var results8 = employeeList.Take(2);
foreach (var item in results8)
{
    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
}
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Partitioning Operators - TakeWhile                           *");
Console.WriteLine("*---------------------------------------------------------------*");
//will take while condition is true
var results9 = employeeList.TakeWhile(e => e.AnnualSalary > 50000);
foreach (var item in results9)
{
    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
}
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                   Conversion Operators - ToList, ToDictionary, ToArray                                            *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Conversion Operators - ToList                                *");
Console.WriteLine("*---------------------------------------------------------------*");
List<Employee> results10 = (from emp in employeeList
                            where emp.AnnualSalary > 50000
                            select emp).ToList();
foreach (var item in results10)
{
    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
}
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Conversion Operators - ToDictionary                          *");
Console.WriteLine("*---------------------------------------------------------------*");
Dictionary<int, Employee> dictionary = (from emp in employeeList
                                        where emp.AnnualSalary > 50000
                                        select emp).ToDictionary<Employee, int>(e => e.Id);
foreach (var key in dictionary.Keys)
{
    Console.WriteLine($"Key: {key}, Value: {dictionary[key].FirstName} {dictionary[key].LastName} {dictionary[key].AnnualSalary}");
}
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Conversion Operators - ToArray                               *");
Console.WriteLine("*---------------------------------------------------------------*");
Employee[] results11 = (from emp in employeeList
                        where emp.AnnualSalary > 50000
                        select emp).ToArray();
foreach (var item in results11)
{
    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
}
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                   Keywords - Let, Into                                                                            *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Keywords - Let Clause                                        *");
Console.WriteLine("*---------------------------------------------------------------*");

var results12 = from emp in employeeList
                let Initials = emp.FirstName.Substring(0, 1).ToUpper() + emp.LastName.Substring(0, 1).ToUpper()
                let AnnualSalaryPlusBonus = (emp.IsManager) ? emp.AnnualSalary + (emp.AnnualSalary * 0.04m) : emp.AnnualSalary + (emp.AnnualSalary * 0.02m)
                where Initials == "AJ" || Initials == "SJ" && AnnualSalaryPlusBonus > 50000
                select new
                {
                    Initials = Initials,
                    FullName = emp.FirstName + " " + emp.LastName,
                    AnnualSalaryPlusBonus = AnnualSalaryPlusBonus
                };
foreach (var item in results12)
{
    Console.WriteLine($"{item.Initials,-5} {item.FullName,-10} {item.AnnualSalaryPlusBonus,-10}");
}
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Keywords - Into Clause                                       *");
Console.WriteLine("*---------------------------------------------------------------*");
var results13 = from emp in employeeList
                where emp.AnnualSalary > 50000
                select emp
                into HighEarners
                //where HighEarners.IsManager == true
                select HighEarners;
foreach (var item in results13)
{
    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10} {item.IsManager}");
}
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*                  The Projection Operators - Select, SelectMany                                                    *");
Console.WriteLine("*-------------------------------------------------------------------------------------------------------------------*");
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Projection Operators - Select                                *");
Console.WriteLine("*---------------------------------------------------------------*");
var results14 = departmentList.Select(d => d.Employees);
foreach (var items in results14)
{
    foreach (var item in items)
    {
        Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
    }
}
Console.WriteLine("*---------------------------------------------------------------*");
Console.WriteLine("*  Projection Operators - SelectMany                            *");
Console.WriteLine("*---------------------------------------------------------------*");
var results15 = departmentList.SelectMany(d => d.Employees).OrderBy(o=>o.Id);
foreach (var item in results15)
{
    Console.WriteLine($"{item.Id,-5} {item.FirstName,-10} {item.LastName,-10} {item.AnnualSalary,-10}");
}
Console.ReadKey();