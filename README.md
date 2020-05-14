# ad-via-pscore
Front-end powershell with dotnetcore

## Purpose
Invoke posh from dotnet core, using mediatr for IPC; import AD-related modules with the compatibility module

## Notes
This is just an example that serves as a reminder for me.  If you've stumbled across this, know that you will need to complete the implementation:
- Create models for the PSObjects you'll be working with
- Invoke the session state
- Import whatever posh modules you want
- Add scripts/commands to the session state
- Execute and serialize what you get back

The WindowsCompatibility Module is a submodule; don't forget to run git submodule update (or whatever the command is, when you're reading this).