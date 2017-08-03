set swigPath=E:\Systems\alkozko\Downloads\swigwin-3.0.12\swigwin-3.0.12\

%swigPath%\swig.exe -c++ -csharp -I"resources\crfsuite\include" -o "dotCRFSuite\dotCRFSuite\GeneratedCode\export_wrap.cpp" "resources\crfsuite\swig\export.i"

move /-y "dotCRFSuite\dotCRFSuite\GeneratedCode\export_wrap.cpp" "crfsuite_module\"
move /-y "dotCRFSuite\dotCRFSuite\GeneratedCode\export_wrap.h" "crfsuite_module\"


PAUSE