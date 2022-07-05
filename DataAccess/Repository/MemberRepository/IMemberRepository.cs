using BusinessObject;
using System.Collections.Generic;

namespace DataAccess.Repository.MemberRepo
{
    public interface IMemberRepository
    {
        public IEnumerable<Member> GetMembersList();
        public int GetNextMemberId();
        public bool IsAdminLogin(string email, string password);
        public Member Login(string email, string password);
        public void AddMember(Member member);
        public void UpdateMember(Member member);
        public void DeleteMember(int MemberID);
        public Member GetMember(int memberId);
        public Member GetMember(string email);
        public IEnumerable<Member> SearchMember(string name);
        public IEnumerable<Member> SearchMemberByCountry(string country, IEnumerable<Member> searchList);
        public IEnumerable<Member> SearchMemberByCity(string country, string city, IEnumerable<Member> searchList);
    }
}
