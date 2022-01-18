using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assign1_LinQ.Objects;
using Assign1_LinQ.Business;

namespace Assign1_LinQ
{
    class Program
    {

        private static List<Member> InstanceList()
        {
            List<Member> ListMember = new List<Member>();
            ListMember.Add(new Member()
            {
                FirstName = "Phuc",
                LastName = "Nguyen",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(2000, 7, 7),
                IsGraduated = true,
                BirthPlace = "Hai Duong",
                PhoneNumber = "0966416708"
            });
            ListMember.Add(new Member()
            {
                FirstName = "Khoi",
                LastName = "Nguyen Trung",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1998, 9, 3),
                IsGraduated = true,
                BirthPlace = "Ha Noi",
                PhoneNumber = "0966432408"
            });
            ListMember.Add(new Member()
            {
                FirstName = "Yen",
                LastName = "Doan Vu",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2000, 4, 27),
                IsGraduated = true,
                BirthPlace = "Lang Son",
                PhoneNumber = "084227227"
            });
            ListMember.Add(new Member()
            {
                FirstName = "Hoa",
                LastName = "Dao",
                Gender = Gender.Female,
                DateOfBirth = new DateTime(2004, 4, 4),
                IsGraduated = true,
                BirthPlace = "Lao Cai",
                PhoneNumber = "084222327"
            });
            return ListMember;


        }

        static void Main(string[] args)
        {
            List<Member> ListMember = InstanceList();
            ClassWork Working = new ClassWork();
            while (true)
            {
                System.Console.WriteLine();
                Console.WriteLine("=========================================");
                Console.WriteLine("1. Return a list of members who is Male");
                Console.WriteLine("2. Return the oldest one based on “Age” ");
                Console.WriteLine("3. Return a new list that contains Full Name only");
                Console.WriteLine("4.  Return 3 lists");
                Console.WriteLine("5.  Return the first person who was born in Ha Noi");
                Console.WriteLine("0.  Exit");
                System.Console.WriteLine();
                Console.Write("Enter your choice: ");
                

                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            Console.WriteLine("1. Return a list of members who is Male");
                            //  m.ShowMale();
                            Working.PrintList(Working.GetMembersByGender(ListMember, Gender.Male));

                            break;
                        }

                    case 2:
                        {
                            Console.WriteLine("2. Return the oldest one based on “Age” ");
                            Working.GetOldestMember(ListMember).PrintInfor();

                            break;
                        }

                    case 3:
                        {
                            Console.WriteLine("3. Return a new list that contains Full Name only");
                            // m.ShowFullName();
                            foreach (var member in Working.GetFullNameofMember(ListMember))
                            {
                                System.Console.WriteLine(member);
                            }
                            break;
                        }


                    case 4:
                        {
                            Console.WriteLine("4.  Return 3 lists");
                            // cl.SlitMembersByBirthYear();
                            foreach (var list in Working.GetListSplitByAge(ListMember))
                            {
                               
                                Working.PrintList(list);
                                Console.WriteLine("_________________________________________________________________");
                            }
                            break;

                        }
                    case 5:

                        {

                            Console.WriteLine("5.  Return the first person who was born in Ha Noi");
                            //  m.PlaceHN();
                            Working.PrintList(Working.GetMembersByPlace(ListMember,Place:"Ha Noi"));
                            break;

                        }
                    case 0: Console.WriteLine("0.  Exit"); return;


                }
            }
        }


    }
}
