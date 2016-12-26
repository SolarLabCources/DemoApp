using AutoMapper;
using BusinessLogic.Objects;
using DataAccessLayer.Objects;

namespace BusinessLogic.Implementation
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<AddPostDto, Post>()
                                        .ForMember(p => p.Description, opt => opt.ResolveUsing(dto => dto.Description + " (Description)"))
                                        .ForMember(p => p.Title, opt => opt.ResolveUsing(dto => dto.Title + " (Title)")));
        }
    }
}
