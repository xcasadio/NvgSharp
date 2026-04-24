mgfxc Effect.fx Effect.dx11.mgfxo /Profile:DirectX_11
mgfxc Effect.fx Effect_AA.ogl.mgfxo /Profile:OpenGL /defines:EDGE_AA=1
mgfxc Effect.fx Effect.dx11.mgfxo /Profile:DirectX_11
mgfxc Effect.fx Effect_AA.dx11.mgfxo /Profile:DirectX_11 /defines:EDGE_AA=1
dotnet "%USERPROFILE%\.nuget\packages\dotnet-mgcb\3.8.4.1\tools\net8.0\any\mgfxc.dll" Effect.fx Effect.ogl.mgfxo /Profile:OpenGL
dotnet "%USERPROFILE%\.nuget\packages\dotnet-mgcb\3.8.4.1\tools\net8.0\any\mgfxc.dll" Effect.fx Effect.dx11.mgfxo /Profile:DirectX_11
dotnet "%USERPROFILE%\.nuget\packages\dotnet-mgcb\3.8.4.1\tools\net8.0\any\mgfxc.dll" Effect.fx Effect_AA.ogl.mgfxo /Profile:OpenGL /defines:EDGE_AA=1
dotnet "%USERPROFILE%\.nuget\packages\dotnet-mgcb\3.8.4.1\tools\net8.0\any\mgfxc.dll" Effect.fx Effect_AA.dx11.mgfxo /Profile:DirectX_11 /defines:EDGE_AA=1

"D:\Windows Kits\10\bin\10.0.19041.0\x64\fxc.exe" /T fx_2_0 /Fo Effect.fxb Effect.fx
"D:\Windows Kits\10\bin\10.0.19041.0\x64\fxc.exe" /T fx_2_0 /Fo Effect_AA.fxb Effect.fx /D EDGE_AA=1