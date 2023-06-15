using AutoMapper;
using LiStream.DataHandler;
using LiStream.DataHandler.Interfaces;
using LiStream.Evaluators.Interfaces;
using LiStreamAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LiStreamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluatorAPIController : ControllerBase
    {
        private APIResponse _response;
        private readonly ILogger<EvaluatorAPIController> _logger;
        private readonly IDataHandler _dataHandler;

        public EvaluatorAPIController(ILogger<EvaluatorAPIController> logger, IDataHandler dataHandler)
        {
            _logger = logger;
            _dataHandler = dataHandler;
            _response = new();
        }

        [HttpGet]
        [Route("similarSong/{id:guid}", Name = "GetSimilarSong")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetSimilarSong(Guid id)
        {
            try
            {
                var song = _dataHandler.GetSong(id);

                if (song == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No song found");
                    return NotFound(_response);
                }

                var similarSong = _dataHandler.GetSimilar(song);

                if (similarSong == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No similar song found");

                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = similarSong;
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
        [Route("similarSongList/{id:guid}", Name = "GetSimilarSongList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetSimilarSongList(Guid id)
        {
            try
            {
                var song = _dataHandler.GetSong(id);

                if (song == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Song not found");
                    return NotFound(_response);
                }

                var songs = _dataHandler.GetSimilarList(song);

                if (songs == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No similar songs found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = songs;
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
        [Route("similarArtist/{id:guid}", Name = "GetSimilarArtist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetSimilarArtist(Guid id)
        {
            try
            {
                var artist = _dataHandler.GetArtistProfile(id);

                if (artist == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Artist not found");
                    return NotFound(_response);
                }

                var similarArtist = _dataHandler.GetSimilar(artist);

                if (similarArtist == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No similar artist found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = similarArtist;
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

        [HttpGet]
        [Route("similarArtistList/{id:guid}", Name = "GetSimilarArtistList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetSimilarArtistList(Guid id)
        {
            try
            {
                var artist = _dataHandler.GetArtistProfile(id);

                if (artist == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("Artist not found");
                    return NotFound(_response);
                }

                var artists = _dataHandler.GetSimilarList(artist);

                if (artists == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No similar artists found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = artists;
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
    }
}
