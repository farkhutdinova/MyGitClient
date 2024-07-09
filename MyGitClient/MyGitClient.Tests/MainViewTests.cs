using Avalonia.Headless.XUnit;
using MyGitClient.Executable.ViewModels;
using MyGitClient.Executable.Views;

namespace MyGitClient.Tests;

public class MainViewTests
{
    [AvaloniaFact]
    public void CanBrowseNewRepo()
    {
        var window = new MainWindow
        {
            DataContext = new MainWindowViewModel(null)
        };

        window.Show();

        var openNewRepoButton = window.OpenButton;
        Assert.NotNull(openNewRepoButton);
        Assert.NotNull(openNewRepoButton.Command);
        Assert.True(openNewRepoButton.Command.CanExecute(null));
    }
}