param (
    [string]$swigFolder
)

$swigPath = "$SwigFolder\swig.exe"

Copy-Item "crfsuite_module\export_wrap.cpp" -Destination "dotCRFSuite\GeneratedCode\"

& "$SwigFolder\swig.exe" -c++ -csharp -I"resources\crfsuite\include\" -o "dotCRFSuite\GeneratedCode\export_wrap.cpp" resources\crfsuite\swig\export.i

Remove-Item "dotCRFSuite\GeneratedCode\export_wrap.cpp"
Remove-Item "dotCRFSuite\GeneratedCode\export_wrap.h"

Get-ChildItem "dotCRFSuite\GeneratedCode" -Recurse -Filter *.cs |
ForEach-Object { 
    $path = "$($_.FullName)"
    $newText = (get-content $path).Replace('public class', 'internal class')
    $newText > $path
}

$path = "dotCRFSuite\GeneratedCode\crfsuitePINVOKE.cs"
$newText = (get-content $path).Replace('DllImport("crfsuite"', 'DllImport(@"crfsuite_module.dll"')
$newText > $path

Copy-Item "crfsuite_module\Win32\Release\crfsuite_module.dll" -Destination "dotCRFSuite\dlls\Win32\"
Copy-Item "crfsuite_module\x64\Release\crfsuite_module.dll" -Destination "dotCRFSuite\dlls\x64\"