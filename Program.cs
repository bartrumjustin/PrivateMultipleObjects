namespace PrivateMultipleObjects
{
    public class Marine
    {
        public string? LastName;
        public string? FirstName;
        private int _ServiceNumber;
        private int _DOB;
        private bool _ActiveStatus;

        //default construtor
        public Marine()
        {
            LastName = string.Empty;
            FirstName = string.Empty;
            _ServiceNumber = 0;
            _ActiveStatus = false;
            _DOB = 0;

        }

        //paramaritized constructor

        public Marine(int servicenumber, bool activestatus, int dob, string lastname, string firstname)
        {
            _ServiceNumber = servicenumber;
            _ActiveStatus = activestatus;
            _DOB = dob;
            LastName = lastname;
            FirstName = firstname;
        }

        //set methods

        public void SetService(int servicenumber) { _ServiceNumber = servicenumber; }
        public void SetActive(bool active) { _ActiveStatus = active; }
        public void SetDob(int dob) { _DOB = dob; }

        //get methods
        public int GetService() { return _ServiceNumber; }
        public bool GetActive() { return _ActiveStatus; }
        public int GetDob() { return _DOB; }

        //Add method

        public virtual void addChange()
        {
            Console.WriteLine("Enter Service Number:\n");
            SetService(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter Last Name:");
            LastName = Console.ReadLine();
            Console.WriteLine("Enter First Name:");
            FirstName = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth (DDMMYYYY)");
            SetDob(int.Parse(Console.ReadLine()));
            Console.WriteLine("Enter Active Status (Y for Active | N for Reserve/other)");
            char ans = char.Parse(Console.ReadLine());
            bool invalid = false;
            do
            {
                if (char.ToUpper(ans) == 'Y')
                {
                    SetActive(true);
                    invalid = false;
                }
                else if (char.ToUpper(ans) != 'N')
                {
                    invalid = true;
                    Console.WriteLine("Enter Y or N");
                    ans = char.Parse(Console.ReadLine());
                }
                else
                {
                    invalid = false;
                }
            } while (invalid == true);
        }
        public virtual void Print()
        {
            string status = string.Empty;
            if (GetActive() == true)
            {
                status = "Active Duty";
            }
            else
            {
                status = "Reserve / Other status";
            }
            Console.WriteLine($"\n\nService Number: {GetService()}\n"
                + $"Name: {LastName} {FirstName}\n" +
                $"Date of Birth: {GetDob()}\n" +
                $"Status: {status}\n");

        }
    }
    public class Speciality : Marine
    {   //enum
        public enum Rate
        {
            PVT = 1,
            PFC,
            LCpl,
            Cpl,
            Sgt,
            SSgt,
            GySgt,
            MSgt,
            MGySgt,
            SgtMaj

        }
        //var
        private string? _StationLoc;
        private int _PayGrade;

        //deafult
        public Speciality()
                : base()
        {
            _StationLoc = string.Empty;
            _PayGrade = 0;
        }

        //param 

        public Speciality(int servicenumber, bool activestatus, int dob, string lastname, string firstname, string? stationloc, int paygrade)
            : base(servicenumber, activestatus, dob, lastname, firstname)
        {
            _StationLoc = stationloc;
            _PayGrade = paygrade;
        }
        //set
        public void SetStatLoc(string stationloc)
        {
            _StationLoc = stationloc;
        }
        public void SetPayGrade(int paygrade)
        {
            _PayGrade = paygrade;
        }
        //get
        public string GetStatLoc()
        {
            return _StationLoc;
        }
        public int GetPayGrade()
        {
            return _PayGrade;
        }
        public override void addChange()
        {
            base.addChange();
            Console.WriteLine("Enter Station Location:");
            SetStatLoc(Console.ReadLine());
            Console.WriteLine("Enter Pay Grade (1-10)");
            SetPayGrade(int.Parse(Console.ReadLine()));
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Station Location: {GetStatLoc()}\n");
            Rate payToRate = (Rate)GetPayGrade();
            Console.WriteLine($"Pay Grade / Pay Rate : {payToRate} / {GetPayGrade()}\n");
        }



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter amount of service members to be recorded:");
            int amt;
            while (!int.TryParse(Console.ReadLine(), out amt))
                Console.WriteLine("Please enter a whole number");

            Marine[] marines = new Marine[amt];
            Console.WriteLine("Enter the amount of specialized members:");
            int amt2;
            while (!int.TryParse(Console.ReadLine(), out amt2))
                Console.WriteLine("Please enter a whole number");

            Speciality[] spc = new Speciality[amt2];

            int choice, rec, type;
            int marinesCount = 0, spcCount = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("Enter 1 for specialized marine or 2 for marine");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("1 for marine or 2 for specialized marine");
                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (type == 1)
                            {
                                if (spcCount <= amt2)
                                {
                                    spc[spcCount] = new Speciality();
                                    spc[spcCount].addChange();
                                    spcCount++;
                                }
                                else
                                    Console.WriteLine("Amount has been satisfied");

                            }
                            else
                            {
                                if (marinesCount <= amt)
                                {
                                    marines[marinesCount] = new Marine();
                                    marines[marinesCount].addChange();
                                    marinesCount++;
                                }
                                else
                                    Console.WriteLine("Amount has been satisfied");

                            }

                            break;
                        case 2:
                            Console.Write("Enter the Index number that will be modified: ");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter the Index number: ");
                            rec--;
                            if (type == 1)
                            {
                                while (rec > spcCount - 1 || rec < 0)
                                {
                                    Console.Write("Not within range");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the Index number: ");
                                    rec--;
                                }
                                spc[rec].addChange();
                            }
                            else
                            {
                                while (rec > marinesCount - 1 || rec < 0)
                                {
                                    Console.Write("Not within range");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter the Index number: ");
                                    rec--;
                                }
                                marines[rec].addChange();
                            }
                            break;
                        case 3:
                            if (type == 1)
                            {
                                for (int i = 0; i < spcCount; i++)
                                    spc[i].Print();
                            }
                            else
                            {
                                for (int i = 0; i < marinesCount; i++)
                                    marines[i].Print();
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid selection made");
                            break;
                    }
                }


                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }


        private static int Menu()
        {
            Console.WriteLine("Select from the following:\n" +
                "| 1-Add | 2-Change | 3-Print | 4-Quit |\n");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("| 1-Add | 2-Change | 3-Print | 4-Quit |");
            return selection;
        }
    }
}



