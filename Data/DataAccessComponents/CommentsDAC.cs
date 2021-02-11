using EntityDataModel.Converter;
using EntityDataModel.EntityModel;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.DataAccessComponents
{
    class CommentsDAC : DACBase, ICommentsDAC
    {
        public CommentsDAC() : base(DACType.CommentsDAC)
        {

        }

        //Add new Comment
        public CommentsDTO AddComment(CommentsDTO commentsDTO)
        {
            Comments comment = new Comments();
            try
            {
                using (BookContext db = new BookContext())
                {
                    EntityConverter.FillEntityFromDTO(commentsDTO, comment);
                    comment.User= db.Users.Where(user => user.UserId == comment.UserId).SingleOrDefault();
                    comment.UserName = comment.User.Name;
                    db.Comments.Add(comment);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return commentsDTO;
        }

        //View All the Comments on an event
        public List<CommentsDTO> ViewComments(int eventId)
        {
            List<Comments> comments = new List<Comments>();
            List<CommentsDTO> commentsDTOs = new List<CommentsDTO>();
            try
            {
                using (BookContext db = new BookContext())
                {
                    comments = db.Comments.Where(c => c.EventId == eventId).ToList();
                    foreach(var temp in comments)
                    {
                        CommentsDTO commentsDTO = new CommentsDTO();
                        EntityConverter.FillDTOFromEntity(temp, commentsDTO);
                        commentsDTOs.Add(commentsDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return commentsDTOs;
        }
    }
}
