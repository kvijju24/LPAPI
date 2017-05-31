using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class lu_ad_rate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ad_rate_id { get; set; }
        public int pub_id { get; set; }
        public Nullable<int> adsize_id { get; set; }
        public int sect_id { get; set; }
        public string ad_size_abbrv { get; set; }
        public Nullable<int> min_inst_1 { get; set; }
        public Nullable<int> max_inst_1 { get; set; }
        public int restrictive_rates { get; set; }
        public string insertions { get; set; }
        public int ad_clr { get; set; }
        public Nullable<int> ad_shape_id { get; set; }
        public Nullable<int> program_pub_id { get; set; }
        public Nullable<int> bonus_id { get; set; }
        public Nullable<decimal> bonus_retail_rate { get; set; }
        public int bonus_yn { get; set; }
        public int pagination_req { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }
        public Nullable<System.DateTime> expire_dt { get; set; }
        public int trade_yn { get; set; }
        public int status { get; set; }
        public Nullable<int> create_by { get; set; }
        public Nullable<System.DateTime> create_dt { get; set; }
        public Nullable<int> mod_by { get; set; }
        public Nullable<System.DateTime> mod_dt { get; set; }
        public Nullable<int> delete_by { get; set; }
        public Nullable<System.DateTime> delete_dt { get; set; }
        public int budget_item { get; set; }
        public int commissionable { get; set; }
        public int trade_commissionable { get; set; }
        public int budget_trade { get; set; }
        public Nullable<int> edition_id { get; set; }
        public int custom_rate { get; set; }
        public Nullable<int> ad_position_id { get; set; }
        public int multi_version { get; set; }
        public Nullable<int> ad_unit_id { get; set; }
        public int classified { get; set; }
        public Nullable<decimal> cl1 { get; set; }
        public Nullable<decimal> cl2 { get; set; }
        public Nullable<decimal> cl3 { get; set; }
        public Nullable<decimal> cl4 { get; set; }
        public Nullable<decimal> cl5 { get; set; }
        public Nullable<decimal> cl6 { get; set; }
        public Nullable<decimal> cl7 { get; set; }
        public Nullable<decimal> cl8 { get; set; }
        public Nullable<decimal> cl9 { get; set; }
        public Nullable<decimal> cl10 { get; set; }
        public Nullable<decimal> cl11 { get; set; }
        public Nullable<decimal> cl12 { get; set; }
        public Nullable<decimal> cl13 { get; set; }
        public Nullable<decimal> cl14 { get; set; }
        public Nullable<decimal> cl15 { get; set; }
        public int taxable { get; set; }
        public Nullable<int> ad_inventory_id { get; set; }
        public Nullable<int> restricted_io_emp_id { get; set; }
        public int subscription_rate { get; set; }
        public int shopping_cart { get; set; }
        public Nullable<decimal> shopping_cart_retail { get; set; }
        public Nullable<decimal> shopping_cart_discount { get; set; }
        public int production_export { get; set; }
    }
}
