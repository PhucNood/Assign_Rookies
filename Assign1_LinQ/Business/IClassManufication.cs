using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assign1_LinQ.Objects;

namespace Assign1_LinQ.Business
{
  public  interface IClassManufication
    {
        List<Member> GetMembersByGender(List<Member> members,Gender Gender);
        Member GetOldestMember(List<Member> members);
        List<string> GetFullNameofMember(List<Member> members) ;
      List<List<Member>>  GetListSplitByAge(List<Member> members);       
        List<Member> GetMembersByPlace(List<Member> members ,string Place);
       void PrintList(List<Member> members);
    }
}
