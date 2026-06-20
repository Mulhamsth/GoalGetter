using GG.CoreBusiness;
using Libraries.DistanceAddressCalculator;

namespace ConsoleAppPlayground
{
    internal class Program
    {

        static void Main(string[] args)
        {
            TestGeolocator();
        }

        public static void TestGeolocator()
        {
            Address a = Address.FindAddresses("Stephansplatz 1, 1010 Wien")[0];
            Address b = Address.FindAddresses("Hauptplatz 1, 4020 Linz")[0];

            Console.WriteLine($"Distance from {a.ID} to {b.ID}");
            Console.WriteLine(Address.CalcDistance(a, b));
            
            
        }

        public static void Librarytest()
        {
            List<Project> Projects = new List<Project>();
            List<Person> Contact = new List<Person>();
            Random randy = new Random();


            CreateTestData();
            Console.WriteLine();

            void CreateTestData()
            {
                Contact.Add(new Person()
                {
                    Id = 1,
                    Firstname = "Sam",
                    Lastname = "Hale",
                    Address = "Stephansplatz 1, 1010 Wien",
                    AvatarPath = @"https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png",
                    Email = "s.hale@example.com"
                });

                Contact.Add(new Person()
                {
                    Id = 2,
                    Firstname = "Nora",
                    Lastname = "Berg",
                    Address = "Hauptplatz 1, 4020 Linz",
                    AvatarPath = @"https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png",
                    Email = "n.berg@example.com"
                });

                Contact.Add(new Person()
                {
                    Id = 3,
                    Firstname = "Clara",
                    Lastname = "Frost",
                    Address = "Hauptplatz 1, 8010 Graz",
                    AvatarPath = @"https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png",
                    Email = "c.frost@example.com"
                });

                Contact.Add(new Person()
                {
                    Id = 4,
                    Firstname = "Alex",
                    Lastname = "Stein",
                    Address = "Domplatz 1, 3500 Krems an der Donau",
                    AvatarPath = @"https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png",
                    Email = "a.stein@example.com"
                });

                Contact.Add(new Person()
                {
                    Id = 5,
                    Firstname = "Max",
                    Lastname = "Mustermann",
                    Address = "Residenzplatz 1, 5020 Salzburg",
                    AvatarPath = @"https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png",
                    Email = "demo@example.com"
                });

                Contact.Add(new Person()
                {
                    Id = 6,
                    Firstname = "Chris",
                    Lastname = "Walden",
                    Address = "Maria-Theresien-Straße 1, 6020 Innsbruck",
                    AvatarPath = @"https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png",
                    Email = "demo@example.com"
                });

                Contact.Add(new Person()
                {
                    Id = 7,
                    Firstname = "Jonas",
                    Lastname = "Roth",
                    Address = "Stephansplatz 1, 1010 Wien",
                    AvatarPath = @"https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460__340.png",
                    Email = "j.roth@example.com"
                });


                //Project I
                Team t1 = new Team() { Description = "Dream Team", Id = RandomString(), members = new List<Teammember>() };

                t1.members.Add(new Teammember() { person = getRandomPerson(), Description = "Designer", Role = Teamrolle.Worker });
                t1.members.Add(new Teammember() { person = getRandomPerson(), Description = "Programmer", Role = Teamrolle.Worker });
                t1.members.Add(new Teammember() { person = getRandomPerson(), Description = "Projektleiter", Role = Teamrolle.Projektleader });

                Project p1 = new Project() { Name = "Project 1", Budget = 99.50f, status = ProgressStatus.In_Progress, assignedTeam = t1, Description = "This project is for testing", Id = 1, Tasks = new List<ProjectTask>() };

                p1.Tasks.Add(new ProjectTask() { Name = "Code Website", Description = "Make a website lol. xd. mega lol.", AssignedPerson = getRandomTPerson(t1), Deadline = RandomDay(), Id = RandomString() });
                p1.Tasks.Add(new ProjectTask() { Name = "Code Website 2", Description = "Make a website lol. xd. mega lol.", AssignedPerson = getRandomTPerson(t1), Deadline = RandomDay(), Id = RandomString() });
                p1.Tasks.Add(new ProjectTask() { Name = "Code Website 3", Description = "Make a website lol. xd. mega lol.", AssignedPerson = getRandomTPerson(t1), Deadline = RandomDay(), Id = RandomString() });
                p1.Tasks.Add(new ProjectTask() { Name = "Have FreeTime 1", Description = "Have Freetime lol. Very hard to understand", AssignedPerson = getRandomTPerson(t1), Deadline = RandomDay(), Id = RandomString() });
                p1.Tasks.Add(new ProjectTask() { Name = "Create Blazor App 1", Description = ".NET 7.0 CORE Framework needed. please install it and create blazorproject with it", AssignedPerson = getRandomTPerson(t1), Deadline = RandomDay(), Id = RandomString() });
                p1.Tasks.Add(new ProjectTask() { Name = "Create Blazor App 2", Description = ".NET 6.0 CORE Framework needed. please install it and create blazorproject with it", AssignedPerson = getRandomTPerson(t1), Deadline = RandomDay(), Id = RandomString() });

                Projects.Add(p1);


                //Project II
                Team t2 = new Team() { Description = "Die 4 netten Menschen", Id = RandomString(), members = new List<Teammember>() };

                t2.members.Add(new Teammember() { person = getRandomPerson(), Description = "Designer", Role = Teamrolle.Worker });
                t2.members.Add(new Teammember() { person = getRandomPerson(), Description = "Programmer", Role = Teamrolle.Worker });
                t2.members.Add(new Teammember() { person = Contact[0], Description = "Programmer", Role = Teamrolle.Administrator });
                t2.members.Add(new Teammember() { person = getRandomPerson(), Description = "Projektleiter", Role = Teamrolle.Projektleader });

                Project p2 = new Project() { Name = "Funky Munky", Budget = 99.50f, status = ProgressStatus.In_Progress, assignedTeam = t2, Id = 2, Tasks = new List<ProjectTask>() };

                p2.Tasks.Add(new ProjectTask() { Name = "Code Website", Description = "Make a website lol. xd. mega lol.", AssignedPerson = getRandomTPerson(t2), Deadline = RandomDay(), Id = RandomString() });
                p2.Tasks.Add(new ProjectTask() { Name = "Code Website 2", Description = "Make a website lol. xd. mega lol.", AssignedPerson = getRandomTPerson(t2), Deadline = RandomDay(), Id = RandomString() });
                p2.Tasks.Add(new ProjectTask() { Name = "Code Website 3", Description = "Make a website lol. xd. mega lol.", AssignedPerson = getRandomTPerson(t2), Deadline = RandomDay(), Id = RandomString() });
                p2.Tasks.Add(new ProjectTask() { Name = "Have FreeTime 1", Description = "Have Freetime lol. Very hard to understand", AssignedPerson = getRandomTPerson(t2), Deadline = RandomDay(), Id = RandomString() });
                p2.Tasks.Add(new ProjectTask() { Name = "Create Blazor App 1", Description = ".NET 7.0 CORE Framework needed. please install it and create blazorproject with it", AssignedPerson = getRandomTPerson(t2), Deadline = RandomDay(), Id = RandomString() });
                p2.Tasks.Add(new ProjectTask() { Name = "Create Blazor App 2", Description = ".NET 6.0 CORE Framework needed. please install it and create blazorproject with it", AssignedPerson = getRandomTPerson(t2), Deadline = RandomDay(), Id = RandomString() });

                Projects.Add(p2);

            }

            //Functions
            Person getRandomPerson()
            {
                return Contact.ToArray()[randy.Next(0, Contact.Count)];
            }
            Teammember getRandomTPerson(Team t)
            {
                return t.members.ToArray()[randy.Next(0, t.members.Count)];
            }
            DateTime RandomDay()
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(randy.Next(range));
            }
            string RandomString(int length = 8)
            {
                string ret = "";
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                ret = new string(Enumerable.Repeat(chars, length)
                        .Select(s => s[randy.Next(s.Length)]).ToArray());
                ret = new string(Enumerable.Repeat(chars, length)
                    .Select(s => s[randy.Next(s.Length)]).ToArray());
                return ret;
            }
        }
    }
}