# Creating a cylcing club registration application
- Using Console as a UI
- Database = **Microsoft.EntityFrameworkCore.Sqlite**
- Delegates

# Setting Up Sqlite  

## Models

Download Microsoft.EntityFrameworkCore.Sqlite  
and start setting up the models for the project

Notice that the Id property in models have the following annotation  
```
public class User
    {

        //
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressFirstLine { get; set; }
        public string AddressSecondLine { get; set; }
        public string AddressCity { get; set; }
        public string PostCode { get; set; }
    }
```

The above code is a type of database generation so called code first database generator

EnitiyFrameworkCore has the ability to generate databases for use using its special syntax

## Setting up EntityFramworkCore Database configuration files

**DbContext**  
Create a Class with DbContext for normal convention that inherets from the Microsoft.EntityFrameworkCore.DbContext class


>The code below Shows a class that implements the DbContext
>```
>public class ClubMemberShipDbContext : DbContext
>    {
>        
>    }
>```

**Override DbContext's Methods to tailor your project needs and run package manager**
1. This will create a .db file within your projects base class files uppon build to save the database within the project

```
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Notice the Data Source location   
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembershipDb.db");
            base.OnConfiguring(optionsBuilder);
        }
```

2. Add properties DbSet<YourClass> to create tables according to your models  

3. In order to use the package manager console install the following package:  
> ### Microsoft.EntityFrameworkCore.Tools

4. Run PM  
- First you must Initial run the code => Add-Migration if not done so  
- Then run the code Update-Database




