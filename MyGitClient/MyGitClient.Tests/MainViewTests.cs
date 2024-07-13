using Avalonia.Headless.XUnit;
using MyGitClient.Executable.ViewModels;
using MyGitClient.Executable.Views;

namespace MyGitClient.Tests;

public class MainViewTests
{
    [AvaloniaFact]
    public void CanBrowseRepo()
    {
        var vm = new MainWindowViewModel();
        vm.SelectFolder.RegisterHandler(interaction => interaction.SetOutput("MyPath"));

        var window = new MainWindow
        {
            DataContext = vm
        };

        window.Show();

        var openNewRepoButton = window.OpenButton;
        Assert.NotNull(openNewRepoButton);
        Assert.NotNull(openNewRepoButton.Command);
        Assert.True(openNewRepoButton.Command.CanExecute(null));
    }

    [AvaloniaFact]
    public void CanSelectFolder()
    {
        var vm = new MainWindowViewModel();
        vm.SelectFolder.RegisterHandler(interaction => interaction.SetOutput("MyPath"));

        vm.BrowseRepoCommand.Execute();

        Assert.Equal("MyPath", vm.SelectedFolderPath);
    }
}