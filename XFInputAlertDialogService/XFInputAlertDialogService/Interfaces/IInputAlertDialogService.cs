using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFInputAlertDialogService.Controls.InputViews;

namespace XFInputAlertDialogService.Interfaces
{
    public interface IInputAlertDialogService
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="titleText"></param>
        /// <param name="placeHolderText"></param>
        /// <param name="closeButtonText"></param>
        /// <param name="validationLabelText"></param>
        /// <returns></returns>
        Task<string> OpenTextInputAlertDialog(
            string titleText, string placeHolderText,
            string closeButtonText, string validationLabelText);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="titleText"></param>
        /// <param name="placeHolderText"></param>
        /// <param name="saveButtonText"></param>
        /// <param name="cancelButtonText"></param>
        /// <param name="validationText"></param>
        /// <returns></returns>
        Task<string> OpenCancellableTextInputAlertDialog(string titleText, 
            string placeHolderText, string saveButtonText, 
            string cancelButtonText, string validationText);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="titleText"></param>
        /// <param name="selectiondataSource"></param>
        /// <param name="saveButtonText"></param>
        /// <param name="cancelButtonText"></param>
        /// <param name="validationText"></param>
        /// <returns></returns>
        Task<string> OpenSelectableInputAlertDialog(string titleText,
            IList<string> selectiondataSource,  string saveButtonText,
            string cancelButtonText, string validationText);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="titleText"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="saveButtonText"></param>
        /// <param name="cancelButtonText"></param>
        /// <param name="validationText"></param>
        /// <returns></returns>
        Task<double> OpenSliderInputAlertDialog(string titleText, double minValue, 
            double maxValue, string saveButtonText, 
            string cancelButtonText, string validationText);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title1Text"></param>
        /// <param name="title2Text"></param>
        /// <param name="entry1PlaceholderValue"></param>
        /// <param name="entry2PlaceholderValue"></param>
        /// <param name="sliderMinValue"></param>
        /// <param name="sliderMaxValue"></param>
        /// <param name="saveButtonText"></param>
        /// <param name="cancelButtonText"></param>
        /// <returns></returns>
        Task<MyDataModel> OpenMultipleDataInputAlertDialog
        (string title1Text, string title2Text,
            string entry1PlaceholderValue, string entry2PlaceholderValue,
            double sliderMinValue, double sliderMaxValue,
            string saveButtonText, string cancelButtonText);
    }
}
