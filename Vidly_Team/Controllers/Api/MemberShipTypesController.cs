using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Vidly_Team.Models;

namespace Vidly_Team.Controllers.Api
{
    [EnableCors("*", "*", "*")]
    public class MemberShipTypesController : ApiController
    {
        private ApplicationDbContext _context;

        public MemberShipTypesController()
        {
             _context = new ApplicationDbContext();
        }
        //Get : /api/MemberShipTypes
        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }
        //Get : /api/MembershipTypes/1
        public MembershipType GetMembershipType(int id )
        {
            var memberShipType= _context.MembershipTypes.SingleOrDefault(m => m.Id == id);
            return memberShipType;
        }


    }
}
