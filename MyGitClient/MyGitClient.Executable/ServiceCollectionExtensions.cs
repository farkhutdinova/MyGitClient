using Microsoft.Extensions.DependencyInjection;
using MyGitClient.Executable.ViewModels;
using MyGitClient.Executable.ViewModels.Internal;

namespace MyGitClient.Executable;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddTransient<MainWindowViewModel>();
        collection.AddSingleton<IOpenedRepositoryViewModelFactory, OpenedRepositoryViewModelFactory>();
        collection.AddSingleton<IStartViewModelFactory, StartViewModelFactory>();
    }
}