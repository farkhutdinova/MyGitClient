using System;
using System.Linq;
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
                vm.SelectFolder.RegisterHandler(async interaction =>
                {
                    var topLevel = GetTopLevel(this);

                    var storageFiles = await topLevel!.StorageProvider.OpenFolderPickerAsync(
                        new FolderPickerOpenOptions
                        { 
                            AllowMultiple = false,
                            Title = interaction.Input
                        });

                    var selectedFolderPath = storageFiles.Select(f => f.Path.AbsolutePath).FirstOrDefault() ?? string.Empty;

                    interaction.SetOutput(selectedFolderPath);
                });
        }

        base.OnDataContextChanged(e);
    }
}