
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDamageAssessment.Web.Api.MiddleWares
{
  public static class MiddleWareExtension
  {
    public static IApplicationBuilder UseUnitOfworkMiddleware(this IApplicationBuilder applicationBuilder)
    {
      return applicationBuilder.UseMiddleware<UnitOfWorkMiddleWare>();
    }

        public static IApplicationBuilder UseLogRequestMidleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
    }
}
