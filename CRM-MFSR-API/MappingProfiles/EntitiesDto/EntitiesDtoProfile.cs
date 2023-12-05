using AutoMapper;
using CRM_MFSR_API.Models.Dtos.Entities;
using Entities.Models.Developments;
using Entities.Models.Users;

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
            //Users
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
            //Development
            CreateMap<Development, DevelopmentDto>()
                .ForMember(dest=>dest.Stages, opt=>opt.MapFrom(src=>src.Stages)).ReverseMap();
            CreateMap<Stage, StageDto>()
                .ForMember(dest => dest.Development, opt => opt.MapFrom(src => src.Development))
                .ForMember(dest => dest.Lots, opt => opt.MapFrom(src => src.Lots)).ReverseMap();
            CreateMap<Lot, LotDto>()
                .ForMember(dest=>dest.Category, opt=>opt.MapFrom(src=>src.Category))
                .ForMember(dest => dest.Stage, opt => opt.MapFrom(src => src.Stage)).ReverseMap();
            CreateMap<LotCategory, LotCategoryDto>()
                .ForMember(dest => dest.Lots, opt => opt.MapFrom(src => src.Lots)).ReverseMap();

        }
    }
}
