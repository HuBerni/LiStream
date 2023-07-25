using AutoMapper;
using LiStream.DataHandler;
using LiStream.DataHandler.Interfaces;
using LiStream.DtoHandler.Interfaces;
using LiStreamAPI.Models;
using LiStreamData.DTO;
using LiStreamData.DTOs.CreateDTOs;
using LiStreamData.DTOs.UpdateDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace LiStreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongAPIController : ControllerBase
    {
        private APIResponse _response;
        private readonly ILogger<SongAPIController> _logger;
        private readonly SongHandler _songHandler;
        private readonly AlbumHandler _albumHandler;
        private readonly PlaylistHandler _playlistHandler;
        private readonly UserHandler _userHandler;
        private readonly IDtoHandler _dtoHandler;
        private readonly IMapper _mapper;

        public SongAPIController(ILogger<SongAPIController> logger, SongHandler songHandler, AlbumHandler albumHandler, PlaylistHandler playlistHandler, UserHandler userHandler,  IDtoHandler dtoHandler, IMapper mapper)
        {
            _logger = logger;
            _songHandler = songHandler;
            _albumHandler = albumHandler;
            _playlistHandler = playlistHandler;
            _userHandler = userHandler;
            _dtoHandler = dtoHandler;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetSongs()
        {
            try
            {
                var songDtos = _songHandler.GetAll().Select(_dtoHandler.ToDto);

                if (songDtos == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No songs found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = songDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting songs");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting songs");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("{id:guid}", Name = "GetSong")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetSong(Guid id)
        {
            try
            {
                var songDto = _dtoHandler.ToDto(_songHandler.Get(id));

                if (songDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No song found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = songDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting song");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting song");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("album/{id:guid}", Name = "GetAlbumSongs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetAlbumSongs(Guid id)
        {
            try
            {
                var songDtos = _songHandler.GetSongsByAlbum(id).Select(_dtoHandler.ToDto);

                if (songDtos == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No songs found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = songDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting songs");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting songs");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("artist/{id:guid}", Name = "GetArtistSongs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetArtistSongs(Guid id)
        {
            try
            {
                var songDtos = _songHandler.GetSongsByArtist(id).Select(_dtoHandler.ToDto);

                if (songDtos == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No songs found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = songDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting songs");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting songs");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("playlist/{id:guid}", Name = "GetPlaylistSongs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetPlaylistSongs(Guid id)
        {
            try
            {
                var songDtos = _songHandler.GetSongsByPlaylist(id).Select(_dtoHandler.ToDto);

                if (songDtos.IsNullOrEmpty())
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No songs found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = songDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting songs");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting songs");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }



        [HttpGet]
        [Route("userFav/{id:guid}", Name = "GetUsersFavouriteSongs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetUsersFavouriteSongs(Guid id)
        {
            try
            {
                var songDtos = _songHandler.GetUsersFavouriteSongs(id).Select(_dtoHandler.ToDto);

                if (songDtos == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No songs found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = songDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting songs");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting songs");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> AddSong([FromBody] SongCreateDto songCreateDto)
        {
            try
            {
                if (songCreateDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Song object is null");
                    return BadRequest(_response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid song object");
                    return BadRequest(_response);
                }

                var songDto = _mapper.Map<SongDto>(songCreateDto);

                var success = _songHandler.Create(songDto);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error adding song");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding song");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error adding song");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpPost]
        [Route("{songId:guid}/album/{albumId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> AddSongToAlbum(Guid songId, Guid albumId)
        {
            try
            {
                var song = _songHandler.Get(songId);
                
                if (song.Album != null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Song already is in an album");
                    return BadRequest(_response);
                }
                
                var album = _albumHandler.Get(albumId);

                if (album == null || song == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Album or song not found");
                    return NotFound(_response);
                }

                var success = _songHandler.InsertSongToAlbum(songId, albumId);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error adding song to album");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding song to album");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error adding song to album");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpPost]
        [Route("{songId:guid}/playlist/{playlistId:guid}/user/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> AddSongToPlaylist(Guid songId, Guid playlistId, Guid userId)
        {
            try
            {
                var playlist = _playlistHandler.Get(playlistId);

                var song = _songHandler.Get(songId);

                var user = _userHandler.Get(userId);

                if (playlist == null || song == null || user == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid playlist, song or user");
                    return BadRequest(_response);
                }

                var success = _songHandler.InsertSongToPlaylist(songId, playlistId, userId);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error adding song to playlist");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding song to playlist");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error adding song to playlist");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpPost]
        [Route("{songId:guid}/user/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> InsertSongToUserFav(Guid songId, Guid userId)
        {
            try
            {
                var song = _songHandler.Get(songId);
                var user = _userHandler.Get(userId);

                if (user == null || song == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid song or user");
                    return BadRequest(_response);
                }

                var success = _songHandler.InsertSongToUserFavorites(songId, userId);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error adding song to user favorites");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding song to user favorites");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error adding song to user favorites");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> UpdateSong(Guid id, [FromBody] SongUpdateDto songUpdateDto)
        {
            try
            {
                if (songUpdateDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Song object is null");
                    return BadRequest(_response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid song object");
                    return BadRequest(_response);
                }

                var songDto = _mapper.Map<SongDto>(songUpdateDto);
                songDto.Id = id;

                var success = _songHandler.Update(songDto);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error updating song");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating song");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error updating song");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> DeleteSong(Guid id)
        {
            try
            {
                var song = _songHandler.Get(id);

                if (song == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No song found");
                    return NotFound(_response);
                }

                var success = _songHandler.Delete(id);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error deleting song");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting song");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error deleting song");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpDelete]
        [Route("/removeFromAlbum/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> RemoveSongFromAlbum(Guid id)
        {
            try
            {
                var song = _songHandler.Get(id);

                if (song == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Song not found");
                    return NotFound(_response);
                }

                if (song.Album.Id == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Song is not in an album");
                    return NotFound(_response);
                }

                var success = _songHandler.DeleteSongFromAlbum(id);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Error removing song from album");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing song from album");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error removing song from album");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpDelete]
        [Route("{songId:guid}/playlist/{playlistId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> DeleteSongFromPlaylist(Guid songId, Guid playlistId)
        {
            try
            {
                var playlist = _playlistHandler.Get(playlistId);

                var song = _songHandler.Get(songId);

                if (playlist == null || song == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No playlist or song found");
                    return NotFound(_response);
                }

                var success = _songHandler.DeleteSongFromPlaylist(songId, playlistId);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error deleting song from playlist");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting song from playlist");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error deleting song from playlist");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

    }
}
