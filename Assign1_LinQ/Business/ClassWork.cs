using Assign1_LinQ.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1_LinQ.Business
{
    public class ClassWork : IClassManufication
    {
        public List<string> GetFullNameofMember(List<Member> members)
        {
            var ListFullName = from member in members select(member.FirstName+" "+member.LastName);
            
            return ListFullName.ToList();
        }

        public List<List<Member>> GetListSplitByAge(List<Member> members)
        {
            List<Member> ListEqual2000 = (from member in members where member.DateOfBirth.Year==2000 select member).ToList();
            List<Member> ListUnder2000 = (from member in members where member.DateOfBirth.Year<2000 select member).ToList();
            List<Member> ListOver2000 = (from member in members where member.DateOfBirth.Year>2000 select member).ToList();
            // c2
           // var ListEqual2000 = (members.Where(m => m.DateOfBirth.Year==2000).ToList();
         // var ListUnder2000 = (members.Where(m => m.DateOfBirth.Year<2000).ToList();
         // var ListOver2000 = (members.Where(m => m.DateOfBirth.Year>2000).ToList();
            return new List<List<Member>>{ListEqual2000, ListUnder2000, ListOver2000};
        }

        public List<Member> GetMembersByGender(List<Member> members, Gender Gender)
        {
            
            var ListMemberbyGender = members.Where(m => m.Gender == Gender.Male).ToList();
           // c2 var ListMemberbyGender= (from member in members where member.Gender == Gender.Female select member).ToList();
            
            return ListMemberbyGender;
        }

        public List<Member> GetMembersByPlace(List<Member> members, string Place)
        {
            List<Member> ListMeberByPlace = (from member in members where member.BirthPlace.ToLower().Equals("ha noi") select member).ToList();
            
            return ListMeberByPlace;
            
        }

        public Member GetOldestMember(List<Member> members)
        {  
            // sort ascending datetime DOB, the last in list is the oldest 
          //c1 var oldest = members.OrderByDescending(m => m.DateOfBirth).LastOrDefault();
          //c2 var oldest =(from member in members orderby member.DateOfBirth ascending select member).FirstOrDefault();
         var oldest = (Member)(from member in members where member.DateOfBirth == members.Max(m => m.DateOfBirth) select member); // c3
            return oldest == null ? new Member() : oldest;
            
            
        }

        public void PrintList(List<Member> members){
            foreach (var member in members){
                member.PrintInfor();
            }
        }

        
      
    }
}
