using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace studentinformation
{
    public class all
    {

        //first menu display
        public void display()
        {
            int choice;
            Console.WriteLine("Student Information System using CSharp");
            Console.WriteLine();
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Add New User");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            //choosing number in menu
            if(choice == 1)
            {
                Console.Clear();
                login();
            } else if(choice == 2)
            {
                Console.Clear();
                addUser();
            } else if(choice == 3)
            {
                Console.ReadKey();
            }
        }

        //dashboard display
        public void display1()
        {
            int choice;
            Console.WriteLine("              Welcome to Student Information System Dashboard");
            Console.WriteLine();
            Console.WriteLine("          --Mission--                                --Vision--");
            Console.WriteLine("   Lorem ipsum dolor sit amet               consectetur adipiscing elit");
            Console.WriteLine(" sed do eiusmod tempor incididunt          ut labore et dolore magna aliqua");
            Console.WriteLine("      Ut enim ad minim veniam                       quis nostrud");
            Console.WriteLine(" exercitation ullamco laboris nisi        ut aliquip ex ea commodo consequat");
            Console.WriteLine();
            Console.WriteLine(" ---------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(" Dash Board Menu");
            Console.WriteLine(" 1. Add Student");
            Console.WriteLine(" 2. Search Student");
            Console.WriteLine(" 3. Update Student");
            Console.WriteLine(" 4. Back to Menu");
            Console.WriteLine(" -------------------");
            Console.Write(" Enter number choice: ");
            choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                Console.Clear();
                addStudent();
            } else if(choice == 2)
            {
                Console.Clear();
                searchStudent();
            } else if(choice == 3)
            {
                Console.Clear();
                updateStudent();
            }
        }
        
        //add admin user
        public void addUser()
        {
            string username = string.Empty,password = string.Empty;
            string path = "C:\\Users\\Briñas\\Desktop\\Reset PC\\studentinformation\\login\\login.txt";
            int choice;

            //type username and password
            Console.WriteLine("Add User");
            Console.WriteLine();
            Console.Write("Enter Username: ");
            username = Console.ReadLine();
            Console.Write("Enter Password: ");
            password = Console.ReadLine();

            //passing the text to textfile
            List<string> lines = File.ReadAllLines(path).ToList();
            lines.Add(username);
            lines.Add(password);
            File.WriteAllLines(path, lines);

            //if success
            Console.WriteLine("Done adding user..");
            Console.WriteLine("--------------------");
            Console.Write("Login[1], Add New User [2]?: ");
            choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                Console.Clear();
                login();
            } else if (choice == 2)
            {
                Console.Clear();
                addUser();
            }
        }

        //login
        public void login()
        {
            string username, password, username1, password1 = string.Empty;
            int choice;
            Console.WriteLine("Login Form");
            Console.WriteLine();

            //input ng username at password
            Console.Write("Enter Username: ");
            username = Console.ReadLine();
            Console.Write("Enter Password: ");
            password = Console.ReadLine();

            //kapag nabasa na merong ganung text
            using (StreamReader sr = new StreamReader(File.Open("C:\\Users\\Briñas\\Desktop\\Reset PC\\studentinformation\\login\\login.txt", FileMode.Open)))
            {
                username1 = sr.ReadLine();
                password1 = sr.ReadLine();
                sr.Close();
            }

            if(username == username1 && password == password1)
            {
                Console.Clear();
                display1();
            } else
            {
                Console.WriteLine("Login Failed!");
                Console.Write("Login Again[1], Back[2]: ");
                choice = int.Parse(Console.ReadLine());
                if(choice == 1)
                {
                    Console.Clear();
                    login();
                } else if(choice == 2)
                {
                    Console.Clear();
                    display();
                }
            }
        }

        //addStudent
        public void addStudent()
        {
            string[] sNumber = new string[100];
            string[] sName = new string[100];
            string[] sGender = new string[100];
            string[] sAge = new string[100];
            string[] eAddress = new string[100];
            string studentnumber;
            int choice,number;

            Console.WriteLine(" Add Student");
            Console.WriteLine();
            Console.Write(" Enter amount of student you want to register: ");
            number = int.Parse(Console.ReadLine());

            //loop para kong ilang studyante gusto iadd
            for(int i=0;i<number;i++)
            {
                Console.WriteLine();
                Console.Write(" Enter Student Number: ");
                sNumber[i] = Console.ReadLine();
                Console.Write(" Enter Student Name: ");
                sName[i] = Console.ReadLine();
                Console.Write(" Enter Student Gender: ");
                sGender[i] = Console.ReadLine();
                Console.Write(" Enter Student Age: ");
                sAge[i] = Console.ReadLine();
                Console.Write(" Enter Student Email Address: ");
                eAddress[i] = Console.ReadLine();
                Console.Write(" Enter Student Code: ");
                studentnumber = Console.ReadLine();
                //gagawan ng sariling .txt kada student na mareregister
                using (StreamWriter sw = new StreamWriter(File.Create("C:\\Users\\Briñas\\Desktop\\Reset PC\\studentinformation\\students\\" + studentnumber + ".txt")))
                {
                    sw.Close();
                    //ilalagay na .txt file nya yung text na niregister mo sa student
                    string path = "C:\\Users\\Briñas\\Desktop\\Reset PC\\studentinformation\\students\\" + studentnumber + ".txt";
                    List<string> lines = File.ReadAllLines(path).ToList();
                    lines.Add(sNumber[i]);
                    lines.Add(sName[i]);
                    lines.Add(sGender[i]);
                    lines.Add(sAge[i]);
                    lines.Add(eAddress[i]);
                    File.WriteAllLines(path, lines);
                }
            }
            Console.Clear();
            //display naten yung ininput naten na data
            for(int j=0;j<number;j++)
            {
                Console.WriteLine(" -- Student Information --");
                Console.WriteLine(" Student Number: " + sNumber[j]);
                Console.WriteLine(" Student Name: " + sName[j]);
                Console.WriteLine(" Student Gender: " + sGender[j]);
                Console.WriteLine(" Student Age: " + sAge[j]);
                Console.WriteLine(" Student Email Address: " + eAddress[j]);
                Console.WriteLine();
            }

            //lalabas kapag na display na lahat ng data na nainput mo
            Console.WriteLine("Add Student[1], Dash Board[2]: ");
            choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                Console.Clear();
                addStudent();
            } else if(choice == 2)
            {
                Console.Clear();
                display1();
            }

        }

        //mag uupdate na tayo ng student sawakas hahaha
        public void updateStudent()
        {
            //lagay muna naten yung mga kailangan naten
            //gawin naten string
            string sNumber;
            string sName;
            string sGender;
            string sAge;
            string eAddress;
            int studentnumber;
            int choice;

            Console.WriteLine(" Update Student");
            Console.Write(" Enter Student Code you want to Update: ");
            studentnumber = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write(" Enter New Student Number: ");
            sNumber = Console.ReadLine();
            Console.Write(" Enter New Student Name: ");
            sName = Console.ReadLine();
            Console.Write(" Enter New Student Gender: ");
            sGender = Console.ReadLine();
            Console.Write(" Enter New Student Age: ");
            sAge = Console.ReadLine();
            Console.Write(" Enter New Student Email Address: ");
            eAddress = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(File.Create("C:\\Users\\Briñas\\Desktop\\Reset PC\\studentinformation\\students\\" + studentnumber + ".txt")))
            {
                sw.Close();
                string path = "C:\\Users\\Briñas\\Desktop\\Reset PC\\studentinformation\\students\\" + studentnumber + ".txt";
                List<string> lines = File.ReadAllLines(path).ToList();
                lines.Add(sNumber);
                lines.Add(sName);
                lines.Add(sGender);
                lines.Add(sAge);
                lines.Add(eAddress);
                File.WriteAllLines(path, lines);
            }
            Console.WriteLine(" Processing.....");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine();
            Console.WriteLine(" Student is now updated!");
            Console.Write(" Update New Student[1], Dash Board[2]: ");
            choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                Console.Clear();
                updateStudent();
            } else if(choice == 2)
            {
                Console.Clear();
                display1();
            }
        }

        public void searchStudent()
        {
            string studentnumber,path,first,second,third,fourth,fifth;
            int choice;
            Console.WriteLine(" Search Student");
            Console.WriteLine();
            Console.Write(" Enter Student code: ");
            studentnumber = Console.ReadLine();
            Console.WriteLine(" Searching in database.....");
            System.Threading.Thread.Sleep(7000);
            path = "C:\\Users\\Briñas\\Desktop\\Reset PC\\studentinformation\\students\\" + studentnumber + ".txt";
            using(StreamReader sr = new StreamReader(path))
            {
                first = sr.ReadLine();
                second = sr.ReadLine();
                third = sr.ReadLine();
                fourth = sr.ReadLine();
                fifth = sr.ReadLine();
                Console.WriteLine();
                Console.WriteLine(" -- Student Information --");
                Console.WriteLine(" Student Number: " + first);
                Console.WriteLine(" Student Name: " + second);
                Console.WriteLine(" Student Gender: " + third);
                Console.WriteLine(" Student Age: " + fourth);
                Console.WriteLine(" Student Email Address: " + fifth);
                sr.Close();
            }
            Console.WriteLine();
            Console.Write(" Search Again[1], Dash Board[2]: ");
            choice = int.Parse(Console.ReadLine());
            if(choice == 1)
            {
                Console.Clear();
                searchStudent();
            } else if(choice == 2)
            {
                Console.Clear();
                display1();
            }
        }
    }
}
