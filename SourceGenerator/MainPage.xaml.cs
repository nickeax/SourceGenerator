using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using System.Text;
using System.Threading;
using ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace SourceGenerator
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _vm;

        public MainPage(MainPageViewModel vm)
        {
            _vm = vm;
            BindingContext = _vm;
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            // Show toast and return if the input text is empty
            if (string.IsNullOrWhiteSpace(_vm.InputText))
            {
                await Toast.Make("Please enter some text in the input box").Show(default);
                return;
            }

            var stream = new MemoryStream(Encoding.Default.GetBytes(_vm.OutputText ?? ""));
            var res = await FileSaver.Default.SaveAsync("output.txt", stream, default);

            if (res.IsSuccessful)
            {
                _vm.OutputText = res.FilePath;
            }
            else
            {
                //await Toast.Make($"The file was not saved successfully with error: {res.Exception.Message}").Show();
            }
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            Clipboard.Default.ClipboardContentChanged += Clipboard_ClipboardContentChanged;
        }

        private async void Clipboard_ClipboardContentChanged(object sender, EventArgs e)
        {
            _vm.OutputText = await Clipboard.Default.GetTextAsync() ?? "";
        }
    }

}
