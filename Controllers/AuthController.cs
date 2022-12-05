using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Curso.Data.Interfaces;
using Curso.Dtos;
using Curso.Models;
using Curso.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Curso.Controllers
{
    [ApiController]
     [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
         private readonly IAuthRepository _repo;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthController(IMapper mapper, IAuthRepository repo, ITokenService tokenService)
        {
            _mapper = mapper;
            _repo = repo;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto usuarioDto)
        {
            // validate request

            usuarioDto.Email = usuarioDto.Email.ToLower();

            if (await _repo.ExistUser(usuarioDto.Email))
                return BadRequest("Usuario con ese correo ya existe");


            var usuarioToCreate = _mapper.Map<User>(usuarioDto);

            var UsuarioCreated = await _repo.Register(usuarioToCreate, usuarioDto.Password);

            var UsuarioReturn = _mapper.Map<UserListDto>(UsuarioCreated);

            return Ok(UsuarioReturn);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto usuarioLoginDto)
        {
            var usuarioFromRepo = await _repo.Login(usuarioLoginDto.Email.ToLower(), usuarioLoginDto.Password);

            if (usuarioFromRepo == null)
                return Unauthorized("null");


            var usuario = _mapper.Map<UserListDto>(usuarioFromRepo);

            return Ok(new
            {
                token = _tokenService.CreateToken(usuarioFromRepo),
                usuario
            });
        }
    }
}