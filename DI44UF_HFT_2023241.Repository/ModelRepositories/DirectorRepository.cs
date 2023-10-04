namespace DI44UF_HFT_2023241.Repository
{
    //public class DirectorRepository : Repository<Director>, IRepository<Director>
    //{
    //    public DirectorRepository(MovieDbContext ctx) : base(ctx)
    //    {
    //    }

    //    public override Director Read(int id)
    //    {
    //        return ctx.Directors.FirstOrDefault(t => t.DirectorId == id);
    //    }

    //    public override void Update(Director item)
    //    {
    //        var old = Read(item.DirectorId);
    //        foreach (var prop in old.GetType().GetProperties())
    //        {
    //            prop.SetValue(old, prop.GetValue(item));
    //        }
    //        ctx.SaveChanges();
    //    }
    //}
}
