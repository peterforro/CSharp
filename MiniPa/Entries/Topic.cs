using System.Collections.Generic;


namespace MiniPa.Entries {


    class Topic : Entry {


        private static int _idCounter;
        private string Title;


        public List<Comment> Comments {
            get {
                var tmp = new List<Comment>();
                foreach (var comment in Comments) {
                    if (comment.Moderated) {
                        tmp.Add(comment);
                    }
                }
                return tmp;
            }
            private set { }
        }


        public Topic(string title, string message) : base(++_idCounter, message ) {
            Comments = new List<Comment>(); 
            Title = title;
        }


        public void AddComment(Comment comment) {
            Comments.Add(comment);
        }


        public override string ToString() {
            return $"ID: {ID}\nDate-time: {CreationDate}\nTitle: {Title}\nMessage: {Message}\n";
        }


    }


}
