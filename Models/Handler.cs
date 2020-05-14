using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Management.Automation;
using Example.SessionState;
using MediatR;

namespace Example.Models
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly ActiveDirectorySessionState _sessionState;
        public Handler(ActiveDirectorySessionState sessionState){
            this._sessionState = sessionState;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            using(PowerShell posh = _sessionState.Shell())
            {
                posh.AddScript("Import-WinModule ActiveDirectory");
                if(request.requestBody != null)
                    posh.AddScript($"New-Something -Name {request.requestBody.Name}");
                else
                    return new Response(){ message = new List<string>(){"Invalid Parameters"} };

                try
                {
                    List<string> propertyValues = new List<string>();
                    PSDataCollection<PSObject> results = await posh.InvokeAsync();
                    foreach(PSObject item in results){
                        propertyValues.Add(item.Properties["DisplayName"].Value.ToString());
                    }

                    return new Response(){ message = propertyValues };
                }
                catch (Exception e){
                    Console.WriteLine($"{e} caught");
                    throw;
                }
            }
        }
    }
}