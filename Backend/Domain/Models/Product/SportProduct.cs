namespace SmartTrade.Models
{
    public partial class SportProduct : Product
    {
        public SportProduct() : base()
        {
            Category = SmartTrade.Models.Category.Sport;
        }
    }
}
