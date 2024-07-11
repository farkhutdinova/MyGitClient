using System;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using MyGitClient.Executable.ViewModels;

namespace MyGitClient.Executable.Views;

public partial class MainWindow : Window
{
    private IDisposable? _selectFilesInteractionDisposable;

    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnDataContextChanged(EventArgs e)
    {
        _selectFilesInteractionDisposable?.Dispose();

        if (DataContext is MainWindowViewModel vm)
        {
            _selectFilesInteractionDisposable =
                vm.SelectFilesInteraction.RegisterHandler(_ => InteractionHandler("Select a folder"));
        }

        base.OnDataContextChanged(e);
    }
    
    private async Task<string> InteractionHandler(string input)
    {
        var topLevel = GetTopLevel(this);

        var storageFiles = await topLevel!.StorageProvider.OpenFolderPickerAsync(
            new FolderPickerOpenOptions
            { 
                AllowMultiple = false,
                Title = input
            });

        return storageFiles.Select(f => f.Path.AbsolutePath).FirstOrDefault() ?? string.Empty;
    }
}