using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using XFInputAlertDialogService.Controls.InputViews;

namespace XFInputAlertDialogService.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public string Result { get; set; }

        public DelegateCommand OpenTextInputAlertDialogCommand { get; set; }

        public MainPageViewModel()
        {
            OpenTextInputAlertDialogCommand = new DelegateCommand(OpenTextInputAlertDialog);
        }
        
        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        private async void OpenTextInputAlertDialog()
        {
            //InputResultLabel.Text = "Waiting for result...";
            //var result = await OpenTextInputAlertDialog();
            //InputResultLabel.Text = $"-{result}-";
        }

        private async void OpenCancellableTextInputAlertDialogButton_OnClicked(object sender, EventArgs e)
        {
            //InputResultLabel.Text = "Waiting for result...";
            //var result = await OpenCancellableTextInputAlertDialog();
            //InputResultLabel.Text = $"-{result}-";
        }

        private async void OpenSelectableInputAlertDialogButton_OnClicked(object sender, EventArgs e)
        {
            //InputResultLabel.Text = "Waiting for result...";
            //var result = await OpenSelectableInputAlertDialog();
            //InputResultLabel.Text = $"-{result}-";
        }

        private async void OpenSliderInputAlertDialogButton_OnClicked(object sender, EventArgs e)
        {
            //InputResultLabel.Text = "Waiting for result...";
            //var result = await OpenSliderInputAlertDialog();
            //InputResultLabel.Text = $"-{result}-";
        }

        private async void OpenMultipleDataInputAlertDialogButton_OnClicked(object sender, EventArgs e)
        {
            //InputResultLabel.Text = "Waiting for result...";
            //var result = await OpenMultipleDataInputAlertDialog();

            //var resultString = $"-{result.FirstName}-\n-{result.LastName}-\n-{result.Age}-\n";
            //InputResultLabel.Text = $"{resultString}";
        }
        
    }
}
