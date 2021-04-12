﻿using Consumption.Core.Common;
using Consumption.PC.Views;
using Consumption.Service;
using Consumption.Shared.DataInterfaces;
using Consumption.ViewModel;
using Consumption.ViewModel.Interfaces;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Windows;

namespace Consumption.PC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public App()
        {
            App.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IUserRepository, UserService>();
            containerRegistry.Register<IGroupRepository, GroupService>();
            containerRegistry.Register<IMenuRepository, MenuService>();
            containerRegistry.Register<IBasicRepository, BasicService>();
            containerRegistry.Register<ILog, ConsumptionNLog>();


            containerRegistry.RegisterForNavigation<HomeView>("HomeView");
            containerRegistry.RegisterForNavigation<SkinView>("SkinView");
            containerRegistry.RegisterForNavigation<BasicView, BasicViewModel>("BasicView");
            containerRegistry.RegisterForNavigation<GroupView, GroupViewModel>("GroupView");
            containerRegistry.RegisterForNavigation<MenuView, MenuViewModel>("MenuView");
            containerRegistry.RegisterForNavigation<UserView, UserViewModel>("UserView");
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            var win = Container.Resolve<LoginView>();
            var result = (bool)win.ShowDialog();
            if (result)
            {
                base.OnInitialized();
            }
            else
                Environment.Exit(0);
        }
    }
}
