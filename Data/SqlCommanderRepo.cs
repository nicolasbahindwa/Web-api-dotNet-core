using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_api_dotNet_core.Models;

namespace Web_api_dotNet_core.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContex _context;

        public SqlCommanderRepo(CommanderContex context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if (cmd == null)
            {

                throw new ArgumentNullException(nameof(cmd));
            }
            _context.commands.Add(cmd);
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
            {

                throw new ArgumentNullException(nameof(cmd));
            }

            _context.commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommand()
        {
            return _context.commands.ToList();
        }

        public Command GetCommandById(int Id)
        {
            var command = _context.commands.Find(Id);

            return command;

        }

        public bool SaveChanges()
        {
          return ( _context.SaveChanges() > 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //nothing
        }


    }
}
