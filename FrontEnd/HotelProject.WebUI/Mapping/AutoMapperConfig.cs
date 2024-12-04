using AutoMapper;

using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.ReservationDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.TestimonialDto;
using System.Runtime.InteropServices;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
           
            CreateMap<CreateNewUserDto, AppUser>().ReverseMap();
            
            CreateMap<LoginUserDto, AppUser>().ReverseMap();

            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<ResultAboutDto, About>().ReverseMap();
            
            CreateMap<ResultTestimonialDto, About>().ReverseMap();
            
     
            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();

            CreateMap<CreateReservationDto, Reservation>().ReverseMap();
            CreateMap<ApprovedReservationDto, Reservation>().ReverseMap(); 
            
            CreateMap<CreateGuestDto, Guest>().ReverseMap();
            CreateMap<UpdateGuestDto, Guest>().ReverseMap();
         

        }
    }
}
