using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.AspNetCore.Hosting;


namespace Example.SessionState
{
    public class ActiveDirectorySessionState
    {
        InitialSessionState sessionState;

        public ActiveDirectorySessionState(IWebHostEnvironment environment)
        {
            // Import necessary PoSh Modules
            string modulePath = Path.Combine(environment.ContentRootPath, "Modules");
            sessionState = InitialSessionState.CreateDefault();
            // set sessionState.ExecutionPolicy to determine what the session state can run, import etc.
            sessionState.ImportPSModulesFromPath(modulePath);
        }

        public PowerShell Shell()
        {
            PowerShell shell = PowerShell.Create(sessionState);            
            shell.AddScript("Import-Module ActiveDirectory");
            shell.Invoke();
            return shell;
        }
    }
}