using AutoMapper;
using LiStream.DataHandler;
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
    public class UserAPIController : ControllerBase
    {
        private APIResponse _response;
        private readonly ILogger<UserAPIController> _logger;
        private readonly UserHandler _userHandler;
        private readonly IDtoHandler _dtoHandler;
        private readonly IMapper _mapper;

        public UserAPIController(ILogger<UserAPIController> logger, UserHandler userHandler, IDtoHandler dtoHandler, IMapper mapper)
        {
            _logger = logger;
            _userHandler = userHandler;
            _dtoHandler = dtoHandler;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetUsers()
        {
            try
            {
                var userDtos = _userHandler.GetAll().Select(_dtoHandler.ToDto).ToList();

                if (userDtos == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No users found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = userDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting users");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting users");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("{id:guid}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetUser(Guid id)
        {
            try
            {
                var userDto = _dtoHandler.ToDto(_userHandler.Get(id));

                if (userDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("User not found");
                    return NotFound(_response);
                }

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting user");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> GetUserByEmail(string email)
        {
            try
            {
                var user = _userHandler.GetUserByEmail(email);

                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("User with email not found");
                    return NotFound(_response);
                }

                var userDto = _dtoHandler.ToDto(user);

                _response.StatusCode = HttpStatusCode.OK;
                _response.Result = userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting user");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error getting user");
                return StatusCode((int)_response.StatusCode, _response);
            }

            return Ok(_response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<APIResponse> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            try
            {
                if (userCreateDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("user object is null");
                    return BadRequest(_response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid user object");
                    return BadRequest(_response);
                }

                var userDto = _mapper.Map<UserDto>(userCreateDto);

                var success = _userHandler.Create(userDto);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error adding user");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding user");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error adding user");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ResponseCache(Duration = 300)]
        public ActionResult<APIResponse> UpdateUser(Guid id, [FromBody] UserUpdateDto userUpdateDto)
        {
            try
            {
                if (userUpdateDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("User object is null");
                    return BadRequest(_response);
                }

                if (!ModelState.IsValid)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages.Add("Invalid user object");
                    return BadRequest(_response);
                }

                var userDto = _mapper.Map<UserDto>(userUpdateDto);
                userDto.Id = id;

                var success = _userHandler.Update(userDto);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error updating user");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error updating user");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<APIResponse> DeleteUser(Guid id)
        {
            try
            {
                var user = _userHandler.Get(id);

                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages.Add("No user found");
                    return NotFound(_response);
                }

                var success = _userHandler.Delete(id);

                if (success == false)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.InternalServerError;
                    _response.ErrorMessages.Add("Error deleting user");
                    return StatusCode((int)_response.StatusCode, _response);
                }

                _response.Result = success;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user");
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages.Add("Error deleting user");
                return StatusCode((int)_response.StatusCode, _response);
            }
        }
    }
}
