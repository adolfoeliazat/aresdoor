# Aresdoor
###  Yet another persistant backdoor for Windows, in C#
***

### Features
 * Automatically modify registry to autorun on startup
 * 100% persistant backdoor
 * Silent exception escapes (so no noisy dialogs)
 * Checks for internet connection before sending backdoor
 * Command line switches for defining server and port

***
### Version History
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
__How To:__
```bash
root@localhost$ find -type f -exec md5sum "{}" + > checklist.chk
root@localhost$ md5sum -c checklist.chk
./.vs/aresdoor/v15/.suo: OK
./App.config: OK
./aresdoor.csproj: OK
./aresdoor.csproj.user: OK
./aresdoor.sln: OK
./bin/Debug/aresdoor.exe: OK
./bin/Debug/aresdoor.exe.config: OK
./bin/Debug/aresdoor.exe.manifest: OK
./bin/Debug/aresdoor.pdb: OK
./checklist.chk: FAILED
./Program.cs: OK
./Properties/app.manifest: OK
./Properties/AssemblyInfo.cs: OK
./Properties/Settings.Designer.cs: OK
./Properties/Settings.settings: OK
md5sum: WARNING: 1 computed checksum did NOT match
root@localhost$
```
__v1.1 Checksums:__
```md5sum
ccf6d865245eebed72a625aff76c81c1  ./.vs/aresdoor/v15/.suo
ef0181de18ef3951806c0ad63b897ba4  ./App.config
90ab17ad0203d7bca1c1d8216b8fd662  ./aresdoor.csproj
99fae535a53b3b6af38a1bbfba426b5f  ./aresdoor.csproj.user
3418b51bd12d09642d641613ac7c14e4  ./aresdoor.sln
1c853510d4570130b2240578b624ef36  ./bin/Debug/aresdoor.exe
ef0181de18ef3951806c0ad63b897ba4  ./bin/Debug/aresdoor.exe.config
7f5bfee348dbba74bd789ff3e45fe4f6  ./bin/Debug/aresdoor.exe.manifest
3815883b9cce5ad82c2fa50abf3ef100  ./bin/Debug/aresdoor.pdb
ebb7c6b6ab934f76bde47b64853c4b64  ./checklist.chk
9104ccf4acf59244fef839b30b39e2c8  ./Program.cs
fe7e22736538240fd830f05adc29a370  ./Properties/app.manifest
da92bb21b543ac0a30ae2b21197d0dcf  ./Properties/AssemblyInfo.cs
c7b12cac52b1fd145858d3b1e5f40e3a  ./Properties/Settings.Designer.cs
853866334f6941de6f38796e3763634c  ./Properties/Settings.settings
```
