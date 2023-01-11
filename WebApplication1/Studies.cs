namespace WebApplication1
{
    public class Studies
    {
        public Studies(string studiesMode, string StudiesName) { 
            this.studiesMode = studiesMode;
            this.studiesName = StudiesName;
        }

        public string studiesMode { get; set; }
        public string studiesName { get; set; }
    }
}
