using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using AngularCURD.Models;
using Microsoft.Data.OData;

namespace AngularCURD.Controllers
{
    /*
    在为此控制器添加路由之前，WebApiConfig 类可能要求你做出其他更改。请适当地将这些语句合并到 WebApiConfig 类的 Register 方法中。请注意 OData URL 区分大小写。

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using AngularCURD.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<UserViewModel>("ApiUser");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class ApiUserController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/ApiUser
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Skip |
        //                          AllowedQueryOptions.Top)]

        public IHttpActionResult GetApiUser(ODataQueryOptions<UserViewModel> queryOptions)
        {
            // validate the query.
            try
            {

                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }
            //int skip = queryOptions.Skip?.Value ?? 0;
            //int top = queryOptions.Top?.Value ?? 10;
           // var list = UserViewModel.GetUserList().ToList();

            return Ok<IEnumerable<UserViewModel>>(UserViewModel.GetUserList());
        }

        // GET: odata/ApiUser(5)
        public IHttpActionResult GetUserViewModel([FromODataUri] int key, ODataQueryOptions<UserViewModel> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<UserViewModel>(userViewModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/ApiUser(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<UserViewModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(userViewModel);

            // TODO: Save the patched entity.

            // return Updated(userViewModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/ApiUser
        public IHttpActionResult Post(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(userViewModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/ApiUser(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<UserViewModel> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(userViewModel);

            // TODO: Save the patched entity.

            // return Updated(userViewModel);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/ApiUser(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
