namespace PrivateMultipleObjects
{
    class Marine
    {
        public required string LastName;
        public required string FirstName;
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

        public Marine(string lastname, string firstname, int servicenumber, bool activestatus, int dob)
        {
            _ServiceNumber = servicenumber;
            _ActiveStatus |= activestatus;
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
            Console.WriteLine($"\n\n Service Number: {GetService}\n" +
                +$"Name: {LastName} {FirstName}\n" +
                $"Date of Birth: {GetDob}\n" +
                $"Status: {status}\n");

        }
    }
    class Speciality : Marine
    {
        private string? _StationLoc;
        private int _PayGrade;

        public Speciality()
                : base()
        {
            _StationLoc = string.Empty;
            _PayGrade = 0;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
