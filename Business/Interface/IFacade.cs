using System;
using TurisLocAPI.API.Business.Interface;

namespace TurisLocAPI.API.Repository.Interface
{
    public interface IFacade
    {

        IUserBL userBL {get;}
         
    }
}