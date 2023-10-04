namespace DI44UF_HFT_2023241.Repository
{
    //public class MovieRepository : Repository<Movie>, IRepository<Movie>
    //{
    //    public MovieRepository(MovieDbContext ctx) : base(ctx)
    //    {
    //    }

    //    public override Movie Read(int id)
    //    {
    //        return ctx.Movies.FirstOrDefault(t => t.MovieId == id);
    //    }

    //    public override void Update(Movie item)
    //    {
    //        var old = Read(item.MovieId);
    //        foreach (var prop in old.GetType().GetProperties())
    //        {
    //            prop.SetValue(old, prop.GetValue(item));
    //        }
    //        ctx.SaveChanges();
    //    }
    //}
}
