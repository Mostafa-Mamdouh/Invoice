using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ItemDto, ItemsDTL>()
                 .ForMember(d => d.ItemCode, o => o.MapFrom(s => s.ItemCode))
                 .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemName))
                 .ForMember(d => d.QTY, o => o.MapFrom(s => s.QTY))
                 .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
                 .ForMember(d => d.InvoiceId, o => o.MapFrom(s => s.InvoiceId));

            CreateMap<ItemsDTL, ItemDto>()
                  .ForMember(d => d.ItemCode, o => o.MapFrom(s => s.ItemCode))
                  .ForMember(d => d.ItemName, o => o.MapFrom(s => s.ItemName))
                  .ForMember(d => d.QTY, o => o.MapFrom(s => s.QTY))
                  .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
                  .ForMember(d => d.InvoiceId, o => o.MapFrom(s => s.InvoiceId));




            CreateMap<InvoiceDto, InvoiceHDR>()
                .ForMember(d => d.InvoiceDate, o => o.MapFrom(s => s.InvoiceDate))
                .ForMember(d => d.PaymentMethod, o => o.MapFrom(s => s.PaymentMethod))
                .ForMember(d => d.Customer, o => o.MapFrom(s => s.Customer))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.ItemsDTLs, o => o.MapFrom(s => s.itemDtos));


            CreateMap<InvoiceHDR, InvoiceDto>()
                .ForMember(d => d.InvoiceDate, o => o.MapFrom(s => s.InvoiceDate))
                .ForMember(d => d.PaymentMethod, o => o.MapFrom(s => s.PaymentMethod))
                .ForMember(d => d.Customer, o => o.MapFrom(s => s.Customer))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
                .ForMember(d => d.itemDtos, o => o.MapFrom(s => s.ItemsDTLs));

        }
    }
}