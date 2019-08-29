using System;
using Microsoft.EntityFrameworkCore;
using TurisLocAPI.API.Business.Implementation;
using TurisLocAPI.API.Business.Interface;
using TurisLocAPI.API.Data;
using TurisLocAPI.API.Repository.Interface;

namespace TurisLocAPI.API.Repository.Implementation
{
    public class UnitOfBL : IUnitOfBL
    {

        public UnitOfBL(IUserBL _user)
        {
            userBL= _user;
        }


        public IUserBL userBL {get; private set; }

    }
}