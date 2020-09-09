using AutoMapper;
using ItemSchema = Assesment.Inventory.Data.Model.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assesment.Inventory.Common.Model.Item;

namespace Assesment.Inventory.Core.AutoMapperConf
{
    public class AutoMapperConf
    {        
        public static AutoMapperConf Instance { get; private set; }

        public IMapper Mapper { get {
                IMapper mapper = mapperConfiguration.CreateMapper();
                return mapper;
            } }

        private MapperConfiguration mapperConfiguration;

        private AutoMapperConf()
        {
            mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ItemSchema.Item, ItemDTO>();
                cfg.CreateMap<ItemDTO, ItemSchema.Item>();
            });
        }

        static AutoMapperConf()
        {
            Instance = new AutoMapperConf();
        }
    }
}
