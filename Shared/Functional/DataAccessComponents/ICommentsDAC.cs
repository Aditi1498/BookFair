using System.Collections.Generic;

namespace Shared
{
    public interface ICommentsDAC : IDataAccessComponent
    {
        CommentsDTO AddComment(CommentsDTO commentsDTO);

        List<CommentsDTO> ViewComments(int eventId);

    }
}
