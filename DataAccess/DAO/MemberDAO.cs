using BusinessObject;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataAccess.DAO
{
    public class MemberDao
    {
        private static MemberDao _instance;
        private static readonly object InstanceLook = new object();

        public static MemberDao GetMemberDao
        {
            get
            {
                lock (InstanceLook)
                {
                    return _instance ??= new MemberDao();
                }
            }
        }


        public bool IsAdminLogin(string email, string password)
        {
            try
            {
                if (email == null || password == null)
                {
                    return false;
                }

                if (email.Trim().Length == 0 || password.Trim().Length == 0)
                {
                    return false;
                }

                using StreamReader streamReader = new StreamReader("appsettings.json");
                streamReader.ReadToEnd();
                IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
                string adminEmail = config["account:defaultAccount:email"];
                string adminPassword = config["account:defaultAccount:password"];
                return adminEmail.ToLower().Equals(email.ToLower()) && adminPassword.Equals(password);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public IEnumerable<Member> GetMembersList()
        {
            try
            {
                return  new SalesManagementContext().Members;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Member Login(string email, string password)
        {
            IEnumerable<Member> members = GetMembersList();
            return  members.SingleOrDefault(mb => mb.Email.Equals(email) && mb.Password.Equals(password));
        }

        public Member GetMemberByMemberId(int memberId)
        {
            try
            {
                return new SalesManagementContext().Members.SingleOrDefault(mem => mem.MemberId == memberId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Member GetMemberByEmail(string memberEmail)
        {
            try
            {
               return new SalesManagementContext().Members.SingleOrDefault(mem => mem.Email.ToLower().Equals(memberEmail.ToLower()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetNextMemberId()
        {

            try
            {
                return new SalesManagementContext().Members.Max(mem => mem.MemberId) + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public void AddMember(Member member)
        {
            if (member == null)
            {
                throw new Exception("Member is undefined!!");
            }
            try
            {
                if (GetMemberByMemberId(member.MemberId) == null && GetMemberByEmail(member.Email) == null)
                {
                    var context = new SalesManagementContext();
                    context.Members.Add(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Member is existed!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Member member)
        {
            if (member == null)
            {
                throw new Exception("Can't search this member!");
            }
            try
            {
                Member memberExistByMemberId = GetMemberByMemberId(member.MemberId);
                if (memberExistByMemberId == null)
                {
                    throw new Exception("Member does not exist!!");
                }

                Member memberExistByEmail = GetMemberByEmail(member.Email);
                if (memberExistByEmail == null || memberExistByEmail.MemberId == memberExistByMemberId.MemberId)
                {
                    SalesManagementContext salesManagementContext =  new SalesManagementContext();
                    salesManagementContext.Members.Update(member);
                    salesManagementContext.SaveChanges();
                    return;
                }
                else
                {
                    throw new Exception("Email already user by another account.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Delete(int memberId)
        {
            try
            {
                Member member = GetMemberByMemberId(memberId);
                if (member != null)
                {
                    var context = new SalesManagementContext();
                    context.Members.Remove(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Member does not exist!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Member> SearchMember(string name)
        {
            try
            {
                return new SalesManagementContext().Members.Where(mem => mem.Fullname.ToLower().Contains(name.ToLower()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Member> FilterMemberByCountry(string country, IEnumerable<Member> searchList = null)
        {
            if (searchList == null)
            {
                return searchList;
            }
            if (country.Equals("All"))
            {
                return searchList;
            } 
            return from member in searchList
                where member.Country == country
                select member;
        }

        public IEnumerable<Member> FilterMemberByCity(string country, string city, IEnumerable<Member> searchList)
        {
            IEnumerable<Member> resultFilterByCountry = FilterMemberByCountry(country, searchList.ToList());
            if (city.Equals("All"))
            {
                return resultFilterByCountry;
            }

            return resultFilterByCountry.Where(member => member.City == city);
        }
    }
}
