using CommunityToolkit.Mvvm.ComponentModel;
using SmartWeightLib.Models;
using SmartWeightAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartVægtApp.ViewModels
{
    [ObservableObject]
    public partial class BaseViewModel
    {
        public BaseViewModel()
        {
            RefreshCommand = new(async () =>
            {
                IsRefreshing = true;
                await OnRefreshing();
                IsRefreshing = false;
            });
        }

        protected void PostApi<Content>(Endpoints endpoint, string url, Content content)
        {
            
        }
        public User Client { get; set; }

        #region RefreshCommand
        public Command RefreshCommand { get; set; }

        [ObservableProperty]
        private bool isRefreshing = false;
        /// <summary>
        /// Override whenever you want to do something when the refresh command is called
        /// </summary>
        protected virtual async Task OnRefreshing() { await Task.CompletedTask; }
        #endregion

        protected static Task GoToAsync(ShellNavigationState state) => Shell.Current.GoToAsync(state);
    }
}
