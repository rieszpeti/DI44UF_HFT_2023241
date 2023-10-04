using DI44UF_HFT_2023241.Models;

namespace DI44UF_HFT_2023241.Repository
{
    public class ProductRepository : Repository<IProduct>, IRepository<IProduct>
    {
        public ProductRepository(ApiCallerDbContext ctx) : base(ctx)
        {
        }

        public override IProduct Read(int id)
        {
            return null;
            //return ctx.WebSite.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(IProduct item)
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
