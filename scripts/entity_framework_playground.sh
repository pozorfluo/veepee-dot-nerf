# install Entity Framework + dependencies + tools
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

# install alternate database provider
dotnet add package MySql.Data.EntityFrameworkCore

# export the scaffold tool path
export PATH=$HOME/.dotnet/tools:$PATH

# generate crud code for Client model
dotnet aspnet-codegenerator controller -name ClientController -m Client -dc VeepeeDotNerfContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

# generate crud code for Address model
dotnet aspnet-codegenerator controller -name AddressController -m Address -dc VeepeeDotNerfContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries

# get help 
dotnet aspnet-codegenerator controller -h

# !!! shutdown app first !!!
# prepare migration
dotnet ef migrations add InitialCreate -v

# undo migration that has not been applied yet
dotnet ef migrations remove -v

# apply migration
dotnet ef database update -v