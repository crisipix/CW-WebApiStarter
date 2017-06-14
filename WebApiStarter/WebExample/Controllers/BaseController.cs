using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebExample.DataAccess.Models;

namespace WebExample.Controllers
{
    //ExecutingAsync
    public class BaseController : ApiController
    {
        //
        // Summary:
        //     Executes asynchronously a single HTTP operation.
        //
        // Parameters:
        //   controllerContext:
        //     The controller context for a single HTTP operation.
        //
        //   cancellationToken:
        //     The cancellation token assigned for the HTTP operation.
        //
        // Returns:
        //     The newly started task.
        public override async Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext,
            CancellationToken cancellationToken)
        {

            var response = await base.ExecuteAsync(controllerContext, cancellationToken);

            if (response.StatusCode != System.Net.HttpStatusCode.OK) {
                return response;
            }
            Type originalType;
            if (response.Content is ObjectContent)
            {
                var type = ((ObjectContent)response.Content).Value.GetType();
                if (type != null)
                {
                    var underlier = type.GetInterfaces()
                                        .Where(i => i.IsGenericType && i.GenericTypeArguments.Length == 1)
                                        .FirstOrDefault(i => i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                    if (underlier != null)
                    {
                        originalType = underlier.GenericTypeArguments[0];
                    }
                    else
                    {
                        originalType = type;
                    }


                    if (ImplementsInterface(originalType, typeof(IRecordPermission)))
                    {
                        Console.WriteLine("Foundssss");
                        if (underlier != null)
                        {

                            // var results = (IEnumerable<IPermission>)((ObjectContent)response.Content).Value;
                            // var results = (IEnumerable<AccountModel>)((ObjectContent)response.Content).Value;

                            // var filtered = results.Where(r => r.Identifier != "Invalid").Select(x => x).Take(2).ToList();

                            //response.Content = new ObjectContent(type, filtered, new JsonMediaTypeFormatter());
                        }
                        else
                        {
                            var result = (IRecordPermission)((ObjectContent)response.Content).Value;

                            var filtered = result.Identifier != "Invalid" ? result : null;

                            response.Content = new ObjectContent(type, filtered, new JsonMediaTypeFormatter());

                        }
                    }

                    // check content for changes
                    var message = await response.Content.ReadAsStringAsync();


                }
            }

            return response;
        }


        public Type GetBaseType(Type inputType)
        {

            var baseType = inputType.BaseType;
            return baseType;
        }

        public bool ImplementsInterface(Type type, Type permissionInterface)
        {
            if (permissionInterface.IsAssignableFrom(type))
            {
                return true;
            }
            if (type.GetInterfaces().Contains(permissionInterface))
            {
                return true;
            }

            return false;
        }

    }
}