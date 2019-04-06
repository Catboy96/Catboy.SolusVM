Imports System.Threading.Tasks
Imports System.Net
Imports System.Text.RegularExpressions

Namespace SolusVM
    Public Class SolusVMClient

        Public Property ApiKey As String
        Public Property ApiHash As String
        Public Property Endpoint As String

        Public Structure ClientReturnStructure
            Public status As String
            Public statusmsg As String
            Public hostname As String
            Public vmstat As String
            Public ipaddr As String
            Public ipaddress As String
            Public hdd As String
            Public mem As String
            Public bw As String
        End Structure

        Public Sub New()
            ApiKey = ""
            ApiHash = ""
            Endpoint = ""
        End Sub

        Public Sub New(ApiKey As String, ApiHash As String, Endpoint As String)
            Me.ApiKey = ApiKey
            Me.ApiHash = ApiHash
            Me.Endpoint = Endpoint
        End Sub

        Public Async Function BootAsync() As Task(Of ClientReturnStructure)
            Dim query_string As String = $"{Endpoint}/api/client/command.php?key={ApiKey}&hash={ApiHash}&action=boot"
            Dim return_string As String = Await (New WebClient).DownloadStringTaskAsync(New Uri(query_string))
            Return New ClientReturnStructure With {
                .status = Regex.Match(return_string, "(?<=\<status\>).*(?=\</status\>)").Value,
                .statusmsg = Regex.Match(return_string, "(?<=\<statusmsg\>).*(?=\</statusmsg\>)").Value,
                .hostname = Regex.Match(return_string, "(?<=\<hostname\>).*(?=\</hostname\>)").Value,
                .ipaddress = Regex.Match(return_string, "(?<=\<ipaddress\>).*(?=\</ipaddress\>)").Value,
                .vmstat = Regex.Match(return_string, "(?<=\<vmstat\>).*(?=\</vmstat\>)").Value
            }
        End Function

        Public Async Function RebootAsync() As Task(Of ClientReturnStructure)
            Dim query_string As String = $"{Endpoint}/api/client/command.php?key={ApiKey}&hash={ApiHash}&action=reboot"
            Dim return_string As String = Await (New WebClient).DownloadStringTaskAsync(New Uri(query_string))
            Return New ClientReturnStructure With {
                .status = Regex.Match(return_string, "(?<=\<status\>).*(?=\</status\>)").Value,
                .statusmsg = Regex.Match(return_string, "(?<=\<statusmsg\>).*(?=\</statusmsg\>)").Value,
                .hostname = Regex.Match(return_string, "(?<=\<hostname\>).*(?=\</hostname\>)").Value,
                .ipaddress = Regex.Match(return_string, "(?<=\<ipaddress\>).*(?=\</ipaddress\>)").Value,
                .vmstat = Regex.Match(return_string, "(?<=\<vmstat\>).*(?=\</vmstat\>)").Value
            }
        End Function

        Public Async Function ShutdownAsync() As Task(Of ClientReturnStructure)
            Dim query_string As String = $"{Endpoint}/api/client/command.php?key={ApiKey}&hash={ApiHash}&action=shutdown"
            Dim return_string As String = Await (New WebClient).DownloadStringTaskAsync(New Uri(query_string))
            Return New ClientReturnStructure With {
                .status = Regex.Match(return_string, "(?<=\<status\>).*(?=\</status\>)").Value,
                .statusmsg = Regex.Match(return_string, "(?<=\<statusmsg\>).*(?=\</statusmsg\>)").Value,
                .hostname = Regex.Match(return_string, "(?<=\<hostname\>).*(?=\</hostname\>)").Value,
                .ipaddress = Regex.Match(return_string, "(?<=\<ipaddress\>).*(?=\</ipaddress\>)").Value,
                .vmstat = Regex.Match(return_string, "(?<=\<vmstat\>).*(?=\</vmstat\>)").Value
            }
        End Function

        Public Async Function StatusAsync() As Task(Of ClientReturnStructure)
            Dim query_string As String = $"{Endpoint}/api/client/command.php?key={ApiKey}&hash={ApiHash}&action=status"
            Dim return_string As String = Await (New WebClient).DownloadStringTaskAsync(New Uri(query_string))
            Return New ClientReturnStructure With {
                .status = Regex.Match(return_string, "(?<=\<status\>).*(?=\</status\>)").Value,
                .statusmsg = Regex.Match(return_string, "(?<=\<statusmsg\>).*(?=\</statusmsg\>)").Value,
                .hostname = Regex.Match(return_string, "(?<=\<hostname\>).*(?=\</hostname\>)").Value,
                .ipaddress = Regex.Match(return_string, "(?<=\<ipaddress\>).*(?=\</ipaddress\>)").Value,
                .vmstat = Regex.Match(return_string, "(?<=\<vmstat\>).*(?=\</vmstat\>)").Value
            }
        End Function

        Public Async Function InfoAsync() As Task(Of ClientReturnStructure)
            Dim quer_string As String = $"{Endpoint}/api/client/command.php?key={ApiKey}&hash={ApiHash}&action=info" &
                                        "&bw=true&hdd=true&mem=true&ipaddr=true"
            Dim return_string As String = Await (New WebClient).DownloadStringTaskAsync(New Uri(quer_string))
            Return New ClientReturnStructure With {
                .status = Regex.Match(return_string, "(?<=\<status\>).*(?=\</status\>)").Value,
                .statusmsg = Regex.Match(return_string, "(?<=\<statusmsg\>).*(?=\</statusmsg\>)").Value,
                .hostname = Regex.Match(return_string, "(?<=\<hostname\>).*(?=\</hostname\>)").Value,
                .vmstat = Regex.Match(return_string, "(?<=\<vmstat\>).*(?=\</vmstat\>)").Value,
                .ipaddr = Regex.Match(return_string, "(?<=\<ipaddr\>).*(?=\</ipaddr\>)").Value,
                .ipaddress = Regex.Match(return_string, "(?<=\<ipaddress\>).*(?=\</ipaddress\>)").Value,
                .hdd = Regex.Match(return_string, "(?<=\<hdd\>).*(?=\</hdd\>)").Value,
                .mem = Regex.Match(return_string, "(?<=\<mem\>).*(?=\</mem\>)").Value,
                .bw = Regex.Match(return_string, "(?<=\<bw\>).*(?=\</bw\>)").Value
            }
        End Function

    End Class
End Namespace
