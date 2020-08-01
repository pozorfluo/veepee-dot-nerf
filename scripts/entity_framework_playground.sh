# install Entity Framework + dependencies + tools
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

# export the scaffold tool path
export PATH=$HOME/.dotnet/tools:$PATH

# generate crud code for Client model
dotnet aspnet-codegenerator controller -name ClientsController -m Client -dc VeepeeDotNerfContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

# get help 
dotnet aspnet-codegenerator controller -h

# !!! shutdown app first !!!
# prepare migration
dotnet ef migrations add InitialCreate -v
dotnet ef database update