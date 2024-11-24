using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Services;

namespace ViewModels;
public partial class MainPageViewModel : ObservableObject
{
    FileService _fileService;

    public MainPageViewModel(FileService fileService)
    {
        _fileService = fileService;
    }

    [ObservableProperty]
    public string inputText;

    [ObservableProperty]
    public string outputText;

    public MainPageViewModel()
    {
        InputText = string.Empty;
        OutputText = string.Empty;
    }

    partial void OnInputTextChanged(string value)
    {
        OutputText = InputText.ToUpper();
    }

    [RelayCommand]
    async public Task SaveToFile(string fileName)
    {
        await _fileService.SaveToFile(fileName, OutputText);
    }
}
