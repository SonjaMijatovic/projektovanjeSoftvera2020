namespace PSV.Model
{
    public class Recipe
    {
        public User Patient { get; set; }
        public Medicine Medicine { get; set; }
        public double Amount { get; set; }
    }
}