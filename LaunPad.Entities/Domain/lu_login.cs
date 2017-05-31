using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Entities.Domain
{
    public class lu_login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int login_id { get; set; }
        public string user_name { get; set; }
        public string pword { get; set; }
        public string server_name { get; set; }
        public string dsn { get; set; }
        public Nullable<int> client_emp_id { get; set; }
        public string db { get; set; }       
        public int client_id { get; set; }
        [ForeignKey("client_id")]
        public virtual lu_client lu_client { get; set; }
        public int status { get; set; }
        public int fail_count { get; set; }
        public Nullable<int> registration { get; set; }
        public Nullable<int> User_ID { get; set; }
        public string ServiceUrl { get; set; }
        public string Sync_UserEmail { get; set; }
        public string user_token { get; set; }
    }
}
