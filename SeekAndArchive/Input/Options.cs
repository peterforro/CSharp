using SeekAndArchive.Modules.Seeker;



namespace SeekAndArchive.Input {


    struct Options {


        public string rootDir;
        public string pattern;
        public string archiveDir;
        public SearchType searchType;


        public Options(string rootDir, string pattern, string archiveDir, string searchType) {
            this.rootDir = rootDir;
            this.pattern = pattern;
            this.archiveDir = archiveDir;
            SearchType.TryParse(searchType,true,out this.searchType);

        }


    }


}
