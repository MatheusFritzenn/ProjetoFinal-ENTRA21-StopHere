using AutoMapper;
using Entities;
using PresentationLayer.Models.LegalPerson;
using PresentationLayer.Models.Location;
using PresentationLayer.Models.NaturalPerson;
using PresentationLayer.Models.Parking;
using PresentationLayer.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Infrastructure
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<LegalPersonCreateViewModel, LegalPerson>();
            CreateMap<LegalPerson, LegalPersonUpdateViewModel>();
            CreateMap<LegalPersonUpdateViewModel, LegalPerson>();

            CreateMap<NaturalPersonCreateViewModel, NaturalPerson>();
            CreateMap<NaturalPerson, NaturalPersonCreateViewModel>();
            CreateMap<NaturalPerson, NaturalPersonUpdateViewModel>();
            CreateMap<NaturalPersonUpdateViewModel, NaturalPerson>();

            CreateMap<VehicleCreateViewModel, Vehicle>();
            CreateMap<Vehicle, VehicleShowAllViewModel>();
            CreateMap<Vehicle, VehicleUpdateViewModel>();
            CreateMap<VehicleUpdateViewModel, Vehicle>();

            CreateMap<ParkingInsertViewModel, Parking>();
            CreateMap<Parking, ParkingInsertViewModel>();
            CreateMap<Parking, ParkingQueryViewModel>();
            CreateMap<Parking, ParkingUpdateViewModel>();
            CreateMap<ParkingUpdateViewModel, Parking>();

            CreateMap<Parking, LocationInsertViewModel>();
            CreateMap<LocationInsertViewModel, Location>();
            CreateMap<Parking, LocationShowAllViewModel>();
            CreateMap<Location, LocationShowAllViewModel>();
            CreateMap<Parking, ParkJsonViewModel>().ForMember(c => c.Abre, x => x.MapFrom(src => new DateTime(src.Abre.Ticks).ToString("HH:mm"))).ForMember(c => c.Fecha, x => x.MapFrom(src => new DateTime(src.Fecha.Ticks).ToString("HH:mm")));



        }
    }
}
