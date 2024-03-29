﻿using AutoMapper;
using Azure;
using LiStream.DataHandler;
using LiStream.DataHandler.Interfaces;
using LiStream.DtoHandler.Interfaces;
using LiStreamAPI.Models;
using LiStreamData.DTO;
using LiStreamData.DTOs.CreateDTOs;
using LiStreamData.DTOs.UpdateDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LiStreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistAPIController : ControllerBase
    {
        private APIResponse _response;
        private readonly ILogger<ArtistAPIController> _logger;
        private readonly ArtistHandler _artistHandler;
        private readonly IDtoHandler _dtoHandler;
        private readonly IMapper _mapper;

        public ArtistAPIController(ILogger<ArtistAPIController> logger, ArtistHandler artistHandler, IDtoHandler dtoHandler, IMapper mapper)
        {
            _logger = logger;
            _artistHandler = artistHandler;
            _dtoHandler = dtoHandler;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetArtists()
        {
            try
            {
                var artistDtos = _artistHandler.GetAll().Select(_dtoHandler.ToDto);

                if (artistDtos == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No artists found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = artistDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting artists");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting artists");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("{id:guid}", Name = "GetArtist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetArtist(Guid id)
        {
            try
            {
                var artistDto = _dtoHandler.ToDto(_artistHandler.Get(id));

                if (artistDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Artist not found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = artistDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting artist");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting artist");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> CreateArtist([FromBody] ArtistCreateDto artistCreateDto)
        {
            try
            {
                if (artistCreateDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Artist object is null");
                    return BadRequest(_response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid artist object");
                    return BadRequest(_response);
                }

                var artistDto = _mapper.Map<ArtistDto>(artistCreateDto);

                var success = _artistHandler.Create(artistDto);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error adding artist");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding artist");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error adding artist");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> UpdateArtist(Guid id, [FromBody] ArtistUpdateDto artistUpdateDto)
        {
            try
            {
                if (artistUpdateDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Artist object is null");
                    return BadRequest(_response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid artist object");
                    return BadRequest(_response);
                }

                var artistDto = _mapper.Map<ArtistDto>(artistUpdateDto);
                artistDto.Id = id;

                var success = _artistHandler.Update(artistDto);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error updating artist");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating artist");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error updating artist");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> DeleteArtist(Guid id)
        {
            try
            {
                var artist = _artistHandler.Get(id);

                if (artist == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No artist found");
                    return NotFound(_response);
                }

                var success = _artistHandler.Delete(id);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error deleting artist");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting artist");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error deleting artist");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }
    }
}
