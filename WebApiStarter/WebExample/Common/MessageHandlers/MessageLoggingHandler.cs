using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebExample.DataAccess.Models;

namespace WebExample.Common.MessageHandlers
{
    public class MessageLoggingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestMessage = await request.Content.ReadAsByteArrayAsync();

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
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

            var responseMessage = await response.Content.ReadAsByteArrayAsync();

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