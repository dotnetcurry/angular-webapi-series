using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Models
{
    public class UserStoriesRepository : IDisposable
    {
        private ProjectTrackingDBEntities dataContext;

        public UserStoriesRepository()
        {
            dataContext = new ProjectTrackingDBEntities();
        }

        public List<UserStory> GetAllUserStories()
        {
            var query = from us in dataContext.UserStories
                        select us;
            return query.ToList();
        }
        public UserStory GetUserStory(int UserStoryID)
        {
            var query = from us in dataContext.UserStories
                        where us.UserStoryID==UserStoryID
                        select us;
            return query.SingleOrDefault();
        }
        public List<UserStory> InsertUserStory(UserStory us)
        {
            dataContext.UserStories.Add(us);
            dataContext.SaveChanges();
            return GetAllUserStories();
        }
        public List<UserStory> UpdateUserStory(UserStory oldUS)
        {
            var userStory = (from us in dataContext.UserStories
                        where us.UserStoryID == oldUS.UserStoryID
                        select us).SingleOrDefault();
            userStory.Story = oldUS.Story;            
            dataContext.SaveChanges();
            return GetAllUserStories();
        }
        public List<UserStory> DeleteUserStory(UserStory oldUS)
        {
            var userStory = (from us in dataContext.UserStories
                             where us.UserStoryID == oldUS.UserStoryID
                             select us).SingleOrDefault();
            dataContext.UserStories.Remove(userStory);
            dataContext.SaveChanges();
            return GetAllUserStories();
        }



        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}