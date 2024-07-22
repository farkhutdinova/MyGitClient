using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using MyGitClient.Executable.ViewModels;
using ReactiveUI;

namespace MyGitClient.Executable.Views;

public partial class StartView : ReactiveUserControl<IStartViewModel>
{
    private IDisposable _selectFilesInteractionDisposable;

    public StartView()
    {
        this.WhenActivated(_ => { });
        AvaloniaXamlLoader.Load(this);
    }

    protected override void OnDataContextChanged(EventArgs e)
    {
        _selectFilesInteractionDisposable?.Dispose();
    
        if (DataContext is IStartViewModel vm)
        {
            _selectFilesInteractionDisposable =
                vm.SelectFolder.RegisterHandler(async interaction =>
                {
                    var topLevel = TopLevel.GetTopLevel(this);
                
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