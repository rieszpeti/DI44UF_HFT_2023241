using DI44UF_HFT_2023241.Models.Old;

namespace DI44UF_HFT_2023241.Repository.Old
{
    public class WebSiteRepository : Repository<IWebSite>, IRepository<IWebSite>
    {
        public WebSiteRepository(ApiCallerDbContext ctx) : base(ctx)
        {
        }

        public override IWebSite Read(int id)
        {
            return null;
            //return ctx.WebSite.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(IWebSite item)
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
