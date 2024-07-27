using Microsoft.Extensions.DependencyInjection;
using MyGitClient.GitCommands.Internal;

namespace MyGitClient.GitCommands;

public static class ServiceCollectionExtension
{
    public static void AddRepositoryStatusProvider(this IServiceCollection services)
    {
        services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
        services.AddTransient<IRepositoryStatusProvider, RepositoryStatusProvider>();
        services.AddSingleton<ICommitCommand, CommitCommand>();
    }
}