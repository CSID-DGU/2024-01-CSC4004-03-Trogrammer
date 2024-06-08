namespace MyApiProject.Models
{
    public class Food
    {
        public string Name { get; set; }
        public float Amount { get; set; }
        public string Unit { get; set; }
        public float Price { get; set; }

        public Food()
        {
            Name = string.Empty;
            Unit = string.Empty;
        }
    }
}
