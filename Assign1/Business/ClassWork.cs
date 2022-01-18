using Assign1.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1.Business
{
    public class ClassWork : IClassManufication
    {
        public List<string> GetFullNameofMember(List<Member> members)
        {
            List<string> ListFullName = new List<string>();
            foreach (var member in members)
            {
                string FullName = member.FirstName +" "+ member.LastName;
                
                ListFullName.Add(FullName);
                
            }
            return ListFullName;
        }

        public List<List<Member>> GetListSplitByAge(List<Member> members)
        {
            List<Member> ListEqual2000 = new List<Member>();
            List<Member> ListUnder2000 = new List<Member>();
            List<Member> ListOver2000 = new List<Member>();

            foreach (var member in members)
            {
                switch (member.DateOfBirth.Year)
                {
                    case 2000: ListEqual2000.Add(member); break;
                    case >2000: ListOver2000.Add(member); break;
                    case <2000: ListUnder2000.Add(member); break;
                   
                }
            }

            return new List<List<Member>> { ListUnder2000, ListUnder2000, ListOver2000 };
        }

        public List<Member> GetMembersByGender(List<Member> members, Gender Gender)
        {
            List<Member> ListMemberbyGender = new List<Member>();
            
            foreach (var member in members)
            {
                if (member.Gender == Gender.Male) ListMemberbyGender.Add(member);
            }
            
            return ListMemberbyGender;
        }

        public List<Member> GetMembersByPlace(List<Member> members, string Place)
        {
            List<Member> ListMeberByPlace = new List<Member>();
            foreach (var member in members)
            {
                if (member.BirthPlace.Equals(Place)) ListMeberByPlace.Add(member);
            }
            return ListMeberByPlace;
            
        }

        public Member GetOldestMember(List<Member> members)
        {  
            members.Sort((m1,m2)=>DateTime.Compare(m1.DateOfBirth,m2.DateOfBirth)); // sort ascending datetime DOB, the first in list is the oldest 
            return members.ToArray()[0];
            
            
        }

        public void PrintList(List<Member> members){
            foreach (var member in members){
                member.PrintInfor();
            }
        }

        
      
    }
}
