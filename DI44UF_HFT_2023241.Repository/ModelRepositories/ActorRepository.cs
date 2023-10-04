using MovieDbApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDbApp.Repository
{
    public class ActorRepository : Repository<Actor>, IRepository<Actor>
    {
        public ActorRepository(MovieDbContext ctx) : base(ctx)
        {
        }

        public override Actor Read(int id)
        {
            return ctx.Actors.FirstOrDefault(t => t.ActorId == id);
        }

        public override void Update(Actor item)
        {
            var old = Read(item.ActorId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
