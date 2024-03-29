﻿using System;
using AutoMapper;
using Ultimate_Tic_Tac_Toe.Dto;
using Ultimate_Tic_Tac_Toe.Models;

namespace Ultimate_Tic_Tac_Toe.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Players, PlayersDto>();
            CreateMap<PlayersDto, Players>();

            CreateMap<Games, GamesDto>();
            CreateMap<GamesDto, Games>();

            CreateMap<MainBoard, MainBoardDto>();
            CreateMap<MainBoardDto, MainBoard>();

            CreateMap<LocalBoard, LocalBoardDto>();
            CreateMap<LocalBoardDto, LocalBoard>();
        }
	}
}

