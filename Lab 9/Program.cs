using System;
using System.Collections.Generic;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            const string INPUT_CHECK = @"\w\s+";
            // set a constant int to the number of students
            const int NUMBER_OF_STUDENTS = 20;
            // 2d array of students and their info
            List<string> favColors = new List<string>()
            {
                { "gray" },
                { "red" },
                { "blue" },
                { "yellow" },
                { "pink" },
                { "orange" },
                { "purple" },
                { "green" },
                { "lavender" },
                { "orangered" },
                { "beige" },
                { "yellowgreen" },
                { "hunter green" },
                { "royal blue" },
                { "gunmetal gray" },
                { "perfect black" },
                { "ultra indigo" },
                { "tan" },
                { "brown" },
                { "maroon" },
            };
            List<string> favFoods = new List<string>()
            {
                { "pizza" },
                { "cheese" },
                { "chips" },
                { "candy" },
                { "ice" },
                { "lasagna" },
                { "dumplings" },
                { "rice" },
                { "pasta" },
                { "pizza" },
                { "pizza" },
                { "pizza" },
                { "donuts" },
                { "pizza" },
                { "steak" },
                { "food" },
                { "donuts" },
                { "tequilla" },
                { "cheese steak" },
                { "yogurt" }
            };
            List<string> hometowns = new List<string>()
            {
                { "Waterbury" },
                { "Scranton" },
                { "Alpena" },
                { "Grand Rapids" },
                { "Naugatuck" },
                { "Detroit" },
                { "Lansing" },
                { "Prospect" },
                { "Torrington" },
                { "Cheshire" },
                { "LA" },
                { "New York" },
                { "San Francisco" },
                { "Chicago" },
                { "Austin" },
                { "Houston" },
                { "Boston" },
                { "Miami" },
                { "Philly" },
                { "Burbank" }
            };
            List<string> students = new List<string>()
            {
                { "Alvin Chipmunk" },
                { "Bob Smith" },
                { "Barbara Smith" },
                { "Bill Rogers" },
                { "Clementine Bauch" },
                { "Chelsey Dietrich" },
                { "Clementina DuBuque" },
                { "Chuck" },
                { "Dennis Schulist" },
                { "Ervin Howell" },
                { "Glenna Reichrt" },
                { "Holly Barry" },
                { "John Doe" },
                { "Jane Doe" },
                { "Kurtis Weissnat" },
                { "Leanne Graham" },
                { "Michael Cacciano" },
                { "Nicholas Runolfsdottir" },
                { "Patricia Lebsack" },
                { "Simon Chipmunk" }
            };
            // flag to keep program running in while loop
            bool isRunning = true;

            while (isRunning)
            {
                Console.Write("Welcome to our C# class. Which would you like to do? (Add) or (Find) a student? : ");
                string addOrFind = Console.ReadLine().ToLower();
                if (addOrFind == "add")
                {
                    AddStudent(students, hometowns, favFoods, favColors);
                }
                else if(addOrFind == "find")
                {
                    var studentId = GetStudentID(students);
                    for (int i = 0; i < students.Count; i++)
                    {
                        if (studentId == i + 1)
                        {
                            var hometown = hometowns[i];
                            var favFood = favFoods[i];
                            var favColor = favColors[i];
                            DisplayStudentInfo(studentId, students[i], hometown, favFood, favColor);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Sorry but you either didn't add that student, input nothing, or entered some information about the student incorrectly");
                }
                // if user does not want to look up another student end program else run program from start
                if (!RunAgain())
                {
                    Console.WriteLine("Thanks! o/");
                    isRunning = false;
                }
            }
        }
        // method to display the specified user info, if invalid query calls itself recursively
        private static void DisplayStudentInfo(int studentIndex, string studentName, string hometown, string favFood, string favColor)
        {
            // if user input  matches display index position and username then ask what info they would like
            Console.WriteLine($"Student {studentIndex} is {studentName}. What would you like to know about {studentName}?\n(enter or \"hometown\" or \"favorite food\" \"favorite color\")");
            // store request response for info
            var infoRequested = Console.ReadLine();
            // if info requested matches data stored display corresponding response
            if (infoRequested == "hometown")
            {
                Console.WriteLine($"{studentName}'s hometown is {hometown}.");
            }
            else if (infoRequested == "favorite food")
            {
                Console.WriteLine($"{studentName}'s favorite food is {favFood}.");
            }
            else if (infoRequested == "favorite color")
            {
                Console.WriteLine($"{studentName}'s favorite color is {favColor}.");
            }
            else
            {
                Console.WriteLine("That data does not exist. Pleast try again.(enter 'hometown', 'favorite food', 'favorite color')");
                // if invalid input display error message and call this function recursively
                DisplayStudentInfo(studentIndex, studentName, hometown, favFood, favColor);
            }
        }
        private static void AddStudent(List<string> students,List<string> hometowns, List<string> favFoods, List<string> favColors)
        {
            Console.WriteLine("Enter student's full name");
            var studentName = Console.ReadLine();
            int studentNameIndex;
            if (!string.IsNullOrWhiteSpace(studentName))
            {
                students.Insert(students.Count, studentName);
                students.Sort();
            }
            studentNameIndex = students.IndexOf(studentName);
            Console.WriteLine("Enter student's hometown");
            var hometown = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(hometown))
            {
                hometowns.Insert(studentNameIndex, hometown);
            }
            Console.WriteLine("Enter student's favorite food");
            var favFood = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(favFood))
            {
                favFoods.Insert(studentNameIndex, favFood);
            }
            Console.WriteLine("Enter students favorite color");
            var favColor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(favColor))
            {
                favColors.Insert(studentNameIndex, favColor);
            }
            else
            {
                Console.WriteLine("Sorry but all information must be filled out");
            }
        }
        // method to get the user id as well as validate is int, if invalid query calls itself recursively
        private static int GetStudentID(List<string> students)
        {
            Console.WriteLine("Please enter a student id");
            var studentIndex = Console.ReadLine();
            // try parse to check if the user input is actually a number then check for the range
            if (int.TryParse(studentIndex, out int studentId) && studentId > 0 && studentId < (students.Count + 1))
            {
                return studentId;
            }
            else
            {
                Console.WriteLine("Sorry but there is no student with that Id. Enter a valid Id or start over and add a student.");
                return GetStudentID(students);
            }


        }
        // method to ask the user if they would like to look up another student
        private static bool RunAgain()
        {
            Console.WriteLine("Would you like to Add or find another student? (y/n)");
            var yOrNo = Console.ReadLine().ToLower();
            if (yOrNo.StartsWith('y'))
            {
                return true;
            }
            else if (yOrNo.StartsWith('n'))
            {
                return false;
            }
            else
            {
                RunAgain();
                return false;
            }
        }

    }
}