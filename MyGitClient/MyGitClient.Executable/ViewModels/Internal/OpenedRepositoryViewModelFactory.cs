﻿using MyGitClient.GitCommands;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels.Internal;

internal sealed class OpenedRepositoryViewModelFactory(IRepositoryStatusProvider repositoryStatusProvider, ICommitCommand commitCommand) : IOpenedRepositoryViewModelFactory
{
    public IOpenedRepositoryViewModel Create(IScreen hostScreen, string repoPath)
    {
        return new OpenedRepositoryViewModel(hostScreen, repoPath, repositoryStatusProvider, commitCommand);
    }
}