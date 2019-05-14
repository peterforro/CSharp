using System;



namespace MiniPa.Entries {


    abstract class Entry {


        protected int ID;
        protected DateTime CreationDate { get; }
        protected string Message { get; }


        protected Entry(int id, string message) {
            ID = id;
            Message = message;
            CreationDate = DateTime.Now;
        }

        
    }


}
