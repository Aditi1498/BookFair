using Shared;
using System;
using System.Collections.Generic;

namespace Business.Business
{
    class CommentsBDC : BDCBase, ICommentsBDC
    {
        public CommentsBDC() : base(BDCType.CommentsBDC)
        {

        }

        //Add new Comment by User
        public OperationResult<CommentsDTO> AddComment(CommentsDTO commentsDTO)
        {
            OperationResult<CommentsDTO> result = null;
            try
            {
                ICommentsDAC commentsDAC = (ICommentsDAC)DACFactory.Instance.Create(DACType.CommentsDAC);
                CommentsDTO resultDTO = commentsDAC.AddComment(commentsDTO);
                if (resultDTO != null)
                {

                    result = OperationResult<CommentsDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    result = OperationResult<CommentsDTO>.CreateFailureResult("User With This email address does not exists");
                }
            }
            catch (DACException dacEx)
            {
                result = OperationResult<CommentsDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception e)
            {
                result = OperationResult<CommentsDTO>.CreateErrorResult(e.Message, e.StackTrace);
            }
            return result;
        }


        //View All Comments
        public List<CommentsDTO> ViewComments(int eventId)
        {
            ICommentsDAC commentsDAC = (ICommentsDAC)DACFactory.Instance.Create(DACType.CommentsDAC);
            return commentsDAC.ViewComments(eventId);
        }
    }
}
