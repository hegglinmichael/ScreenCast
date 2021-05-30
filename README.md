# ScreenCast
A simple screencast application.  Has multiple branches, each branch a small step to achieving Screencast application.  Starting with simple C# chat server, ending with screen cast.

All code is written in C#, the code will eventually be added with some sort of interface

## These programs where developed on Macos, the setup is below
1. install visual studio code, visual studio code C# extension, and .net stable build
  a. https://dotnet.microsoft.com/download
  b. https://code.visualstudio.com/download

2. create an example Hello World Project in VS Code
  a. File > Open
  b. create a folder
  c. open the terminal in VS code (View > Terminal)
  d. type $> dotnet new console

3. insert my code into the Program.cs file

4. Add the below to the [your project name].csproj file
  a. This is allowing you to use the System.Drawing packages
  <ItemGroup>
    <PackageReference Include="System.Drawing.Common" Version="4.7.0" />
  </ItemGroup>

5. run code with command: $> dotnet run

NOTE: you must run the server before the client
  


