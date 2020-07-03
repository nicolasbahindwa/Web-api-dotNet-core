using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_api_dotNet_core.Data;
using Web_api_dotNet_core.Dtos;
using Web_api_dotNet_core.Models;

namespace Web_api_dotNet_core.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        //GET api/commands/
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var CommandItems = _repository.GetAllCommand();

            // return Ok(CommandItems);
            return Ok(mapper.Map<IEnumerable<CommandReadDto>>(CommandItems));

        }

        //GET api/commands/{id}
        [Route("{Id}", Name = "GetCommandById")]
        [HttpGet]
        public ActionResult <CommandReadDto> GetCommandById(int Id)
        {
            var CommandItem = _repository.GetCommandById(Id);

            if (CommandItem == null)
            {
                return NotFound();
                //  return Ok(CommandItem);

            }
            else
            {
                return Ok(mapper.Map<CommandReadDto>(CommandItem));
               
            }
           
        }


        //POST api/command
       // [Route()]
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {

            var CommandModel = mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(CommandModel);
            _repository.SaveChanges();

            var commandReadDto = mapper.Map<CommandReadDto>(CommandModel);

            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
          //  return Ok(CommandModel);

        }

        //PUT api/command
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int Id, CommandUpdateDto commandUpdateDto)
        {

            var commandModelFromRepo = _repository.GetCommandById(Id);
            if (commandUpdateDto == null)
            {
                return NotFound();
            }

            mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }


        //PAtch api/command
        [HttpPatch("{id}")]
        public ActionResult partialCommandUpdate(int Id, JsonPatchDocument<CommandUpdateDto> patchdoc)
        {

            var commandModelFromRepo = _repository.GetCommandById(Id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchdoc.ApplyTo(commandToPatch, ModelState);
            if (!(TryValidateModel(commandToPatch)))
            {
                return ValidationProblem(ModelState);
            }

            mapper.Map(commandToPatch, commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();

        }

        //DELETE api/commands/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int Id)
        {
            var commandModelFromRepo = _repository.GetCommandById(Id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


    }
}
