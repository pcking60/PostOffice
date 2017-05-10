using AutoMapper;
using PostOffice.Model.Models;
using PostOffice.Service;
using PostOffice.Web.Infrastructure.Core;
using PostOffice.Web.Infrastructure.Extensions;
using PostOffice.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace PostOffice.Web.Api
{
    
    [RoutePrefix("api/property")]
    [Authorize]
    public class PropertyServiceController : ApiControllerBase
    {
        private IServiceService _serviceService;
        private IPropertyServiceService _proService;

        public PropertyServiceController(IErrorService errorService, IServiceService service, IPropertyServiceService proService) : base(errorService)
        {
            _proService = proService;
            _serviceService = service;
        }

        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _proService.GetAll();
                totalRow = model.Count();
                var query = model.OrderBy(x => x.ID).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<PropertyService>, IEnumerable<PropertyServiceViewModel>>(query);

                foreach (var item in responseData)
                {
                    var service = _serviceService.GetById(item.ID);
                    item.ServiceName = service.Name;
                }

                var paginationSet = new PaginationSet<PropertyServiceViewModel>//sai ne ban.
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("getallnoparam")]
        [HttpGet]
        public HttpResponseMessage GetAllNoParams(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _serviceService.Getall();

                var responseData = Mapper.Map<IEnumerable<Model.Models.Service>, IEnumerable<ServiceViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, PropertyServiceViewModel proVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbProperty = _proService.GetById(proVM.ID);
                    dbProperty.UpdateProperty(proVM);
                    _proService.Update(dbProperty);
                    _proService.Save();
                    var responseData = Mapper.Map<PropertyService, PropertyServiceViewModel>(dbProperty);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _proService.GetById(id);

                var responseData = Mapper.Map<PropertyService, PropertyServiceViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, PropertyServiceViewModel proVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newProperty = new PropertyService();
                    newProperty.UpdateProperty(proVm);
                    _proService.Add(newProperty);
                    _proService.Save();
                    var responseData = Mapper.Map<PropertyService, PropertyServiceViewModel>(newProperty);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldProperty = _proService.Delete(id);
                    _proService.Save();
                    var responseData = Mapper.Map<PropertyService, PropertyServiceViewModel>(oldProperty);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedProperties)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listProperties = new JavaScriptSerializer().Deserialize<List<int>>(checkedProperties);
                    foreach (var item in listProperties)
                    {
                        _proService.Delete(item);
                    }

                    _proService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listProperties.Count);
                }

                return response;
            });
        }
    }
}