using Shared;
using System.Collections.Generic;

namespace BusinessFacades.Facades
{
    class CommentsFacade : FacadeBase, ICommentsFacade
    {
        public CommentsFacade() : base(FacadeType.CommentsFacade)
        {

        }

        public OperationResult<CommentsDTO> AddComment(CommentsDTO commentsDTO)
        {
            ICommentsBDC commentsBDC = (ICommentsBDC)BDCFactory.Instance.Create(BDCType.CommentsBDC);
            return commentsBDC.AddComment(commentsDTO);
        }


        public List<CommentsDTO> ViewComments(int eventId)
        {
            ICommentsBDC commentsBDC = (ICommentsBDC)BDCFactory.Instance.Create(BDCType.CommentsBDC);
            return commentsBDC.ViewComments(eventId);
        }
    }
}
