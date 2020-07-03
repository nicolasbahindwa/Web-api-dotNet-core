using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_api_dotNet_core.Models;

namespace Web_api_dotNet_core.Data
{
    public class CommanderContex:DbContext
    {
        public CommanderContex(DbContextOptions<CommanderContex> opt):base(opt)
        {

        }

        public DbSet<Command> commands { get; set; }
    }
}
