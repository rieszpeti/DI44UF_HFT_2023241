namespace DI44UF_HFT_2023241.Models
{
    public interface IRole
    {
        int ActorId { get; set; }
        int MovieId { get; set; }
        int Priority { get; set; }
        int RoleId { get; set; }
        string RoleName { get; set; }
    }
}