namespace AHP
{
    public class Component
    {
        public List<Criteria>? Criterias { get; set; }

        public Component? ParentComponent { get; set; }
        public Component? ChildComponent { get; set; }

        public Component()
        {
            Criterias = new List<Criteria>();
        }
    }
}
