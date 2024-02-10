using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ultimate_Tic_Tac_Toe.Dto;
using Ultimate_Tic_Tac_Toe.Interfaces;
using Ultimate_Tic_Tac_Toe.Models;
using Ultimate_Tic_Tac_Toe.Repository;

namespace Ultimate_Tic_Tac_Toe.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainBoardController : ControllerBase
    {
        private readonly IMainBoardRepository _mainBoardRepository;
        private readonly IMapper _mapper;

        public MainBoardController(IMainBoardRepository mainBoardRepository, IMapper mapper)
		{
            _mainBoardRepository = mainBoardRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<MainBoard>))]
        [ProducesResponseType(400)] // Specify 400 for Bad Request
        [ProducesResponseType(404)] // Specify 404 for Not Found
        public IActionResult GetMainBoards()
        {
            var MainBoard = _mapper.Map<List<MainBoardDto>>(_mainBoardRepository.getMainBoards());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(MainBoard);
        }

        [HttpGet("{mainboardID}")]
        [ProducesResponseType(200, Type = typeof(MainBoard))]
        [ProducesResponseType(400)] // Specify 400 for Bad Request
        [ProducesResponseType(404)] // Specify 404 for Not Found
        public IActionResult GetPlayer(int mainboardID)
        {
            if (!_mainBoardRepository.MainBoardExist(mainboardID))
                return NotFound();

            var mainboard = _mapper.Map<MainBoardDto>(_mainBoardRepository.GetMainBoards(mainboardID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mainboard);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateMainBoard([FromBody] MainBoardDto boardDto)
        {
            if (boardDto == null)
                return BadRequest(ModelState);

            var board = _mainBoardRepository.getMainBoards()
                .Where(p => p.Id == boardDto.Id)
                .FirstOrDefault();

            if (board != null)
            {
                ModelState.AddModelError("", "board already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var boardMap = _mapper.Map<MainBoard>(boardDto);

            if (!_mainBoardRepository.CreateMainBoard(boardMap))
            {
                ModelState.AddModelError("", "Something went wront while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");

        }
    }
}

