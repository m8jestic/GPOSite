namespace GPOSite.Models
{
    public class Algorithm
    { 
        public string OEIS_ID { get; set; }
        public string Information { get; set; } 
        public int Number { get; set; }
        public bool Empty
        {
            get
            {
                return (string.IsNullOrWhiteSpace(OEIS_ID) &&
                          string.IsNullOrWhiteSpace(Information) &&
                          Number == 0);
            }
        }
    }
}
