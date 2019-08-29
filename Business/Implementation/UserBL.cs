using System;
using AutoMapper;
using TurisLocAPI.API.Business.Interface;
using TurisLocAPI.API.DTO.User;
using TurisLocAPI.API.Models;
using TurisLocAPI.API.Repository;
using TurisLocAPI.API.Repository.Interface;

namespace TurisLocAPI.API.Business.Implementation
{
    public class UserBL : IUserBL
    {
        // private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserBL(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public UserDTO Login(string username, string password)
        {
            var user = _unitOfWork.userRepository.GetSingle(x => x.userName == username);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            // var va= _mapper.Map<IEnumerable<UserDTO>>(List);
            return _mapper.Map<UserDTO>(user);

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {

                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i > computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool Register(UserRegisterDTO userRegisterDTO)
        {

            userRegisterDTO.username = userRegisterDTO.username.ToLower();

            if (_unitOfWork.userRepository.Exist(x => x.userName == userRegisterDTO.username))
            {
                return false;
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userRegisterDTO.password, out passwordHash, out passwordSalt);

            User user = new User
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                userName = userRegisterDTO.username
            };

            _unitOfWork.userRepository.Add(user);

            _unitOfWork.Save();

            return true;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}