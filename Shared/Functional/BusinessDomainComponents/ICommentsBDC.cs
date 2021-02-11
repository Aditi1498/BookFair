using System.Collections.Generic;

namespace Shared
{
    public interface ICommentsBDC : IBusinessDomainComponent
    {
        OperationResult<CommentsDTO> AddComment(CommentsDTO commentsDTO);

        List<CommentsDTO> ViewComments(int eventId);
    }
}
