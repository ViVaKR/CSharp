$stringAsStream = [System.IO.MemoryStream]::new()
$writer = [System.IO.StreamWriter]::new($stringAsStream)
$writer.write("Hello world")
$writer.Flush()
$stringAsStream.Position = 0
Get-FileHash -InputStream $stringAsStream | Select-Object Hash

Get-FileHash .\Program.cs -Algorithm SHA256 | Format-List


Get-Uptime
Write-Output "----------------"
Get-Uptime -Since
