using LaunchPad.Data;
using LaunchPad.Data.Infrastructure;
using LaunchPad.Data.Repositories;
using LaunchPad.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LaunchPad.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        protected readonly IEntityBaseRepository<Error> _errorsRepository;
        //protected readonly IUnitOfWork<LPDataContext> _unitOfWorkSecurity;
        protected readonly IUnitOfWork<ClientDataContext> _unitOfWork;

        public ApiControllerBase(IEntityBaseRepository<Error> errorsRepository, IUnitOfWork<ClientDataContext> unitOfWork)
        {
            _errorsRepository = errorsRepository;
           // _unitOfWorkSecurity = unitOfWorkSecurity;
            _unitOfWork = unitOfWork;
            var token = HttpContext.Current.User.Identity.Name;
            var repo = new SecurityRepository();
            var luLogin = repo.ValidateToken(token);
            if (luLogin != null)
            {
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder
                    (System.Configuration.ConfigurationManager
                        .ConnectionStrings["ClientDataContext"].ConnectionString);


                if (!string.IsNullOrEmpty(luLogin.db))
                    sqlCnxStringBuilder.InitialCatalog = luLogin.db;
                _unitOfWork.ChangeDataBaseName(sqlCnxStringBuilder);
            }

        }

        public ApiControllerBase(IDataRepositoryFactory dataRepositoryFactory, IEntityBaseRepository<Error> errorsRepository, IUnitOfWork<ClientDataContext> unitOfWork)
        {
            _errorsRepository = errorsRepository;
            //_unitOfWorkSecurity = unitOfWorkSecurity;
            _unitOfWork = unitOfWork;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        private void LogError(Exception ex)
        {
            try
            {
                Error _error = new Error()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                };

                _errorsRepository.Add(_error);
                _unitOfWork.Commit();
            }
            catch { }
        }
    }
}