using LaunchPad.Entities.Domain;
using LaunchPad.Entities.Domain.Dummy;
using LaunchPad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static LaunchPad.Models.DesignerDummy.DummyViewModel;

namespace LaunchPad.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {
        public static void UpdateBrand(this lu_brand brand, BrandViewModel brandVm)
        {
            brand.brand_desc = brandVm.brand_desc;
        }
        public static void UpdatePage(this tbl_dummy_page  page, DummyPageViewModel pageVm)
        {
            page.page_name = pageVm.page_name;
            page.page_number = pageVm.page_number;
            page.page_status = pageVm.page_status;
            page.page_note = pageVm.page_note;
        }
    }
}