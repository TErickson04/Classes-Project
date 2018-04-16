using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;



namespace Classes1
{
    class Program
    {
        private static int birthDay;
        private static int birthYear;
        private static int birthMonth;

        static void Main(string[] args)
        {
            string fName, address, lName, state, country, phoneNumber, cellPhoneNumber, relationship, company, position, email;
            int option, zipCode;
            bool check;



            do
            {
                //Menu options
                WriteLine("1. Create a Friend / Family entry \n2. Create a Business Contact entry \n3. Quit");
                Write("Choose option 1, 2, or 3:  ");
                while (!int.TryParse(ReadLine(), out option))
                {
                    Write("Invalid Option, try again:  ");
                };
                WriteLine();
                //Start Base Class
                Contact contact = new Contact();
                if (option == 1)
                {
                    do
                    {
                        //Set Flag
                        check = false;
                        //Get First Name (Required to enter something)  STRING
                        Write("First name (req'd):  ");
                        fName = ReadLine();
                        for (int i = 0; i < fName.Length; i++)
                        {
                            if (fName[i] >= 'a' && fName[i] <= 'z')
                            {
                                check = true;
                                contact.FirstName = fName;
                            }
                            else
                            {
                                check = false;
                            }
                        }
                    }
                    while (check == false);
                    do
                    {
                        //Set Flag
                        check = false;
                        //Get Last Name (Required to enter something)  STRING
                        Write("Last name (req'd):  ");
                        lName = ReadLine();
                        for (int i = 0; i < lName.Length; i++)
                        {
                            if (lName[i] >= 'a' && lName[i] <= 'z')
                            {
                                check = true;
                                contact.LastName = lName;
                            }
                            else
                            {
                                check = false;
                            }
                        }
                    }
                    while (check == false);
                    //Get Address (if enter is hit, address is N/A)  STRING
                    Write("Street Address (or Enter if N/A):  ");
                    address = ReadLine();

                    if (address == "")
                    {
                        address = "N/A";
                        contact.Address = address;

                    }
                    else
                    {
                        contact.Address = address;
                    }

                    //Get State (if enter is hit, state is N/A)  STRING
                    Write("State (or Enter if N/A):  ");
                    state = ReadLine();
                    if (state == "")
                    {
                        state = "N/A";
                        contact.State = state;
                    }
                    else
                    {
                        contact.State = state;
                    }

                    //Get Zip Code (if enter is hit, zip code is 0)  INT
                    Write("Zip Code (or Enter if no Zip Code):  ");
                    int.TryParse(ReadLine(), out zipCode);
                    contact.ZipCode = zipCode;

                    //Get Country (if enter is hit, zip code is N/A)  STRING
                    if (state == "N/A")
                    {
                        Write("Country (or Enter if N/A):  ");
                        country = ReadLine();

                        if (country == "")
                        {
                            country = "N/A";
                            contact.Country = country;
                        }
                        else
                        {
                            contact.Country = country;
                        }
                    }
                    else
                    {
                        country = "USA";
                        contact.Country = country;
                    }
                    

                    //Get LandLine Phone Number (if enter is hit, phone number is N/A)  STRING
                    Write("Phone number - land line (or Enter if N/A):  ");
                    phoneNumber = ReadLine();

                    if (phoneNumber == "")
                    {
                        phoneNumber = "N/A";
                        contact.PhoneNumber = phoneNumber;
                    }
                    else
                    {
                        contact.PhoneNumber = phoneNumber;
                    }

                    //Get Cell Phone Number (if enter is hit, phone number is N/A)  STRING
                    Write("Phone number - cell phone (or Enter if N/A):  ");
                    cellPhoneNumber = ReadLine();

                    if (cellPhoneNumber == "")
                    {
                        cellPhoneNumber = "N/A";
                        contact.CellPhoneNumber = cellPhoneNumber;
                    }
                    else
                    {
                        contact.CellPhoneNumber = cellPhoneNumber;
                    }
                    
                    //Start Child Class (FamilyContact)
                    FamilyContact fam = new FamilyContact();
                    //Family Contact Menu
                    WriteLine();
                    WriteLine("Relationship choices:");
                    WriteLine();
                    Write("\t(SP) Spouse \n\t(C) Child \n\t(P) Parent \n\t(S) Sibling \n\t(Enter) Other");
                    Write("Relationship to you (Key in letter or Enter):  ");
                    relationship = ReadLine();
                    // Set Relationship for FamilyContact child class
                    if (relationship == "SP" || relationship == "sp")
                    {
                        fam.Relationship = "Spouse";
                    }
                    else if(relationship == "C" || relationship == "c")
                    {
                        fam.Relationship = "Child";
                    }
                    else if(relationship == "P" || relationship == "p")
                    {
                        fam.Relationship = "Parent";
                    }
                    else if(relationship == "S" || relationship == "s")
                    {
                        fam.Relationship = "Sibling";
                    }
                    else
                    {
                        fam.Relationship = "Other";
                    }

                    // Get Birthday information
                    Write("Month of Birthday (or Enter if not entering birthday):  ");
                    int.TryParse(ReadLine(), out birthMonth);
                    if (birthMonth != 0)
                    {
                        if (birthMonth > 0 && birthMonth < 13)
                        {

                            do
                            {
                                Write("Day of Birthday, between 1 - 31 (req'd):  ");
                                while (!int.TryParse(ReadLine(), out birthDay))
                                {
                                    Write("Day of Birthday required:  ");
                                };

                            }
                            while (birthDay < 1 || birthDay > 32);

                            do
                            {
                                Write("4-digit Year of Birthday (req'd):  ");
                                while (!int.TryParse(ReadLine(), out birthYear))
                                {
                                    Write("4-digit Year of Birthday required:  ");
                                }
                            }
                            while (birthYear < 1000 || birthYear > 9999);
                            fam.BirthMonth = birthMonth;
                            fam.BirthDay = birthDay;
                            fam.BirthYear = birthYear;

                            //Display Family/Friend child class information
                            DateTime birthDate = new DateTime(fam.BirthYear, fam.BirthMonth, fam.BirthDay);
                            WriteLine();
                            WriteLine("Family - Friend entry:");
                            WriteLine();
                            WriteLine("Name: {0} {1}", contact.FirstName, contact.LastName);
                            WriteLine("Address: {0}", contact.Address);
                            WriteLine("State: {0}", contact.State);
                            WriteLine("Country: {0}", contact.Country);
                            WriteLine("Land line number: {0}", contact.PhoneNumber);
                            WriteLine("Cell number: {0}", contact.CellPhoneNumber);
                            WriteLine();
                            WriteLine("Relationship: {0}", fam.Relationship);
                            WriteLine("Birthday: {0}", birthDate.ToString("MM/dd/yyyy"));
                            WriteLine("10 days before birthday: {0}", birthDate.AddDays(-10).ToString("MM/dd/yyyy"));
                        }
                        else
                        {
                            do
                            {
                                Write("Month of Birthday (or Enter if not entering birthday):  ");
                                int.TryParse(ReadLine(), out birthMonth);
                            }
                            while (birthMonth < 1 || birthMonth > 12);

                            do
                            {
                                Write("Day of Birthday, between 1 - 31 (req'd):  ");
                                while (!int.TryParse(ReadLine(), out birthDay))
                                {
                                    Write("Day of Birthday required:  ");
                                };

                            }
                            while (birthDay < 1 || birthDay > 31);

                            do
                            {
                                Write("4-digit Year of Birthday (req'd):  ");
                                while (!int.TryParse(ReadLine(), out birthYear))
                                {
                                    Write("4-digit Year of Birthday required:  ");
                                }
                            }
                            while (birthYear < 1000 || birthYear > 9999);
                            fam.BirthMonth = birthMonth;
                            fam.BirthDay = birthDay;
                            fam.BirthYear = birthYear;

                            //Display Family/Friend child class information
                            DateTime birthDate = new DateTime(fam.BirthYear, fam.BirthMonth, fam.BirthDay);
                            WriteLine();
                            WriteLine("Family - Friend entry:");
                            WriteLine();
                            WriteLine("Name: {0} {1}", contact.FirstName, contact.LastName);
                            WriteLine("Address: {0}", contact.Address);
                            WriteLine("State: {0}", contact.State);
                            WriteLine("Country: {0}", contact.Country);
                            WriteLine("Land line number: {0}", contact.PhoneNumber);
                            WriteLine("Cell number: {0}", contact.CellPhoneNumber);
                            WriteLine();
                            WriteLine("Relationship: {0}", fam.Relationship);
                            WriteLine("Birthday: {0}", birthDate.ToString("MM/dd/yyyy"));
                            WriteLine("10 days before birthday: {0}", birthDate.AddDays(-10).ToString("MM/dd/yyyy"));

                        }
                    }                    
                    else
                    {
                        WriteLine("Name: {0}{1}", contact.FirstName, contact.LastName);
                        WriteLine("Address: {0}", contact.Address);
                        WriteLine("State: {0}", contact.State);
                        WriteLine("Country: {0}", contact.Country);
                        WriteLine("Land line number: {0}", contact.PhoneNumber);
                        WriteLine("Cell number: {0}", contact.CellPhoneNumber);
                        WriteLine();
                        WriteLine("Relationship: {0}", fam.Relationship);
                    }
                    WriteLine();
                    WriteLine("Press Enter to continue...");
                    ReadLine();

                }
                else if (option == 2)
                {
                    do
                    {
                        //Set Flag
                        check = false;
                        //Get First Name (Required to enter something)  STRING
                        Write("First name (req'd):  ");
                        fName = ReadLine();
                        for (int i = 0; i < fName.Length; i++)
                        {
                            if (fName[i] >= 'a' && fName[i] <= 'z')
                            {
                                check = true;
                                contact.FirstName = fName;
                            }
                            else
                            {
                                check = false;
                            }
                        }
                    }
                    while (check == false);
                    do
                    {
                        //Set Flag
                        check = false;
                        //Get Last Name (Required to enter something)  STRING
                        Write("Last name (req'd):  ");
                        lName = ReadLine();
                        for (int i = 0; i < lName.Length; i++)
                        {
                            if (lName[i] >= 'a' && lName[i] <= 'z')
                            {
                                check = true;
                                contact.LastName = lName;
                            }
                            else
                            {
                                check = false;
                            }
                        }
                    }
                    while (check == false);
                    //Get Address (if enter is hit, address is N/A)  STRING
                    Write("Address (or Enter if N/A):  ");
                    address = ReadLine();

                    if (address == "")
                    {
                        address = "N/A";
                        contact.Address = address;

                    }
                    else
                    {
                        contact.Address = address;
                    }

                    //Get State (if enter is hit, state is N/A)  STRING
                    Write("State (or Enter if N/A):  ");
                    state = ReadLine();
                    if (state == "")
                    {
                        state = "N/A";
                        contact.State = state;
                    }
                    else
                    {
                        contact.State = state;
                    }

                    //Get Zip Code (if enter is hit, zip code is 0)  INT
                    Write("Zip Code (or Enter if no Zip Code):  ");
                    int.TryParse(ReadLine(), out zipCode);
                    contact.ZipCode = zipCode;

                    //Get Country (if enter is hit, zip code is N/A)  STRING
                    if (state == "N/A")
                    {
                        Write("Country (or Enter if N/A):  ");
                        country = ReadLine();

                        if (country == "")
                        {
                            country = "N/A";
                            contact.Country = country;
                        }
                        else
                        {
                            contact.Country = country;
                        }
                    }
                    else
                    {
                        country = "USA";
                        contact.Country = country;
                    }


                    //Get LandLine Phone Number (if enter is hit, phone number is N/A)  STRING
                    Write("Phone number - land line (or Enter if N/A):  ");
                    phoneNumber = ReadLine();

                    if (phoneNumber == "")
                    {
                        phoneNumber = "N/A";
                        contact.PhoneNumber = phoneNumber;
                    }
                    else
                    {
                        contact.PhoneNumber = phoneNumber;
                    }

                    //Get Cell Phone Number (if enter is hit, phone number is N/A)  STRING
                    Write("Phone number - cell phone (or Enter if N/A):  ");
                    cellPhoneNumber = ReadLine();

                    if (cellPhoneNumber == "")
                    {
                        cellPhoneNumber = "N/A";
                        contact.CellPhoneNumber = cellPhoneNumber;
                    }
                    else
                    {
                        contact.CellPhoneNumber = cellPhoneNumber;
                    }
                    WriteLine();

                    // Start child class Business
                    Business bus = new Business();

                    // Set company name for child class Business
                    Write("Company name (or Enter for ACME Yarn and Supplies):  ");
                    company = ReadLine();
                    if (company == "")
                    {
                        company = "ACME Yarn and Supplies";
                        bus.CompanyName = company;
                    }
                    else
                    {
                        bus.CompanyName = company;
                    }

                    //Set position for child class Business
                    Write("Position (or Enter if N/A):  ");
                    position = ReadLine();
                    if (position == "")
                    {
                        position = "N/A";
                        bus.Position = position;
                    }
                    else
                    {
                        bus.Position = position;
                    }

                    //Set email for child class Business
                    if (company == "ACME Yarn and Supplies")
                    {
                        email = "sales@ACMEYarn.com";
                        bus.Email = email;
                    }
                    else
                    {
                        Write("Email:  ");
                        email = ReadLine();
                        bus.Email = email;
                    }

                    // Display Business child class information
                    WriteLine();
                    WriteLine("Business entry:");
                    WriteLine();
                    WriteLine("Name: {0} {1}", contact.FirstName, contact.LastName);
                    WriteLine("Address: {0}", contact.Address);
                    WriteLine("State: {0}", contact.State);
                    WriteLine("Country: {0}", contact.Country);
                    WriteLine("Land line number: {0}", contact.PhoneNumber);
                    WriteLine("Cell number: {0}", contact.CellPhoneNumber);
                    WriteLine();
                    WriteLine("Company:  {0}", bus.CompanyName);
                    WriteLine("Position:  {0}", bus.Position);
                    WriteLine("Email:  {0}", bus.Email);
                    WriteLine();
                    WriteLine("Press Enter to continue...");
                    ReadLine();
                    
                }
                else if (option == 3)
                {
                    Environment.Exit(0);
                }
                WriteLine();
                
            }
            while (option != 3);

        }
        
        
    }
    
    class Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public int ZipCode { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string CellPhoneNumber { get; set; }

    }

    class FamilyContact : Contact
    {
        public string Relationship { get; set; }

        public int BirthMonth { get; set; }

        public int BirthDay { get; set; }

        public int BirthYear { get; set; }
    }

    class Business : Contact
    {
        public string CompanyName { get; set; }

        public string Position { get; set; }

        public string Email { get; set; }
    }

}
