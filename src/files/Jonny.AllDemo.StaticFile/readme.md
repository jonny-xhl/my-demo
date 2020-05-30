@[TOC]
# 前言
以前使用.Net Framwork部署web时需要IIS进行部署 ，在IIS中的虚拟目录、默认文档、MIME、、等等都是已经帮我们处理好了，但是在aspnet core中需要我们自处理，框架自带为我们提供了几个中间件 ，需要在请求管道中自行进行处理过滤等。
下面我将详细的介绍框架自带的几个静态文件、目录文档中间件。
# 1. wwwroot
aspnet core提供的mvc、razorpage、webapi模板都是可以用来开发web项目的，那么细心的童鞋会注意到项目结构中新建`wwwroot`文件夹会自动映射成这样的结构。![在这里插入图片描述](https://img-blog.csdnimg.cn/20200530130808632.png)
这是框架中默认`wwwroot`为静态文件虚拟目录文件夹，内部可以存放`js、css、html、image`等等常用文件。
# 2. UseStaticFiles()注册静态文件中间件

## 2.1 框架自带静态文件
从下图中可以看到`UseStaticFiles`方法件默认有三个重载，下面会进行一一尝试 。
![在这里插入图片描述](https://img-blog.csdnimg.cn/2020053013102812.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3hobF9qYW1lcw==,size_16,color_FFFFFF,t_70)
当我们没有注册静态文件中间件时并不能访问`wwwroot`文件夹下的文件。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200530131306114.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3hobF9qYW1lcw==,size_16,color_FFFFFF,t_70)
在`Configure`方法中注册静态文件中间件。

```csharp
app.UseStaticFiles();
```
这时就可以正常访问了。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200530131750522.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3hobF9qYW1lcw==,size_16,color_FFFFFF,t_70)

## 2.1 自定义静态文件
在某些业务场景中我们可能需要自建立静态文件的路径，例如上传文件需要自己建立的文件夹来进行存储等。
这时就需要使用到`UseStaticFiles`另外两个重载方法。
```csharp
app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = new Microsoft.AspNetCore.Http.PathString("/file"),
    ServeUnknownFileTypes = true,
    //这里需要传递绝对路径
    //FileProvider = new PhysicalFileProvider("files")
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "files"))
});
```
`StaticFileOptions`常用属性解释：
- RequestPath：请求的路径，一定是绝对路径 ==/==
- ServeUnknownFileTypes：支持未知的文件类型
- FileProvider：文件路径，一定是绝对路径
- OnPrepareResponse：这是一个Action\<StaticFileResponseContext>委托，可以对HttpContext做自己的相关处理

我们新建一个==files==文件夹用来存放自己的文件。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200530132747641.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3hobF9qYW1lcw==,size_16,color_FFFFFF,t_70)
这时我们测试访问 **https://localhost:5001/file/特殊文件不能访问.png**

下面的截图不要搞混淆了，我这里顺带一起解释了`ServeUnknownFileTypes`,访问上面的地址会访问到我测试了没有设置`ServeUnknownFileTypes`的时候访问`Dockerfile`文件出现的==404==截图。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200530132917461.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3hobF9qYW1lcw==,size_16,color_FFFFFF,t_70)
设置`ServeUnknownFileTypes=true`能正常访问未支持的文件了。

设置`RequestPath`可以对内的文件夹目录做一个封闭，这样能够不暴露内部的目录结构。

> 上面这样的静态文件这样暴露出来对于使用者来说根本不知道路径是怎样的，接下来会引入另外一个浏览器目录中间件

# 3. UseDirectoryBrowser()注册目录结构中间件
## 3.1 默认目录结构
注静态文件、目录结构中间件
```csharp
app.UseStaticFiles();
app.UseDirectoryBrowser();
```
这时我们可以看到`wwwroot`文件夹下的静态文件，这样能够很方便的给使用者一目了然的知道静态文件的结构是怎样的。
> 注意：这里使用默认的目录结构只会显示出wwwroot下的静态文件，并没有显示出上面提及的files下的静态文件。

![在这里插入图片描述](https://img-blog.csdnimg.cn/20200530133724721.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3hobF9qYW1lcw==,size_16,color_FFFFFF,t_70)
## 3.2 自定义开放目录结构
有时候并不会将`wwwroot`下的所有目录展示出来，可以自行定义展示的目录，例如只展示==html==文件夹的文件。
```csharp
app.UseStaticFiles();
app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/html"))
});
```

![在这里插入图片描述](https://img-blog.csdnimg.cn/20200530134330474.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3hobF9qYW1lcw==,size_16,color_FFFFFF,t_70)
> 注意：这里只是目录结构的展示进行了约束，其他静态文件照样是可以访问的。

## 3.3 静态文件和目录配合使用
我们指定展示上面介绍的自定义文件。
```csharp
app.UseStaticFiles(new StaticFileOptions
{
    RequestPath = new Microsoft.AspNetCore.Http.PathString("/file"),
    ServeUnknownFileTypes = true,
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "files"))
});
app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "files")),
    RequestPath = new Microsoft.AspNetCore.Http.PathString("/file")
});
```
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200530135148887.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3hobF9qYW1lcw==,size_16,color_FFFFFF,t_70)
这时点击静态文件就能够进行正常访问了，仔细的童鞋应该发现了我们的静态文件、目录都是指定的同一个路径和访问地址，经过我测试了要是请求地址没有进行统一的话会照样访问不到的，想道理也能够明白，目录结构的访问路径肯定要和请求路径统一。

那么这样是不是觉得很麻烦呢？？？？

# 4. UseFileServer()融合静态文件、目录结构
注册融合静态文件、目录结构中间件。
```csharp
app.UseFileServer(true);
```
这时照样能够正常的访问，这里不设置`EnableDirectoryBrowsing=true`也还是不会展示目录结构的。
``![在这里插入图片描述](https://img-blog.csdnimg.cn/20200530135740711.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3hobF9qYW1lcw==,size_16,color_FFFFFF,t_70)
## 4.1 默认文档
设置`EnableDefaultFiles`是否启用默认文档，例如访问  **https://localhost:5001/html/**时自动采用了index.html，我猜想这里的默认文档应该和iis中设置的默认文档是一个意思。
```csharp
app.UseFileServer(new FileServerOptions
{
    EnableDefaultFiles=true,
    EnableDirectoryBrowsing=true
});
```
> 注意：当启用了默认文档时在展示目录结构的时候并不会定位到和默认文档同级文件夹下的内容。

例如直接点击html时并不会展示html文件夹下的目录结构，而是直接访问了默认文档。根据自己的使用场景可以自定决定是否开启默认文档。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200530141708369.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3hobF9qYW1lcw==,size_16,color_FFFFFF,t_70)