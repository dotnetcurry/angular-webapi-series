using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackingServices.Models
{
    public class ManagerCommentsRepository
    {
        private static ProjectTrackingDBEntities dataContext = new ProjectTrackingDBEntities();
        public static List<ManagerComment> GetAllManagerComments()
        {
            var query = from comments in dataContext.ManagerComments
                        select comments;
            return query.ToList();
        }
        public static ManagerComment GetManagerComment(int ManagerCommentID)
        {
            var query = from comments in dataContext.ManagerComments
                        where comments.ManagerCommentID==ManagerCommentID
                        select comments;
            return query.SingleOrDefault();
        }
        public static List<ManagerComment> InsertManagerComments(ManagerComment comment)
        {
            dataContext.ManagerComments.Add(comment);
            dataContext.SaveChanges();
            return GetAllManagerComments();
        }
        public static List<ManagerComment> UpdateManagerComments(ManagerComment comment)
        {
            var managerComment = (from comments in dataContext.ManagerComments
                        where comments.ManagerCommentID == comment.ManagerCommentID
                        select comments).SingleOrDefault();
            managerComment.Comments = comment.Comments;
            dataContext.SaveChanges();
            return GetAllManagerComments();
        }
        public static List<ManagerComment> DeleteManagerComments(ManagerComment comment)
        {
            dataContext.ManagerComments.Remove(comment);
            dataContext.SaveChanges();
            return GetAllManagerComments();
        }
    }
}