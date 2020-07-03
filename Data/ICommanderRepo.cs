using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_api_dotNet_core.Models;

namespace Web_api_dotNet_core.Data
{
    public interface ICommanderRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommand();
        Command GetCommandById(int Id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
        

    }
}
