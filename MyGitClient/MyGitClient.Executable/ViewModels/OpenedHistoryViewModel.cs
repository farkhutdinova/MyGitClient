using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace MyGitClient.Executable.ViewModels;

[DataContract]
public sealed class OpenedHistoryViewModel : ViewModelBase
{
    [DataMember]
    public ObservableCollection<string> PreviouslyOpenedRepositories { get; set; } = [];

    public void AddNew(string path) => PreviouslyOpenedRepositories.Add(path);
}