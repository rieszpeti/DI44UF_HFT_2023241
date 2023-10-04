using DI44UF_HFT_2023241.Models;
using System.Linq;

namespace DI44UF_HFT_2023241.Repository
{
    public class RoleRepository : Repository<Role>, IRepository<Role>
    {
        public RoleRepository(MovieDbContext ctx) : base(ctx)
        {
        }

        public override Role Read(int id)
        {
            return ctx.Roles.FirstOrDefault(t => t.RoleId == id);
        }

        public override void Update(Role item)
        {
            var old = Read(item.RoleId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
