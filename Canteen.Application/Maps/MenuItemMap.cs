using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Canteen.Application.Commands.MenuItemCommands;
using Canteen.Domain.Aggregates.MenuItemAggregate;

namespace Canteen.Application.Maps
{
    public class MenuItemMap :Profile
    {

        public MenuItemMap()
        {
            CreateMap<CreateMenuItemCommand,MenuItem>();
        }
    }
}
