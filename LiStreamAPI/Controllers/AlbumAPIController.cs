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
    public class AlbumAPIController : ControllerBase
    {
        private APIResponse _response;
        private readonly ILogger<AlbumAPIController> _logger;
        private readonly AlbumHandler _albumHandler;
        private readonly IDtoHandler _dtoHandler;
        private readonly IMapper _mapper;

        public AlbumAPIController(ILogger<AlbumAPIController> logger, AlbumHandler albumHandler, IDtoHandler dtoHandler, IMapper mapper)
        {
            _logger = logger;
            _albumHandler = albumHandler;
            _dtoHandler = dtoHandler;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetAlbums()
        {
            try
            {
                var albumDtos = _albumHandler.GetAll().Select(_dtoHandler.ToDto);


                if (albumDtos == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No albums found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = albumDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting albums");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting albums");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetAlbum(Guid id)
        {
            try
            {
                var albumDto = _dtoHandler.ToDto(_albumHandler.Get(id));

                if (albumDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Album not found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = albumDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting album");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting album");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("artist/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetAlbumsByArtist(Guid id)
        {
            try
            {
                var albumDtos = _albumHandler.GetAlbumsByArtist(id).Select(_dtoHandler.ToDto);

                if (albumDtos == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No albums found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = albumDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting albums");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting albums");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> CreateAlbum([FromBody] AlbumCreateDto albumCreateDto)
        {
            try
            {
                if (albumCreateDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("album object is null");
                    return BadRequest(_response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid album object");
                    return BadRequest(_response);
                }

                var albumDto = _mapper.Map<AlbumDto>(albumCreateDto);

                var success = _albumHandler.Create(albumDto);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error adding album");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding album");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error adding album");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> UpdateAlbum(Guid id, [FromBody] AlbumUpdateDto albumUpdateDto)
        {
            try
            {
                if (albumUpdateDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Album object is null");
                    return BadRequest(_response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid album object");
                    return BadRequest(_response);
                }

                var albumDto = _mapper.Map<AlbumDto>(albumUpdateDto);
                albumDto.Id = id;

                var success = _albumHandler.Update(albumDto);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error updating album");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating album");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error updating album");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> DeleteAlbum(Guid id)
        {
            try
            {
                var album = _albumHandler.Get(id);

                if (album == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No album found");
                    return NotFound(_response);
                }

                var success = _albumHandler.Delete(id);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error deleting album");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting album");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error deleting album");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }
    }
}
