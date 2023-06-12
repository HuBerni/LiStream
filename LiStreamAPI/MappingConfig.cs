using AutoMapper;
using LiStream.Playables;
using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamData.DTO;
using LiStreamData.DTOs.CreateDTOs;
using LiStreamData.DTOs.UpdateDTOs;

namespace LiStreamAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<ISong, SongDto>();
            CreateMap<IAlbum, AlbumDto>();
            CreateMap<IArtistProfile, ArtistDto>();
            CreateMap<IPlaylist, PlaylistDto>();


            CreateMap<SongDto, SongCreateDto>()
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Artist.Id))
                .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.Album.Id)).ReverseMap();
            CreateMap<SongDto, SongUpdateDto>()
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Artist.Id))
                .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.Album.Id)).ReverseMap();
            CreateMap<ISong, SongUpdateDto>()
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Artist.Id))
                .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.Album.Id)).ReverseMap();
            CreateMap<Song, SongUpdateDto>()
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Artist.Id))
                .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.Album.Id)).ReverseMap();

            CreateMap<ArtistDto, ArtistCreateDto>().ReverseMap();
            CreateMap<ArtistDto, ArtistUpdateDto>().ReverseMap();

            CreateMap<AlbumDto, AlbumCreateDto>()
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Artist.Id)).ReverseMap();
            CreateMap<AlbumDto, AlbumUpdateDto>()
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Artist.Id)).ReverseMap();

            CreateMap<PlaylistDto, PlaylistCreateDto>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Owner.Id)).ReverseMap();
            CreateMap<PlaylistDto, PlaylistUpdateDto>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.Owner.Id)).ReverseMap();

            CreateMap<UserDto, UserCreateDto>().ReverseMap();
            CreateMap<UserDto, UserUpdateDto>().ReverseMap();
        }
    }
}
