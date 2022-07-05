using BusinessObject;
using DataAccess.DAO;
using System.Collections.Generic;

namespace DataAccess.Repository.MemberRepo
{
    public class MemberRepository : IMemberRepository
    {
        public bool IsAdminLogin(string email, string password) => MemberDao.GetMemberDao.IsAdminLogin(email, password);
        public void AddMember(Member member) => MemberDao.GetMemberDao.AddMember(member);

        public void DeleteMember(int memberId) => MemberDao.GetMemberDao.Delete(memberId);

        public IEnumerable<Member> GetMembersList()
        {
            return MemberDao.GetMemberDao.GetMembersList();
        }

        public IEnumerable<Member> SearchMember(string name)
        {
            return MemberDao.GetMemberDao.SearchMember(name);
        }

        public Member Login(string email, string password)
        {
            return MemberDao.GetMemberDao.Login(email, password);
        }

        public void UpdateMember(Member member) => MemberDao.GetMemberDao.Update(member);

        public IEnumerable<Member> SearchMemberByCountry(string country, IEnumerable<Member> searchList)
        {
            return MemberDao.GetMemberDao.FilterMemberByCountry(country, searchList);
        }

        public IEnumerable<Member> SearchMemberByCity(string country, string city, IEnumerable<Member> searchList)
        {
            return MemberDao.GetMemberDao.FilterMemberByCity(country, city, searchList);
        }

        public Member GetMember(int memberId)
        {
            return MemberDao.GetMemberDao.GetMemberByMemberId(memberId);
        }

        public int GetNextMemberId()
        {
            return MemberDao.GetMemberDao.GetNextMemberId();
        }

        public Member GetMember(string email) => MemberDao.GetMemberDao.GetMemberByEmail(email);
    }
}
