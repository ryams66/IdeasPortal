using AutoMapper;
using Ideas.WebApi.ViewModel;
using Ideas.WebApi.Models;
namespace Ideas.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<IdeasViewModel, IdeaBox>()
                .ForMember(d => d.IdeaId, o => o.MapFrom(s => s.IdeaId))
                .ForMember(d => d.IdeaMesaage, o => o.MapFrom(s => s.IdeaMesaage))
                .ForMember(d => d.IdeaPosteddate, o => o.MapFrom(s => s.IdeaPosteddate))
                .ForMember(d => d.IdeaUserid, o => o.MapFrom(s => s.IdeaUserid))
                //.ForMember(d => d.IdeaUserName, o => o.MapFrom(s => s.IdeaUserName))
                .ForMember(d => d.Liked, o => o.MapFrom(s => s.liked))
                .ForMember(d => d.IdeaTag, o => o.MapFrom(s => s.IdeaTag));
        }

    }
}
