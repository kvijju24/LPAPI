using AutoMapper;using LaunchPad.Entities.Domain;
using LaunchPad.Entities.Domain.Dummy;
using LaunchPad.Models;
using LaunchPad.Models.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LaunchPad.Models.DesignerDummy.DummyViewModel;

namespace LaunchPad.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        public DomainToViewModelMappingProfile()
        {
            CreateMap<tbl_master_contact, ContactDetailViewModel>();
            CreateMap<tbl_master_contact, Models.Contact.ContactViewModel>();
                
            CreateMap<lu_brand, Models.BrandViewModel>();
            CreateMap<tbl_dummy_page, DummyPageViewModel>();
            CreateMap<tbl_dummy_folio, FolioViewMode>();

            



        }
    }
}