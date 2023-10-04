namespace DI44UF_HFT_2023241.Models.Old
{
    public interface IWebSite
    {
        int Id { get; init; }
        bool SafeToCallApi { get; set; }
        string Url { get; init; }
    }
}