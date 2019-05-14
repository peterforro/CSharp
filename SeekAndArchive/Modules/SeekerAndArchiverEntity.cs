using SeekAndArchive.Control;


namespace SeekAndArchive.Modules {

    abstract class SeekerAndArchiverEntity {

        protected readonly FileSeekerAndArchiver controller;

        protected SeekerAndArchiverEntity(FileSeekerAndArchiver controller) {
            this.controller = controller;
        }
    }
}
