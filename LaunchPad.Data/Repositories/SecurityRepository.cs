using LaunchPad.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchPad.Data.Repositories
{
    public class SecurityRepository
    {
        public lu_login ValidateToken(string token)
        {
            using (LPDataContext context = new LPDataContext())
            {
                return context.lu_login.Where(x => x.user_token == token).FirstOrDefault();
            }
        }
        public lu_client GetClient(string token)
        {
            using (LPDataContext context = new LPDataContext())
            {
                return context.lu_login.Where(x => x.user_token == token).FirstOrDefault().lu_client;
            }
        }
        public string GetDomains()
        {
            using (LPDataContext context = new LPDataContext())
            {
               var domains=  context.lu_client.Where(x=>x.client_domain.Length > 15).ToList().Select(x=> BuildURl(x.client_domain)).Distinct();

               return string.Join(" ,", domains.ToArray());
            }
        }
        public string BuildURl(string url)
        {
            return "https://" + url;
        }
    }
}
