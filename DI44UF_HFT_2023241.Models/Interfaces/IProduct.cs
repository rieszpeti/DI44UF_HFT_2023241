namespace DI44UF_HFT_2023241.Models
{
    public interface IProduct
    {
        string Description { get; init; }
        int Id { get; init; }
        string Name { get; init; }
        string Size { get; set; }
    }
}