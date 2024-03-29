﻿using System;
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
    public class LocalBoardController : ControllerBase
	{
        private readonly ILocalBoardRepository _localBoardRepository;
        private readonly IMapper _mapper;

        public LocalBoardController(ILocalBoardRepository localBoardRepository, IMapper mapper)
		{
            _localBoardRepository = localBoardRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LocalBoard>))]
        [ProducesResponseType(400)] // Specify 400 for Bad Request
        [ProducesResponseType(404)] // Specify 404 for Not Found
        public IActionResult GetLocalBoards()
        {
            var localboard = _mapper.Map<List<LocalBoardDto>>(_localBoardRepository.GetLocalBoards());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(localboard);
        }

        [HttpGet("{localboardID}")]
        [ProducesResponseType(200, Type = typeof(LocalBoard))]
        [ProducesResponseType(400)] // Specify 400 for Bad Request
        [ProducesResponseType(404)] // Specify 404 for Not Found
        public IActionResult GetLocalBoard(int localboardID)
        {
            if (!_localBoardRepository.LocalBoardExist(localboardID))
                return NotFound();

            var localboard = _mapper.Map<LocalBoardDto>(_localBoardRepository.GetLocalBoards(localboardID));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(localboard);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateLocalBoard([FromBody] LocalBoard boardCreate)
        {
            if (boardCreate == null)
                return BadRequest(ModelState);

            var board = _localBoardRepository.GetLocalBoards()
                .Where(g => g.Id == boardCreate.Id).FirstOrDefault();

            if (board != null)
            {
                ModelState.AddModelError("", "LocalBoard already exist");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var boardMap = _mapper.Map<LocalBoard>(boardCreate);

            if (!_localBoardRepository.CreateLocalBoard(boardMap))
            {
                ModelState.AddModelError("", "Something went wront while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully created");

        }
    }
}

