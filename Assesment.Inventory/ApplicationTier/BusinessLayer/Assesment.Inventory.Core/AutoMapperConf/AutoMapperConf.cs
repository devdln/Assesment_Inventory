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
    /// <summary>
    /// AutoMapperConf class
    /// </summary>
    public class AutoMapperConf
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static AutoMapperConf Instance { get; private set; }

        /// <summary>
        /// Gets the mapper.
        /// </summary>
        /// <value>
        /// The mapper.
        /// </value>
        public IMapper Mapper { get {
                IMapper mapper = mapperConfiguration.CreateMapper();
                return mapper;
            } }

        /// <summary>
        /// The mapper configuration
        /// </summary>
        private MapperConfiguration mapperConfiguration;

        /// <summary>
        /// Prevents a default instance of the <see cref="AutoMapperConf"/> class from being created.
        /// </summary>
        private AutoMapperConf()
        {
            // set mapper configurations
            mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ItemSchema.Item, ItemDTO>();
                cfg.CreateMap<ItemDTO, ItemSchema.Item>();
            });
        }

        /// <summary>
        /// Initializes the <see cref="AutoMapperConf"/> class.
        /// </summary>
        static AutoMapperConf()
        {
            Instance = new AutoMapperConf();
        }
    }
}
