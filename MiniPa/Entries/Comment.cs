

namespace MiniPa.Entries {


    class Comment : Entry {


        private static int _idCounter;


        public bool Moderated {
            get;
            private set;
        }


        public Comment(string message) : base(++_idCounter, message) {}


        public void ToogleModeration() {
            Moderated = !Moderated; 
        }


        public override string ToString() {
            return $"ID: {ID}\nDate-time: {CreationDate}\nMessage: {Message}\nModerated: {Moderated}";
        }


    }


}
