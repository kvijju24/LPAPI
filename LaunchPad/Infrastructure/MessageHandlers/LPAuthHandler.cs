using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using LaunchPad.Infrastructure.Extensions;
using LaunchPad.Entities;
using System.Security;
//using LaunchPad.Services;

namespace LaunchPad.Infrastructure.MessageHandlers
{
    public class LPAuthHandler : DelegatingHandler
    {
        IEnumerable<string> authHeaderValues = null;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                request.Headers.TryGetValues("Authorization", out authHeaderValues);
                if (authHeaderValues == null)
                    return base.SendAsync(request, cancellationToken); // cross fingers
                var tokens = authHeaderValues.FirstOrDefault();
                tokens = tokens.Replace("Basic", "").Trim();
                if (!string.IsNullOrEmpty(tokens))
                {
                    byte[] data = Convert.FromBase64String(tokens);
                    string decodedString = Encoding.UTF8.GetString(data);
                    string[] tokensValues = decodedString.Split(':');
                    //var securityService = request.GetSecurityService();
                    // var membershipCtx = securityService.ValidateUser(tokensValues[0], tokensValues[1]);

                    var user = new User { Username = "gsparkman" };
                   
                    var userRoles = new List<string> { "admin" };

                    var identity = new GenericIdentity(user.Username);
                    var Principal = new GenericPrincipal(
                        identity,
                        userRoles.ToArray());

                    if (user != null)
                    {
                        IPrincipal principal = Principal;
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                    else // Unauthorized access - wrong crededentials
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        var tsc = new TaskCompletionSource<HttpResponseMessage>();
                        tsc.SetResult(response);
                        return tsc.Task;
                    }
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                    var tsc = new TaskCompletionSource<HttpResponseMessage>();
                    tsc.SetResult(response);
                    return tsc.Task;
                }
                return base.SendAsync(request, cancellationToken);
            }
            catch
            {
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                var tsc = new TaskCompletionSource<HttpResponseMessage>();
                tsc.SetResult(response);
                return tsc.Task;
            }
        }
    }
}