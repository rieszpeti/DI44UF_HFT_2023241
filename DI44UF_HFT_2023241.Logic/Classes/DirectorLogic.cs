using DI44UF_HFT_2023241.Models;
using DI44UF_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic
{
    public class DirectorLogic : IDirectorLogic
    {
        IRepository<Director> repo;

        public DirectorLogic(IRepository<Director> repo)
        {
            this.repo = repo;
        }

        public void Create(Director item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Director Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Director> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Director item)
        {
            this.repo.Update(item);
        }
    }
}
