namespace MyGitClient.GitCommands;

public record RepositoryStatus(bool IsDirty, string BranchName, IEnumerable<ModifiedRepoFile> ModifiedFiles);

public record ModifiedRepoFile(string Path, bool IsStaged);