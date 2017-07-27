﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Services;
using XFInputAlertDialogService.Controls;
using XFInputAlertDialogService.Controls.InputViews;
using XFInputAlertDialogService.Interfaces;

namespace XFInputAlertDialogService.Services
{
    public class InputAlertDialogService : IInputAlertDialogService
    {
        public async Task<string> OpenTextInputAlertDialog(string titleText, string placeHolderText,
            string closeButtonText, string validationLabelText)
        {
            // create the TextInputView
            var inputView = new TextInputView(
                "What's your name?", "enter here...", "Ok", "Ops! Can't leave this empty!");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<string>(inputView);

            // subscribe to the TextInputView's Button click event
            inputView.CloseButtonEventHandler +=
                (sender, obj) =>
                {
                    if (!string.IsNullOrEmpty(((TextInputView)sender).TextInputResult))
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = false;
                        popup.PageClosedTaskCompletionSource.SetResult(((TextInputView)sender).TextInputResult);
                    }
                    else
                    {
                        ((TextInputView)sender).IsValidationLabelVisible = true;
                    }
                };

            // Push the page to Navigation Stack
            await PopupNavigation.PushAsync(popup);

            // await for the user to enter the text input
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
            return result;
        }

        public async Task<string> OpenCancellableTextInputAlertDialog(string titleText, string placeHolderText, string saveButtonText,
            string cancelButtonText, string validationText)
        {
            // create the TextInputView
            var inputView = new TextInputCancellableView(
                "How's your day mate?", "enter here...", "Save", "Cancel", "Ops! Can't leave this empty!");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<string>(inputView);

            // subscribe to the TextInputView's Button click event
            inputView.SaveButtonEventHandler +=
                (sender, obj) =>
                {
                    if (!string.IsNullOrEmpty(((TextInputCancellableView)sender).TextInputResult))
                    {
                        ((TextInputCancellableView)sender).IsValidationLabelVisible = false;
                        popup.PageClosedTaskCompletionSource.SetResult(((TextInputCancellableView)sender).TextInputResult);
                    }
                    else
                    {
                        ((TextInputCancellableView)sender).IsValidationLabelVisible = true;
                    }
                };

            // subscribe to the TextInputView's Button click event
            inputView.CancelButtonEventHandler +=
                (sender, obj) =>
                {
                    popup.PageClosedTaskCompletionSource.SetResult(null);
                };

            // Push the page to Navigation Stack
            await PopupNavigation.PushAsync(popup);

            // await for the user to enter the text input
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
            return result;
        }

        public async Task<string> OpenSelectableInputAlertDialog(string titleText, IList<string> selectiondataSource, string saveButtonText,
            string cancelButtonText, string validationText)
        {

            // create the TextInputView
            var inputView = new SelectableInputView(
                "How's your day mate?",
                new List<string>() { "Awesome!", "Great!", "Cool!", "Good!", "Not Bad!", "Meh!" },
                "Save", "Cancel", "Ops! You can't leave without a selection!");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<string>(inputView);

            // subscribe to the TextInputView's Button click event
            inputView.SaveButtonEventHandler +=
                (sender, obj) =>
                {
                    if (!string.IsNullOrEmpty(((SelectableInputView)sender).SelectionResult))
                    {
                        ((SelectableInputView)sender).IsValidationLabelVisible = false;
                        popup.PageClosedTaskCompletionSource.SetResult(((SelectableInputView)sender).SelectionResult);
                    }
                    else
                    {
                        ((SelectableInputView)sender).IsValidationLabelVisible = true;
                    }
                };

            // subscribe to the TextInputView's Button click event
            inputView.CancelButtonEventHandler +=
                (sender, obj) =>
                {
                    popup.PageClosedTaskCompletionSource.SetResult(null);
                };

            // Push the page to Navigation Stack
            await PopupNavigation.PushAsync(popup);

            // await for the user to enter the text input
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
            return result;
        }

        public async Task<double> OpenSliderInputAlertDialog(string titleText, double minValue, double maxValue, string saveButtonText,
            string cancelButtonText, string validationText)
        {
            // create the TextInputView
            var inputView = new SlidableInputView(
                "How much would you rate it?", 0, 10,
                "Save", "Cancel", "Ops! You can't leave with an empty value!");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<double>(inputView);

            // subscribe to the TextInputView's Button click event
            inputView.SaveButtonEventHandler +=
                (sender, obj) =>
                {
                    if (((SlidableInputView)sender).SliderInputResult > 0)
                    {
                        ((SlidableInputView)sender).IsValidationLabelVisible = false;
                        popup.PageClosedTaskCompletionSource.SetResult(((SlidableInputView)sender).SliderInputResult);
                    }
                    else
                    {
                        ((SlidableInputView)sender).IsValidationLabelVisible = true;
                    }
                };

            // subscribe to the TextInputView's Button click event
            inputView.CancelButtonEventHandler +=
                (sender, obj) =>
                {
                    popup.PageClosedTaskCompletionSource.SetResult(0);
                };

            // Push the page to Navigation Stack
            await PopupNavigation.PushAsync(popup);

            // await for the user to enter the text input
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
            return result;
        }

        public async Task<MyDataModel> OpenMultipleDataInputAlertDialog(string title1Text, string title2Text, string entry1PlaceholderValue,
            string entry2PlaceholderValue, double sliderMinValue, double sliderMaxValue, string saveButtonText,
            string cancelButtonText)
        {
            // create the TextInputView
            var inputView = new MultipleDataInputView(
                "What's your Name?", "What's your Age?",
                "First Name", "Last Name", 0, 40,
                "Save", "Cancel");

            // create the Transparent Popup Page
            // of type string since we need a string return
            var popup = new InputAlertDialogBase<MyDataModel>(inputView);

            // subscribe to the TextInputView's Button click event
            inputView.SaveButtonEventHandler +=
                (sender, obj) =>
                {
                    // handle validations
                    if (string.IsNullOrEmpty(((MultipleDataInputView)sender).MultipleDataResult.FirstName))
                    {
                        ((MultipleDataInputView)sender).ValidationLabelText = "Ops! You need to enter the First name!";
                        ((MultipleDataInputView)sender).IsValidationLabelVisible = true;
                        return;
                    }

                    if (string.IsNullOrEmpty(((MultipleDataInputView)sender).MultipleDataResult.LastName))
                    {
                        ((MultipleDataInputView)sender).ValidationLabelText = "Ops! You need to enter the Last name!";
                        ((MultipleDataInputView)sender).IsValidationLabelVisible = true;
                        return;
                    }

                    if (((MultipleDataInputView)sender).MultipleDataResult.Age < 18)
                    {
                        ((MultipleDataInputView)sender).ValidationLabelText = "Ops! You need to be over 18 years of Age!";
                        ((MultipleDataInputView)sender).IsValidationLabelVisible = true;
                        return;
                    }

                    // if all good then set the Result
                    ((MultipleDataInputView)sender).IsValidationLabelVisible = false;
                    popup.PageClosedTaskCompletionSource.SetResult(((MultipleDataInputView)sender).MultipleDataResult);
                };

            // subscribe to the TextInputView's Button click event
            inputView.CancelButtonEventHandler +=
                (sender, obj) =>
                {
                    popup.PageClosedTaskCompletionSource.SetResult(null);
                };

            // Push the page to Navigation Stack
            await PopupNavigation.PushAsync(popup);

            // await for the user to enter the text input
            var result = await popup.PageClosedTask;

            // Pop the page from Navigation Stack
            await PopupNavigation.PopAsync();

            // return user inserted text value
            return result;
        }
    }
}
