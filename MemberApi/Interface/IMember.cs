using MemberApi.Model;

namespace MemberApi.Interface
{
    public interface IMember
    {
        public List<Member> GetAllMembers();
        public Member? GetMemberbyId(int id);
        public void CreateMember(Member member);
        public void UpdateMember(Member member, int id);
        public void DeleteMember(int id);



    }
}
