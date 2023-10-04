using DI44UF_HFT_2023241.Models.Old;
using System.Linq;

namespace DI44UF_HFT_2023241.Repository.Old
{
    public class ApiCalledWebsiteRepository : Repository<IApiCalledWebsite>, IRepository<IApiCalledWebsite>
    {
        public ApiCalledWebsiteRepository(ApiCallerDbContext ctx) : base(ctx)
        {
        }

        public override IApiCalledWebsite Read(int id)
        {
            return null;
            //return ctx.WebSite.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(IApiCalledWebsite item)
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
