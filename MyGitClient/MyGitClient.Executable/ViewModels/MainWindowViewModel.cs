using System.Reactive;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public class MainWindowViewModel : ReactiveObject, IScreen
{
    public RoutingState Router { get; } = new();

    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

    // public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack;

    public MainWindowViewModel()
    {
        GoNext = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new StartViewModel(this))
        );
    }
}