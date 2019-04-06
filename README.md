# Catboy.SolusVM
SolusVM Client .NET Library

## Quick and easy guide
* Import  
`Imports Catboy.SolusVM`  
  
* Init  
`Dim client = New SolusVMClient(API_KEY, API_HASH, "https://solusvm.vps-seller.com")`  
  
* Get information  
`Dim bandwidth_usage As String = Await client.InfoAsync().bw`  
  
* Reboot  
```
Dim return_value = Await client.RebootAsync()
If return_value.statusmsg = "rebooted" Then
    Console.WriteLine("VPS Rebooted.")
End If
```
  
* ... And more.
  
## About SolusVM Client API Returning Values
[https://documentation.solusvm.com/display/DOCS/Functions](https://documentation.solusvm.com/display/DOCS/Functions)
