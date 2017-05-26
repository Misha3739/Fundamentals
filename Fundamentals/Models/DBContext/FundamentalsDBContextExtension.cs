using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Antlr.Runtime.Misc;
using AutoMapper;
using Fundamentals.Models.DTO;
using Microsoft.Ajax.Utilities;

namespace Fundamentals.Models.DBContext
{
    public static class FundamentalsDBContextExtension
    {
        public static IEnumerable<UserInRolesDto> UserInRolesDtos(this FundamentalsDBContext context)
        {
            return context.Database.SqlQuery<UserInRolesDto>("select * from dbo.UserInRolesDto");

        }

        
    }
}