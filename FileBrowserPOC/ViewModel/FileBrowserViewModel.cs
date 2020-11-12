using System;
using System.ComponentModel;
using Xamarin.Forms;
using Plugin.FilePicker;
using System.IO;

namespace FileBrowserPOC.ViewModel
{
    public class FileBrowserViewModel : INotifyPropertyChanged
    {
        string[] fileTypes = null;
        public FileBrowserViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private string fileName { get; set; }

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        private Command _btnClickCommand { get; set; }

        public Command btnClickCommand
        {
            get
            {
                return _btnClickCommand ?? new Command(async () =>
                {
                    await BrowseFileAsync();
                });
            }
        }
        private async System.Threading.Tasks.Task BrowseFileAsync()
        {
            //var file = await CrossFilePicker.Current.PickFile();

            try
            {
                var file = await CrossFilePicker.Current.PickFile(GetFileTypeBasedOnPlatform());
                if (file != null)
                {
                    var fileNome = Path.GetFileName(file.FileName);
                    var fileExtensao = Path.GetExtension(fileNome);
                    float fileSize = file.DataArray.Length; fileSize = fileSize / 1024;
                    
                    if (file != null)
                    {
                        FileName = file.FileName;
                    }
                    else
                        FileName = "Not Selected";
                }
            }
            catch (Exception ex)
            {

            }
        }
        internal string[] GetFileTypeBasedOnPlatform()
        {

            if (Device.RuntimePlatform == Device.Android)
            {
                fileTypes = new string[] { "application/pdf", "application/msword", "text/rtf", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };//Image "image/jpeg"
            }

            if (Device.RuntimePlatform == Device.iOS)
            {
                fileTypes = new string[] { "public.image" }; // same as iOS constant UTType.Image
            }
            return fileTypes;
        }
    }
}
