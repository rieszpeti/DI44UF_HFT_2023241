using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Logic.Mapper
{
    public interface IMapper<Model, Dto>
    {
        Dto ConvertModelToDto(Model input);

        Model ConvertDtoToModel(Dto input);
    }
}
