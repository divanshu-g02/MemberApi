using MemberApi.Interface;
using MemberApi.Repository;
using MemberApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace MemberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _members;
        public MembersController(IMemberService member)
        {
            _members = member;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_members.GetAllMembers());
        }

        [HttpGet("{id}")]
        public ActionResult<Member> GetById(int id)
        {
            return Ok(_members.GetMemberbyId(id));
        }

        [HttpPost]
        public  IActionResult Post(Member member)
        {
            try
            {
                _members.CreateMember(member);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Member member, int id)
        {
            try
            {
                _members.UpdateMember(member, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _members.DeleteMember(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
