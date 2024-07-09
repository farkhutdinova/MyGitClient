using Microsoft.Extensions.DependencyInjection;
using MyGitClient.Executable.ViewModels;

namespace MyGitClient.Executable;

public static class ServiceCollectionExtensions {
    public static void AddCommonServices(this IServiceCollection collection) {
        collection.AddTransient<MainWindowViewModel>();
    }
}