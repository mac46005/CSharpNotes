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



## Creating and API Checks Fields for the models

1. Created a new ClassLib

2. Created a class that checks for common user data for feild validation using delegates  
Notice the implemintation on how the delegates are used as Properties.  
This class uses the Singleton Pattern to ensure that each method is instantiated with one instance of it  
```
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDate);
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);

    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchValidDel _patterMatchDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;

        public static RequiredValidDel RequiredValidDel
        {
            get
            {
                if(_requiredValidDel == null)
                {
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);
                }

                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthValidDel
        {
            get
            {
                if(_stringLengthValidDel == null)
                {
                    _stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);
                }

                return _stringLengthValidDel;
            }
        }

        public static DateValidDel DateValidDel
        {
            get
            {
                if(_dateValidDel == null)
                {
                    _dateValidDel = new DateValidDel(DateFieldValid);
                }

                return _dateValidDel;
            }
        }

        public static PatternMatchValidDel PatterMatchDel
        {
            get
            {
                if(_patterMatchDel == null)
                {
                    _patterMatchDel = new PatternMatchValidDel(FieldPatternValid);
                }

                return _patterMatchDel;
            }
        }



        public static CompareFieldsValidDel CompareFieldsValidDel
        {
            get
            {
                if(_compareFieldsValidDel == null)
                {
                    _compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);
                }

                return _compareFieldsValidDel;
            }
        }
        private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            return false;
        }
        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
            {
                return true;
            }
            return false;
        }
        private static bool DateFieldValid(string datetTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(datetTime, out validDateTime))
            {
                return true;
            }
            return false;
        }
        private static bool FieldPatternValid(string fieldVal, string regularExpression)
        {
            Regex regex = new Regex(regularExpression);

            if (regex.IsMatch(fieldVal))
            {
                return true;
            }

            return false;
        }
        private static bool FieldComparisonValid(string field1, string field2)
        {
            if (field1.Equals(field2))
            {
                return true;
            }

            return false;
        }
    }
```


