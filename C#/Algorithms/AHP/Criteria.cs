namespace AHP
{
    public class Criteria
    {
        public string? Title { get; set; }
        public double? LocalProirity { get; set; }
        public double? GlobalPriority { get; set; }
        public List<double>? GoalPriorities { get; set; }
        public double? GoalPercent { get; set; }
    }
}