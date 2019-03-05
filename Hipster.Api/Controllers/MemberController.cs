using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hipster.ApplicationService.Dto.Request;
using Hipster.ApplicationService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hipster.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly ILogger _logger;
        public MemberController(IMemberService memberService,ILoggerFactory loggerFactory){
            _memberService=memberService;
            _logger=loggerFactory.CreateLogger<MemberController>();
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            return Ok(_memberService.GetMember(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] CreateMemberRequest request)
        {
            var response=_memberService.CreateMember(request);
            return Ok(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id)
        {
            var response=_memberService.UpdateMember(id);
            return Ok(response);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
