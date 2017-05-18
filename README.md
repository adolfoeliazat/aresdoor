# Aresdoor
###  Yet another persistant backdoor for Windows, in C#
***

### Features
 * Automatically modify registry to autorun on startup
 * 100% persistant backdoor
 * Silent exception escapes (so no noisy dialogs)
 * Checks for internet connection before sending backdoor
 * Command line switches for defining server and port
 * Can add self to registry for autorun on bootup
 * Can prevent system shutdown
 * Modify process name to "hide in plain sight" (default: System)

***
### Version History
 * ### v1.2
   - Fixed change directory bug for command line
   - Add option to prevent shutdown (built into the code)
   - Changed process name to "System" to help "hide in plain sight"
   - Can now insert itself into registry to autorun on bootup (use 'setStartup' in backdoored command line)
 * ### v1.1
   - Add command line switches for modifying server and port to connect back to
   - Clean up source code for easier managment
   - Added more trust in executable so browsers are unlikely to pick it up as 'untrustworthy'
 * ### v1.0
   -  Initial Release

***
### Contribution
Please feel free to modify any of the code to your likings. Let me know of any bugs found in the code.

This is part of my ares* series. I will be releasing a lot more tools designed for Windows in C# soon.

***
### Checksums
__Check Integtrity:__
```bash
root@localhost$ find -type f -exec md5sum "{}" + > checklist.chk
root@localhost$ md5sum -c checklist.chk
```
__v1.2 Checksums:__
```md5sum
939de394a0c803dd6f87ac180e03a889  ./App.config
62bde3677da3552fd8af958d83a80ba6  ./aresdoor.csproj
aa2a791d5c2f5e38459f048e03dbcb6a  ./aresdoor.csproj.user
3418b51bd12d09642d641613ac7c14e4  ./aresdoor.sln
db0de0f38cbc2e0bfe381e15469b46ce  ./bin/Debug/aresdoor.exe
939de394a0c803dd6f87ac180e03a889  ./bin/Debug/aresdoor.exe.config
11458a328a9c5cb3e181985046e25ddd  ./bin/Debug/aresdoor.exe.manifest
9ab2cabb1a79c47726dd14f2e08b33e8  ./bin/Debug/aresdoor.pdb
443d06404ddae7f934840b707ff7f1cb  ./Program.cs
fe7e22736538240fd830f05adc29a370  ./Properties/app.manifest
d74a5577166d3a323f63d33f2f5e4108  ./Properties/AssemblyInfo.cs
c7b12cac52b1fd145858d3b1e5f40e3a  ./Properties/Settings.Designer.cs
d1926e8ab7ed6c40b08eb40d00c6108a  ./Properties/Settings.settings
d41d8cd98f00b204e9800998ecf8427e  ./Settings.cs
```
