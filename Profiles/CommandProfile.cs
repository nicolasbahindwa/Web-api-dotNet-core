using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_api_dotNet_core.Data;
using Web_api_dotNet_core.Dtos;
using Web_api_dotNet_core.Models;

namespace Web_api_dotNet_core.Profiles
{
    public class CommandProfile: Profile
    {
        public CommandProfile()
        {
            //Source => target
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();

            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }

    }
}
