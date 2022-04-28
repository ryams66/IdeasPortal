using Ideas.WebApi.Models;
using Ideas.WebApi.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Ideas.WebApi.Repository
{
    public class Repository:IRepository
    {
        PRT_IDEAsContext db;
        public Repository(PRT_IDEAsContext _db)
        {
            db = _db;
        }
        public async Task<List<IdeasViewModel>> GetIdeasByDate()
        {
            if (db != null)
            {
                var result= await (from p in db.IdeaBoxes
                                      from c in db.Userdetails
                                      //where p.CategoryId == c.Id
                                      select new IdeasViewModel
                                      {
                                          IdeaId = p.IdeaId,
                                          IdeaTag = p.IdeaTag,
                                          IdeaMesaage = p.IdeaMesaage,
                                          IdeaPosteddate = p.IdeaPosteddate,
                                          IdeaUserid = p.IdeaUserid,
                                          IdeaUserName = c.Username
                                      }).OrderByDescending(d=>d.IdeaPosteddate).ToListAsync();
                if (result is not null)
                {
                    return result;
                }

            }

            return null;
        }
        public async Task<List<IdeasViewModel>> GetIdeasBylikes()
        {
            if (db != null)
            {
                return await (from p in db.IdeaBoxes
                              from c in db.Userdetails
                                  //where p.CategoryId == c.Id
                              select new IdeasViewModel
                              {
                                  IdeaId = p.IdeaId,
                                  IdeaTag = p.IdeaTag,
                                  IdeaMesaage = p.IdeaMesaage,
                                  IdeaPosteddate = p.IdeaPosteddate,
                                  IdeaUserid = p.IdeaUserid,
                                  IdeaUserName = c.Username,
                                  liked=p.Liked
                              }).OrderByDescending(d => d.liked).ToListAsync();
            }

            return null;
        }
        public async Task<int> AddIdea(IdeaBox post)
        {
            if (db != null)
            {
                await db.IdeaBoxes.AddAsync(post);
                await db.SaveChangesAsync();

                return post.IdeaId;
            }

            return 0;
        }
        public async Task<int> AddUser(Userdetail userdetails)
        {
            if (db != null)
            {
                await db.Userdetails.AddAsync(userdetails);
                await db.SaveChangesAsync();

                return userdetails.Userid;
            }

            return 0;
        }
        public async Task<IdeasViewModel> GetIdeaDetail(int? ideaId)
        {
            if (db != null)
            {
                var result= await (from p in db.IdeaBoxes
                                   from c in db.Userdetails
                                   where p.IdeaId == ideaId
                                   select new IdeasViewModel
                                   {
                                       IdeaId = p.IdeaId,
                                       IdeaMesaage = p.IdeaMesaage,
                                       IdeaPosteddate = p.IdeaPosteddate,
                                       IdeaTag = p.IdeaTag,
                                       IdeaUserid = p.IdeaUserid,
                                       IdeaUserName = c.Username,
                                       liked = p.Liked

                                   }).FirstOrDefaultAsync();
                if (result is not null)
                { return result; }
            }

            return null;
        }

        //public void Save(Author author)
        //{
        //    context.Entry(author).State = EntityState.Modified;
        //    context.SaveChanges();
        //}
        public async Task UpdateIdea(int? id,IdeaBox idea)
        {
            if (db != null)
            {
                var result = await db.IdeaBoxes.FirstOrDefaultAsync(x => x.IdeaId == idea.IdeaId);
                
                if (result != null)
                {
                    result.IdeaMesaage = idea.IdeaMesaage;
                    result.IdeaTag = idea.IdeaTag;
                    db.Entry(result).State = EntityState.Modified;

                    //db.IdeaBoxes.Update(result);
                }

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateIdeaLikes(int? id, IdeaBox idea)
        {
            if (db != null)
            {
                var result = await db.IdeaBoxes.FirstOrDefaultAsync(x => x.IdeaId == idea.IdeaId);

                if (result != null)
                {
                    result.Liked = idea.Liked+1;                    
                    db.Entry(result).State = EntityState.Modified;

                    //db.IdeaBoxes.Update(result);
                }

                //Commit the transaction
                await db.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteIdea(int? ideaId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var idea = await db.IdeaBoxes.FirstOrDefaultAsync(x => x.IdeaId == ideaId);

                if (idea != null)
                {
                    db.Entry(idea).State = EntityState.Deleted;
                    //Delete that post
                   // db.IdeaBoxes.Remove(idea);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public Task UpdateIdea(IdeaBox idea)
        {
            throw new NotImplementedException();
        }
    }
}
