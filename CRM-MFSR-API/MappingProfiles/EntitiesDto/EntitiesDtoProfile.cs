using AutoMapper;
using CRM_MFSR_API.Models.Dtos.Entities;
using Entities.Models;

namespace CRM_MFSR_API.MappingProfiles.EntitiesDto
{
    /// <summary>
    /// User mapper profile User/UserDto.
    /// </summary>
    public class EntitiesDtoProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public EntitiesDtoProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles)).ReverseMap();
            CreateMap<UserRole, UserRoleDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role)).ReverseMap();
            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.UserRoles, opt => opt.MapFrom(src => src.UserRoles)).ReverseMap();
            CreateMap<RolePermission, RolePermissionDto>()
                .ForMember(dest=>dest.Role, opt=>opt.MapFrom(src=>src.Role))
                .ForMember(dest=>dest.Permission, opt=>opt.MapFrom(src=>src.Permission)).ReverseMap();
            CreateMap<Permission, PermissionDto>()
                .ForMember(dest => dest.RolePermissions, opt => opt.MapFrom(src => src.RolePermissions)).ReverseMap();
        }
    }
}
