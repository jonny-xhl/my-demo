﻿# ViewCompoment记录
## 引言
此项目用于记录学习ViewComponent，由于在abp.vnext中对mvc做了很强的封装，asp.net core mvc中的相关知识需要进行一个补充。

#### 视图组件描述
参考地址：[官方文档](https://docs.microsoft.com/zh-cn/aspnet/core/mvc/views/view-components?view=aspnetcore-3.1#view-components)
视图组件与分部视图类似，但它们的功能更加强大。 视图组件不使用模型绑定，并且仅依赖调用时提供的数据。 本文是使用控制器和视图编写的，但视图组件也适用于Razor页。

视图组件：
- 呈现一个区块而不是整个响应。
- 包括控制器和视图间发现的相同关注点分离和可测试性优势。
- 可以有参数和业务逻辑。
- 通常从布局页调用。
视图组件可用于具有可重用呈现逻辑（对分部视图来说过于复杂）的任何位置，例如：
- 动态导航菜单
- 标记云（查询数据库的位置）
- 登录面板
- 购物车
- 最近发布的文章
- 典型博客上的边栏内容
- 一个登录面板，呈现在每页上并显示注销或登录链接，具体取决于用户的登录状态

## 练习

#### 创建自定义`ViewComponent`

```chsarp
public class PriorityListViewComponent : ViewComponent
{

    public PriorityListViewComponent()
    {

    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var todo = new List<TodoItem>
        {
            new TodoItem("啦啦啦"),
            new TodoItem("呜呜呜"),
            new TodoItem("嘀嘀嘀"),
            new TodoItem("噫噫噫"),
            new TodoItem("叽叽叽")
        };
        return View(todo);
    }
}
```
#### 创建视图
```
@model IEnumerable<TodoItem>
<div class="text-center">
    <h1 class="display-4">PriorityListViewComponent组件</h1>
    @foreach (var todo in Model)
    {
        <span>@todo.Name</span>
    }
</div>
```
> 注意：这里创建的视图和page是不一样的，不能有@page;路径一定要在以视图名称文件夹目录下;

#### 使用组件
- InvokeAsync方法调用
```
@await Component.InvokeAsync(typeof(PriorityListViewComponent))
```
    - InvokeAsync(this IViewComponentHelper helper, string name)
    - InvokeAsync(this IViewComponentHelper helper, Type componentType)
    - InvokeAsync<TComponent>(this IViewComponentHelper helper)
    - InvokeAsync<TComponent>(this IViewComponentHelper helper, object arguments)
    上诉列表中提供了四个扩展方法，都可以调用，并且可以传递参数
- vc:帮助标记中使用
```
<vc:priority-list> 
</vc:priority-list>
```
使用帮助程序传递参数和常规的element写属性是一致的
例如：
```
<vc:priority-list
  paramter1="p1value"
  paramter2="p2value"
> 
</vc:priority-list>
```
> 采用Pascal的模式组件名称，这和vue中的组件使用基本一致

# @page "{id:int?}"
在razor page页面中加入路由模板`{id:int?}`,这里`?`表示可空。对应的后台代码中加入参数，这样就可以接收到。
```
public void OnGet(int? id)
{
    PrivacyM = PrivacyStore.GetPrivacies().FirstOrDefault(p => p.Id == id);
}
```
> 经测试当没有添加路由模板时候是404
关于`@page`参考官方文档（https://docs.microsoft.com/zh-cn/aspnet/core/tutorials/razor-pages/page?view=aspnetcore-3.1&tabs=visual-studio）

# @page "{searchName?}"
匹配搜索，访问`https://localhost:5001/Privacy/f`就会绑定到后台`Model`的`SearchName`属性下。
