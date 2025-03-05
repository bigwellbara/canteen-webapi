using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Canteen.Application.Commands.UserProfileCommands;
using Canteen.Domain.Aggregates.UserProfileAggregate;

namespace Canteen.Application.Maps
{
    internal class UserProfileMap : Profile
    {
        public UserProfileMap()
        {

            CreateMap<CreateUserCommand, BasicInfor>();

        }
    }
}
