using AutoMapper;
using Curso.Dtos;
using Curso.Models;

namespace Curso.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //post or create
            CreateMap<ProductCreateDto, Product>();
            //put or update
            CreateMap<ProductUpdateDto, Product>();
            //get o list
            CreateMap<Product,ProductToListDto>();

            CreateMap<UserRegisterDto,User>();
            CreateMap<UserLoginDto,User>();
            CreateMap<User,UserListDto>();
        }
    }
}