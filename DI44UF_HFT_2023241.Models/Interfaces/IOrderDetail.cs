namespace DI44UF_HFT_2023241.Models
{
    public interface IOrderDetail
    {
        int OrderId { get; set; }
        int OrderItemId { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }
    }
}