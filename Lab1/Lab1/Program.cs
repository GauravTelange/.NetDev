using System;

namespace Lab1
{
    class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Records : ");
            int numrecord = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numrecord; i++)
            {


                try
                {
                    Person obj = new Person();

                    //string Name = "";
                    //int Age = 0;

                    Console.WriteLine("Enter Name:");
                    obj.Name = Console.ReadLine();
                    Console.WriteLine("Enter Age: ");
                    obj.Age = Convert.ToInt16(Console.ReadLine());
                    if (obj.Valid())
                    {
                        System.Console.WriteLine("Name : " + obj.Name + " Age :" + obj.Age);
                    }
                    else
                    {
                        System.Console.WriteLine("Please Enter a Valid Data");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid Data");
                }
            }
            Console.ReadLine();
        }
    }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public bool Valid()
            {

                if (Name.Length == 0)
                {
                    return false;
                }
                if (Age >= 100)
                {

                    return false;
                }
                return true;
            }

        }
 }