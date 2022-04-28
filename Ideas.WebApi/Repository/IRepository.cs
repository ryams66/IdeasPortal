using Ideas.WebApi.ViewModel;
using Ideas.WebApi.Models;

namespace Ideas.WebApi.Repository
{
    public interface IRepository
    {
        Task<int> AddUser(Userdetail userdetail);
        Task<int> AddIdea(IdeaBox idea);
        Task<IdeasViewModel> GetIdeaDetail(int? ideaId);
        Task UpdateIdea(int? ideaId,IdeaBox idea);
        Task UpdateIdeaLikes(int? ideaId, IdeaBox idea);

        //Task<int> DeleteIdea(int? ideaId);

        Task<List<IdeasViewModel>> GetIdeasByDate();
        Task<List<IdeasViewModel>> GetIdeasBylikes();
       
        

        Task<int> DeleteIdea(int? ideaid);
        Task UpdateIdea(IdeaBox idea);
    }
}
