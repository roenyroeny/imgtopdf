project(imgtopdf LANGUAGES CSharp)

add_executable(imgtopdf Program.cs)

set_property(TARGET imgtopdf PROPERTY VS_DOTNET_REFERENCES
      	"System.Drawing"
	"System"
	"System.Core")
