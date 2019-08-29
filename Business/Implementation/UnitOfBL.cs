using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public UnitOfBL(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            userBL = new UserBL(_unitOfWork, _mapper, _configuration);
        }

        public IUserBL userBL { get; private set; }

    }
}