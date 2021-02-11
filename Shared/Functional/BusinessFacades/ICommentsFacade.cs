using System.Collections.Generic;

namespace Shared
{
    public interface ICommentsFacade : IFacade
    {
        OperationResult<CommentsDTO> AddComment(CommentsDTO commentsDTO);

        List<CommentsDTO> ViewComments(int eventId);

    }
}
