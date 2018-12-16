using CarDamageAssessment.ApplicationCore.Interfaces;
using CarDamageAssessment.ApplicationCore.Interfaces.Repositories;
using CarDamageAssessment.ApplicationCore.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarDamageAssessment.Web.Api.MiddleWares
{
  public class UnitOfWorkMiddleWare
  {

    private readonly RequestDelegate _requestDelegate;
    private IUnitOfWork _unitOfWork;
    private IUserRepository _userRepository;


    public UnitOfWorkMiddleWare(RequestDelegate requestDelegate)
    {
      _requestDelegate = requestDelegate;
    }

    
    
    public async Task Invoke(HttpContext httpContext, IUnitOfWork unitOfWork,IUserRepository userRepository)
    {
      try
      {

        if(httpContext.Request.Method == "POST" || httpContext.Request.Method == "PUT")
        {



          _unitOfWork = unitOfWork;

          _unitOfWork.Begin();

         
          
          await _requestDelegate(httpContext);

          _unitOfWork.Commit();

        }
        else
        {
          await _requestDelegate(httpContext);

        }
        
      }
      catch (Exception e)
      {
        _unitOfWork.RollBack();

      }


    }
  }
}
