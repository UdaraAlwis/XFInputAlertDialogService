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
using XFInputAlertDialogService.Interfaces;

namespace XFInputAlertDialogService.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IInputAlertDialogService _inputAlertDialogService;
        private string _inputResult;

        public string InputResult
        {
            get { return _inputResult; }
            set { SetProperty(ref _inputResult, value); }
        }

        public DelegateCommand OpenTextInputAlertDialogCommand { get; set; }

        public DelegateCommand OpenCancellableTextInputAlertDialogCommand { get; set; }

        public DelegateCommand OpenSelectableInputAlertDialogCommand { get; set; }

        public DelegateCommand OpenSliderInputAlertDialogCommand { get; set; }

        public DelegateCommand OpenMultipleDataInputAlertDialogCommand { get; set; }

        public MainPageViewModel(IInputAlertDialogService inputAlertDialogService)
        {
            _inputAlertDialogService = inputAlertDialogService;

            InputResult = "-Input Results will show up here-";

            OpenTextInputAlertDialogCommand = new DelegateCommand(OpenTextInputAlertDialog);
            OpenCancellableTextInputAlertDialogCommand = new DelegateCommand(OpenCancellableTextInputAlertDialog);
            OpenSelectableInputAlertDialogCommand = new DelegateCommand(OpenSelectableInputAlertDialog);
            OpenSliderInputAlertDialogCommand = new DelegateCommand(OpenSliderInputAlertDialog);
            OpenMultipleDataInputAlertDialogCommand = new DelegateCommand(OpenMultipleDataInputAlertDialog);
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
            InputResult = "Waiting for result...";

            var result = await _inputAlertDialogService.OpenTextInputAlertDialog(
                "What's your name?", "enter here...", "Ok", "Ops! Can't leave this empty!");

            InputResult = $"-{result}-";
        }

        private async void OpenCancellableTextInputAlertDialog()
        {
            InputResult = "Waiting for result...";

            var result = await _inputAlertDialogService.OpenCancellableTextInputAlertDialog(
                "How's your day mate?", "enter here...", "Save", "Cancel", "Ops! Can't leave this empty!");

            InputResult = $"-{result}-";
        }

        private async void OpenSelectableInputAlertDialog()
        {
            InputResult = "Waiting for result...";

            var result = await _inputAlertDialogService.OpenSelectableInputAlertDialog(
                "How's your day mate?",
                new List<string>() { "Awesome!", "Great!", "Cool!", "Good!", "Not Bad!", "Meh!" },
                "Save", "Cancel", "Ops! You can't leave without a selection!");

            InputResult = $"-{result}-";
        }

        private async void OpenSliderInputAlertDialog()
        {
            InputResult = "Waiting for result...";

            var result = await _inputAlertDialogService.OpenSliderInputAlertDialog(
                "How much would you rate it?", 0, 10,
                "Save", "Cancel", "Ops! You can't leave with an empty value!");

            InputResult = $"-{result}-";
        }

        private async void OpenMultipleDataInputAlertDialog()
        {
            InputResult = "Waiting for result...";

            var result = await _inputAlertDialogService.OpenMultipleDataInputAlertDialog(
                "What's your Name?", "What's your Age?",
                "First Name", "Last Name", 0, 40,
                "Save", "Cancel");

            InputResult = $"-{result.FirstName}-\n-{result.LastName}-\n-{result.Age}-\n";
        }
        
    }
}
