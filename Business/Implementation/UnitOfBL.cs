using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TurisLocAPI.API.Business.Implementation;
using TurisLocAPI.API.Business.Interface;
using TurisLocAPI.API.Data;
using TurisLocAPI.API.Repository.Interface;

namespace TurisLocAPI.API.Repository.Implementation
{
    public class UnitOfBL : IUnitOfBL
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfBL(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
            userBL = new UserBL(_unitOfWork, _mapper);
        }

        public IUserBL userBL { get; private set; }

    }
}