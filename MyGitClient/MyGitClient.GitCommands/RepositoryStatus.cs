namespace MyGitClient.GitCommands;

public record RepositoryStatus(bool IsDirty, string BranchName, IEnumerable<RepoFile> ModifiedFiles);

public record RepoFile(string Path, bool IsModified);