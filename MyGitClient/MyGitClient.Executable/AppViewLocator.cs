using System;
using MyGitClient.Executable.ViewModels;
using MyGitClient.Executable.ViewModels.Internal;
using MyGitClient.Executable.Views;
using ReactiveUI;

namespace MyGitClient.Executable;

public class AppViewLocator : IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null) => viewModel switch
    {
        StartViewModel context => new StartView {DataContext = context},
        OpenedRepositoryViewModel context => new OpenedRepositoryView {DataContext = context},
        _ => throw new ArgumentOutOfRangeException(nameof(viewModel))
    };
}