using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace PredicatesWithClasses
{
    class Program
    {
        static void Main(string[] args)
        {

            bool band = true;
            do
            {
                WriteLine("\tWelcome to HappyPet Hospital System");
                WriteLine("\nWhat do you want to do?"
                    + "\n 1.-Search patients by name"
                    + "\n 2.-Search patients by doctor"
                    + "\n 3.-Search patients by age"
                    + "\n 4.-Search patients by Birthday"
                    + "\n 5.-Search patients by visit dat"
                    + "\n 6.-Search only aquatic patinents"
                    + "\n Please enter an option : "
                    );

                Int32.TryParse(ReadLine(), out int option);
                if (option == 4 || option == 5)
                {
                    WriteLine("\nPlease enter your first date : ");
                    var input = ReadLine();
                    WriteLine("\nPlease enter your second date : ");
                    var input2 = ReadLine();
                    Searcher(option, input, input2);//mm/dd/yyyy
                }
                else if (option == 6)
                {
                    var input = "Y";
                    Searcher(option, input);
                }
                else
                {
                    WriteLine("\nPlease enter your search : ");
                    var input = ReadLine();
                    Searcher(option, input);
                }

                WriteLine("Do you want to do something else? (y/n)");
                var respond = ReadLine();
                if (respond == "n") band = false;
            } 
            while (band == true);
            
            
        }

        public static void Searcher(int option, string input, string input2 = null)
        {
            User.Input = input;
            User.Input2 = input2;
            User.Option = option;

            Predicate<Pet> predicateByName = new Predicate<Pet>(Pet.GetByName);
            Predicate<Pet> predicateByResponsable = new Predicate<Pet>(Pet.GetByResponsable);
            Predicate<Pet> predicateByAge = new Predicate<Pet>(Pet.GetByAge);
            Predicate<Pet> predicateByBirthday = new Predicate<Pet>(Pet.GetByBirthday);
            Predicate<Pet> predicateByVisit = new Predicate<Pet>(Pet.GetByVisit);
            Predicate<Pet> predicateByKind = new Predicate<Pet>(Pet.GetByKind);

            List<Pet> pets = new List<Pet>()
        {
            new Pet{Name = "Perrito1", ResponsableName = "Pedro", Age = 5, Birthday = new DateTime(2017,2,14),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Perrito2", ResponsableName = "Pedro", Age = 4, Birthday = new DateTime(2018,3,14),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Perrito3", ResponsableName = "Pedro", Age = 3, Birthday = new DateTime(2019,2,15),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Perrito4", ResponsableName = "Pedro", Age = 2, Birthday = new DateTime(2020,4,14),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Perrito5", ResponsableName = "Pedro", Age = 1, Birthday = new DateTime(2021,2,16),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Gato1", ResponsableName = "Rosa", Age = 1, Birthday = new DateTime(2021,10,31),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Gato2", ResponsableName = "Rosa", Age = 2, Birthday = new DateTime(2020,11,30),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Gato3", ResponsableName = "Rosa", Age = 3, Birthday = new DateTime(2019,12,29),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Gato4", ResponsableName = "Rosa", Age = 4, Birthday = new DateTime(2018,1,12),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Gato5", ResponsableName = "Rosa", Age = 5, Birthday = new DateTime(2017,1,12),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Pez1", ResponsableName = "Luka", Age = 1, Birthday = new DateTime(2021,1,13),VisitDate = DateTime.Now, IsAquatic = true},
            new Pet{Name = "Pez2", ResponsableName = "Luka", Age = 2, Birthday = new DateTime(2020,3,15),VisitDate = DateTime.Now, IsAquatic = true},
            new Pet{Name = "Pez3", ResponsableName = "Luka", Age = 2, Birthday = new DateTime(2020,5,1),VisitDate = DateTime.Now, IsAquatic = true},
            new Pet{Name = "Pez4", ResponsableName = "Luka", Age = 2, Birthday = new DateTime(2020,7,19),VisitDate = DateTime.Now, IsAquatic = true},
            new Pet{Name = "Pez5", ResponsableName = "Luka", Age = 3, Birthday = new DateTime(2019,8,30),VisitDate = DateTime.Now, IsAquatic = true},
            new Pet{Name = "Borrego1", ResponsableName = "Lupita", Age = 3, Birthday = new DateTime(2019,2,14),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Borrego2", ResponsableName = "Lupita", Age = 3, Birthday = new DateTime(2019,2,14),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Borrego3", ResponsableName = "Lupita", Age = 3, Birthday = new DateTime(2019,2,14),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Borrego4", ResponsableName = "Lupita", Age = 3, Birthday = new DateTime(2019,2,14),VisitDate = DateTime.Now, IsAquatic = false},
            new Pet{Name = "Borrego5", ResponsableName = "Lupita", Age = 3, Birthday = new DateTime(2019,2,14),VisitDate = DateTime.Now, IsAquatic = false}
        };


            switch (option)
            {
                case 1:
                    var resultName = pets.FindAll(predicateByName);
                    if (resultName.Any())
                    {
                        WriteLine("We found these patients : ");
                        foreach (var item in resultName)
                        {
                            Printer(item);
                        }
                    }
                    break;
                case 2:
                    var resultResponsable = pets.FindAll(predicateByResponsable);
                    if (resultResponsable.Any())
                    {
                        WriteLine("We found these patients : ");
                        foreach (var item in resultResponsable)
                        {
                            Printer(item);
                        }
                    }
                    break;
                case 3:
                    var resultAge = pets.FindAll(predicateByAge);
                    if (resultAge.Any())
                    {
                        WriteLine("We found these patients : ");
                        foreach (var item in resultAge)
                        {
                            Printer(item);
                        }
                    }
                    break;
                case 4:
                    var resultBirth = pets.FindAll(predicateByBirthday);
                    if (resultBirth.Any())
                    {
                        WriteLine("We found these patients : ");
                        foreach (var item in resultBirth)
                        {
                            Printer(item);
                        }
                    }
                    break;
                case 5:
                    var resultVisit = pets.FindAll(predicateByVisit);
                    if (resultVisit.Any())
                    {
                        WriteLine("We found these patients : ");
                        foreach (var item in resultVisit)
                        {
                            Printer(item);
                        }
                    }
                    break;
                case 6:
                    var resultKind = pets.FindAll(predicateByKind);
                    if (resultKind.Any())
                    {
                        WriteLine("We found these patients : ");
                        foreach (var item in resultKind)
                        {
                            Printer(item);
                        }
                    }
                    break;
                default:
                    break;

            };
        }
        public static void Printer(Pet pet)
        {
            WriteLine("\n Name: " + pet.Name + "   Age: " + pet.Age + "   Dr: " + pet.ResponsableName + "   Birthday: " + pet.Birthday.ToShortDateString() + "   LastVisit: " + pet.VisitDate.ToShortDateString());
        }
    }
    class Pet
    {
        public string Name{ get; set; }
        public string ResponsableName { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime VisitDate { get; set; }
        public bool IsAquatic { get; set; }
        public static bool GetByName(Pet pet)
        {
            return pet.Name.Equals(User.Input);
        }
        public static bool GetByResponsable(Pet pet)
        {
            return pet.ResponsableName.Equals(User.Input);
        }
        public static bool GetByAge(Pet pet)
        {
            var isNumber = Int32.TryParse(User.Input, out int age);
            if (isNumber)
                return pet.Age.Equals(age);
            else
                return false;
        }
        public static bool GetByBirthday(Pet pet)
        {
            var isDate1= DateTime.TryParse(User.Input, out DateTime Bdate1);
            var isDate2 = DateTime.TryParse(User.Input2, out DateTime Bdate2);

            
            if (isDate1 && isDate2)
            {
                if (Bdate1 > Bdate2)
                {
                    return (pet.Birthday > Bdate2) && (pet.Birthday < Bdate1)
                       ?
                       true : false;
                }
                else if(Bdate2 > Bdate1)
                {
                    return (pet.Birthday > Bdate1) && (pet.Birthday < Bdate2)
                       ?
                       true : false;
                }
                else
                {
                    return (pet.Birthday == Bdate1) //Las fechas son iguales
                       ?
                       true : false;
                }

            }
                
            else
                return false;
        }
        public static bool GetByVisit(Pet pet)
        {
            var isDate1 = DateTime.TryParse(User.Input, out DateTime Bdate1);
            var isDate2 = DateTime.TryParse(User.Input2, out DateTime Bdate2);


            if (isDate1 && isDate2)
            {
                if (Bdate1 > Bdate2)
                {
                    return (pet.VisitDate > Bdate2) && (pet.VisitDate < Bdate1)
                       ?
                       true : false;
                }
                else if (Bdate2 > Bdate1)
                {
                    return (pet.VisitDate > Bdate1) && (pet.VisitDate < Bdate2)
                       ?
                       true : false;
                }
                else
                {
                    return (pet.VisitDate == Bdate1) //Las fechas son iguales
                       ?
                       true : false;
                }

            }

            else
                return false;
        }

        public static bool GetByKind(Pet pet)
        {
                return pet.IsAquatic.Equals(true);
        }
        
    }

    class User
    {
        public static string Input { get; set; }
        public static string Input2 { get; set; }
        public static int Option { get; set; }
    }
  
}
