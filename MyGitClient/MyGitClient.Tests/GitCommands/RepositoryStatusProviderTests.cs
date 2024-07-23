using Avalonia.Headless.XUnit;
using MyGitClient.GitCommands;
using MyGitClient.GitCommands.Internal;
using NSubstitute;

namespace MyGitClient.Tests.GitCommands;

public sealed class RepositoryStatusProviderTests
{
    [AvaloniaFact]
    public void GetStatusReturnsCorrectStatus()
    {
        var repositoryFactoryMock = Substitute.For<IRepositoryFactory>();
        var repositoryMock = Substitute.For<IRepositoryWrapper>();
        repositoryMock.RetrieveStatus()
            .Returns(new RepositoryStatus(true, "MyBranch", new List<RepoFile> {new("FilePath", true)}));
        repositoryFactoryMock.Create("MyPath").Returns(repositoryMock);

        var sut = new RepositoryStatusProvider(repositoryFactoryMock);

        var status = sut.GetStatus("MyPath");

        Assert.Equal("MyBranch", status.BranchName);
        Assert.True(status.IsDirty);
        Assert.Contains(status.ModifiedFiles, x => x.Path == "FilePath" && x.IsModified);
    }
}