namespace DI44UF_HFT_2023241.Models
{
    public interface IWebSite
    {
        int Id { get; init; }
        string SafeToCrawl { get; set; }
        string Url { get; init; }
    }
}