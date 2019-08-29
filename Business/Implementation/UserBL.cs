using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public UserBL(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public UserDTO Login(UserLoginDTO userLoginDTO)
        {
            var user = _userRepository.GetSingle(x => x.userName == userLoginDTO.username.ToLower());

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(userLoginDTO.password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.userName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(TokenDescriptor);

            UserDTO userDTO = _mapper.Map<UserDTO>(user); ;

            userDTO.Token = tokenHandler.WriteToken(token);
            // var va= _mapper.Map<IEnumerable<UserDTO>>(List);
            return userDTO;

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

            if (_userRepository.Exist(x => x.userName == userRegisterDTO.username))
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

            _userRepository.Add(user);

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