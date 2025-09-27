using System;

namespace YouTubeVideos
{
    public class Comment
    {
        private string _commenterName;
        private string _commentText;

        public Comment(string commenterName, string commentText)
        {
            _commenterName = commenterName;
            _commentText = commentText;
        }

        public string CommenterName
        {
            get { return _commenterName; }
        }

        public string CommentText
        {
            get { return _commentText; }
        }
    }
}
