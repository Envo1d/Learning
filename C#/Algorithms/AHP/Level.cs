namespace AHP
{
    public class Level
    {
        public List<Component>? Components { get; set; }
        public List<Level> Levels { get; set; }

        public Level? ParentLevel { get; set; }
        public Level? ChildLevel { get; set; }
        public bool IsAlternativeLevel { get; set; }

        public Level()
        {
            Components = new List<Component>();
            Levels = new List<Level>();
            IsAlternativeLevel = false;
        }
    }
}
