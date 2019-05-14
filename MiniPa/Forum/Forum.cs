using System.Collections.Generic;
using MiniPa.Entries;



namespace MiniPa.Forum {


    class Forum {


        private static Forum _instance;
        private List<Topic> topics = new List<Topic>();


        private static Forum GetInstance() {
            if (_instance == null) {
                _instance = new Forum();
            }
            return _instance;
        }


        private Forum() { }


        public void AddTopic(Topic topic) {
            topics.Add(topic);
        }


    }


}
