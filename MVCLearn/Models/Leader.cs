namespace MVCLearn.Models
{
    public class Leader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsVisionary { get; set; }
        public bool HasIntegrity { get; set; }
        public bool HasHumility { get; set; }
        public bool IsResilient { get; set; }
        public bool IsDecisive { get; set; }

        public bool IsLeader => IsVisionary && HasIntegrity && HasHumility && IsResilient && IsDecisive;

    }
}
