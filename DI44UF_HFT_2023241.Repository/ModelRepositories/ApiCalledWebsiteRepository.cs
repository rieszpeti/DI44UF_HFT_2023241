using DI44UF_HFT_2023241.Models;
using System.Linq;

namespace DI44UF_HFT_2023241.Repository
{
    public class ApiCalledWebsiteRepository : Repository<ApiCalledWebsite>, IRepository<ApiCalledWebsite>
    {
        public ApiCalledWebsiteRepository(ApiCallerDbContext ctx) : base(ctx)
        {
        }

        public override ApiCalledWebsite Read(int id)
        {
            return null;
            //return ctx.WebSite.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(ApiCalledWebsite item)
        {
            //var old = Read(item.ActorId);
            //foreach (var prop in old.GetType().GetProperties())
            //{
            //    prop.SetValue(old, prop.GetValue(item));
            //}
            //ctx.SaveChanges();
        }
    }
}
