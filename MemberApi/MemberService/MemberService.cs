using MemberApi.Interface;
using MemberApi.Model;
using MemberApi.Repository;
using System.Reflection.Metadata.Ecma335;

namespace MemberApi
{
    public class MemberService : IMemberService
    {
        private readonly IMember _member;
        public MemberService(IMember member)
        {

            _member = member;
        }
        public List<Member> GetAllMembers()
        {
            return _member.GetAllMembers();
        }

        public Member? GetMemberbyId(int id)
        {
            return _member.GetMemberbyId(id);
        }
        public void CreateMember(Member member)
        {
            _member.CreateMember(member);
        }

        public void DeleteMember(int id)
        {
            _member.DeleteMember(id);
        }

        public void UpdateMember(Member member, int id)
        {
            _member.UpdateMember(member, id);
        }

        public Member? ValidateUser(string email, string password)
        {
            var member = _member.GetAllMembers().FirstOrDefault(m => m.Email == email && m.Password == password);
            return member;

        }
        
    }
}
