namespace WebApi
{
    public class OrderSystemOptions
    {
        public const string SectionName = "OrderSystem";
        public string AppName { get; set; } = string.Empty;
        public int MaxOrderItemsPerOrder { get; set; }
        public bool EnableEmailNotification { get; set; }
    }
}