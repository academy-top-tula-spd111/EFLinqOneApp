using EFLinqOneApp;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using (ApplicationContext context = new())
{
    //context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    // operators
    //var employees = (from e in context.Employees.Include(e => e.Company)
    //                where e.CompanyId == 1
    //                select e).ToList();

    // methods
    //var employees = context.Employees
    //                       .Include(e => e.Company)
    //                       .Where(e => e.CompanyId == 1)
    //                       .ToList();

    //foreach(var e in employees)
    //    Console.WriteLine($"{e.Name} {e.Age} {e.Company.Title}");

    /*
     % - any string
     _ - one symbol
    [] - one symbol from coll
    [-] - one symbol from range
    [^] - one symbol not from coll
    */
    /*
    var employeesE = context.Employees.Where(e => EF.Functions.Like(e.Name, "%e%"));
    foreach (var e in employeesE)
        Console.WriteLine($"{e.Name} {e.Age}");
    */
    //var empl2 = context.Employees
    //                   .Where(e 
    //                        => EF.Functions
    //                             .Like(e.Age.ToString(), "2%"));

    //var empl2 = from e in context.Employees
    //            where EF.Functions.Like(e.Age.ToString(), "2%")
    //            select e;


    //foreach (var e in empl2)
    //    Console.WriteLine($"{e.Name} {e.Age}");

    //Console.WriteLine(context.Companies.Find(2).Title);

    //var emp = context.Employees.FirstOrDefault(e => e.CompanyId == 10);
    //Console.WriteLine($"{emp?.Name}");


    //var emplComp = context.Employees.Select(e => new
    //{
    //    Name = e.Name,
    //    Company = e.Company.Title,
    //    Position = e.Position.Title
    //});

    //foreach(var e in emplComp)
    //    Console.WriteLine($"{e.Name} {e.Company} {e.Position}");

    //var companies = context.Companies
    //                       .Join(context.Countries,
    //                       c => c.CountryId,
    //                       ctr => ctr.Id,
    //                       (c, ctr) => new
    //                       {
    //                           Company = c.Title,
    //                           Country = ctr.Title
    //                       });
    //foreach(var c in  companies)
    //    Console.WriteLine($"{c.Company} {c.Country}");

    //var comps = from cmp in context.Companies
    //            join ctr in context.Countries
    //                     on cmp.CountryId equals ctr.Id
    //            join cap in context.Cities
    //                     on ctr.CapitalId equals cap.Id
    //            select new
    //            {
    //                Company = cmp.Title,
    //                Country = ctr.Title,
    //                Capital = cap.Title
    //            };
    //foreach (var c in comps)
    //    Console.WriteLine($"{c.Company} {c.Country} {c.Capital}");

    //var empsGroupComp = from e in context.Employees
    //                    group e by e.Company.Title into c
    //                    select new
    //                    {
    //                        Company = c.Key,
    //                        Count = c.Count(),
    //                        //Employes = c
    //                    };

    //var empsGroupComp = context.Employees
    //                           .GroupBy(e => e.Company.Title)
    //                           .Select(c => new
    //                           {
    //                               Company = c.Key,
    //                               Count = c.Count(),
    //                               Employees = c.Select(e => e)
    //                           });

    //foreach (var c in empsGroupComp)
    //{
    //    Console.WriteLine($"{c.Company} {c.Count} ");
    //    foreach(var e in c.Employees)
    //        Console.WriteLine($"\t{e.Name}");
    //}

    foreach(var e in context.Employees)
        Console.WriteLine($"{e.Name} {e.Age}");
    Console.WriteLine();

    var empl40 = context.Employees
                       .FirstOrDefault(e => e.Age > 40);
    if(empl40 != null)
    {
        empl40.Age = 60;
        context.SaveChanges();
    }

    foreach (var e in context.Employees)
        Console.WriteLine($"{e.Name} {e.Age}");
    Console.WriteLine();

    var q = context.Employees.Where(e => e.Age > 30);
    Console.WriteLine(q.GetType());


    SqlParameter param = new SqlParameter("@id", "1");
    var compSql = context.Companies.FromSqlRaw("SELECT * FROM Companies WHERE CountryId LIKE @id", param).ToList();
    foreach(var c in compSql)
        Console.WriteLine($"{c.Title}");

}

