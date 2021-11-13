﻿using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entity.Concrate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ICustomerInfoServices _customerService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserService _userService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper,
             IUserOperationClaimService userOperationClaimService, ICustomerInfoServices customerService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
            _customerService = customerService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
          
            _userService.Add(user);
            var users = _userService.GetByMail(user.Email);
            _userOperationClaimService.AddUserClaim(user);
            var newCustomer = new CustomerInfo { UserId = users.Id, PhoneNumber = $"{userForRegisterDto.PhoneNumber}",FindeksScore=userForRegisterDto.FindeksScore,Address=userForRegisterDto.Address};
            _customerService.Add(newCustomer);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult IsAuthenticated(string userMail, List<string> requiredRoles)
        {
            throw new NotImplementedException();
        }
    }
}
