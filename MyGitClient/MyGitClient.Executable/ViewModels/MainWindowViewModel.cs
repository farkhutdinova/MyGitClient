using System.Reactive;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

public sealed class MainWindowViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; } = new();

    public ReactiveCommand<Unit, IRoutableViewModel> GoNext { get; }

    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack;

    public MainWindowViewModel(IStartViewModelFactory startViewModelFactory)
    {
        GoNext = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(startViewModelFactory.Create(this)));
    }
}