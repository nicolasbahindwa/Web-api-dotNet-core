using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_api_dotNet_core.Models;

namespace Web_api_dotNet_core.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommand()
        {
            var commands = new List<Command>
            {
                new Command
            {
                Id = 1,
                HowTo = "boil egg",
                Line = "boil water",
                Platform = "ketle and pan"
            },
                 new Command
            {
                Id = 2,
                HowTo = "how to cook rice",
                Line = "put rice in the cooker ",
                Platform = "Rice cooker"
            },
                  new Command
            {
                Id = 3,
                HowTo = "Fry cheken",
                Line = "",
                Platform = "Kettle and pan"
            }

            };
            return commands;
        }

        public Command GetCommandById(int Id)
        {
            return new Command
            {
                Id = 1,
                HowTo = "boil egg",
                Line = "",
                Platform = "windows"
            };
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}
