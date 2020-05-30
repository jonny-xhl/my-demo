# 1. 设置基础镜像
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# 2. 指定（编译和发布）工作目录
WORKDIR /app

# 3. 将.csporj文件复制到工作目录“/app”下，然后执行“dotnet restore”还原nuget包
COPY *.csproj ./
RUN dotnet restore

# 4. 将所有文件辅助到工作目录"/app"下，然后使用"dotnet publish"命令发布到“/app/out”目录下
COPY . ./
RUN dotnet publish -c Release -o out

# 5. 编译生成Docker镜像
# 5.1 指定基础镜像
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS runtime

# 5.2 设置工作目录，并将发布的所有文件复制到out目录下
WORKDIR /app
COPY --from=build /app/out .

# 5.3 设置环境变量（指定端口80，443）
ENV ASPNETCORE_URLS http://0.0.0.0:80;https://0.0.0.0:443

# 5.4 执行dotnet命令启动应用
ENTRYPOINT ["dotnet", "Jonny.AllDemo.StaticFile.dll" ]