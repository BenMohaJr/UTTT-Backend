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
    }
}

