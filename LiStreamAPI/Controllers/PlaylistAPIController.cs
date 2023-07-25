using AutoMapper;
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
    public class PlaylistAPIController : ControllerBase
    {
        private APIResponse _response;
        private readonly ILogger<PlaylistAPIController> _logger;
        private readonly PlaylistHandler _playlistHandler;
        private readonly IDtoHandler _dtoHandler;
        private readonly IMapper _mapper;

        public PlaylistAPIController(ILogger<PlaylistAPIController> logger, PlaylistHandler playlistHandler, IMapper mapper, IDtoHandler dtoHandler)
        {
            _logger = logger;
            _playlistHandler = playlistHandler;
            _mapper = mapper;
            _dtoHandler = dtoHandler;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetPlaylists()
        {
            try
            {
                var playlistDtos = _playlistHandler.GetAll().Select(_dtoHandler.ToDto).ToList();

                if (playlistDtos == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No playlists found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = playlistDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting playlists");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting playlists");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("{id:guid}", Name = "GetPlaylist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetPlaylist(Guid id)
        {
            try
            {
                var playlistDto = _dtoHandler.ToDto(_playlistHandler.Get(id));

                if (playlistDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Playlist not found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = playlistDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting playlist");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting playlist");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("user/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetUsersPlaylists(Guid id)
        {
            try
            {
                var playlistDtos = _playlistHandler.GetPlaylistsByUser(id).Select(_dtoHandler.ToDto);

                if (playlistDtos == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No playlists found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = playlistDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting playlists");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting playlists");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> CreatePlaylist([FromBody] PlaylistCreateDto playlistCreateDto)
        {
            try
            {
                if (playlistCreateDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("playlist object is null");
                    return BadRequest(_response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid playlist object");
                    return BadRequest(_response);
                }

                var playlistDto = _mapper.Map<PlaylistDto>(playlistCreateDto);

                var success = _playlistHandler.Create(playlistDto);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error adding playlist");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding playlist");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error adding playlist");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> UpdatePlaylist(Guid id, [FromBody] PlaylistUpdateDto playlistUpdateDto)
        {
            try
            {
                if (playlistUpdateDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Playlist object is null");
                    return BadRequest(_response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid playlist object");
                    return BadRequest(_response);
                }

                var playlistDto = _mapper.Map<PlaylistDto>(playlistUpdateDto);
                playlistDto.Id = id;

                var success = _playlistHandler.Update(playlistDto);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error updating playlist");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating playlist");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error updating playlist");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> DeletePlaylist(Guid id)
        {
            try
            {
                var playlist = _playlistHandler.Get(id);

                if (playlist == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No playlist found");
                    return NotFound(_response);
                }

                var success = _playlistHandler.Delete(id);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error deleting playlist");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting playlist");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error deleting playlist");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }
    }
}

