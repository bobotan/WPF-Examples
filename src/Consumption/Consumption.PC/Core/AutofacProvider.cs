﻿/*
*
* 文件名    ：AutofacProvider                             
* 程序说明  : 获取Autofac注册的依赖关系实现
* 更新时间  : 2020-05-21 16：09
* 联系作者  : QQ:779149549 
* 开发者群  : QQ群:874752819
* 邮件联系  : zhouhaogg789@outlook.com
* 视频教程  : https://space.bilibili.com/32497462
* 博客地址  : https://www.cnblogs.com/zh7791/
* 项目地址  : https://github.com/HenJigg/WPF-Xamarin-Blazor-Examples
* 项目说明  : 以上所有代码均属开源免费使用,禁止个人行为出售本项目源代码
*/

namespace Consumption.PC.Core
{
    using Consumption.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Text;

    /// <summary>
    /// Autofac 服务提供者
    /// </summary>
    public class AutofacProvider
    {
        public static IAutoFacLocator Instance { get; private set; }

        public static void RegisterServiceLocator(IAutoFacLocator locator)
        {
            if (Instance == null)
            {
                Instance = locator;
            }
        }

        public static T Get<T>()
        {
            if (Instance == null) return default(T);
            return Instance.Get<T>();
        }

        public static T Get<T>(string typeName)
        {
            if (Instance == null) return default(T);
            return Instance.Get<T>(typeName);
        }
    }
}