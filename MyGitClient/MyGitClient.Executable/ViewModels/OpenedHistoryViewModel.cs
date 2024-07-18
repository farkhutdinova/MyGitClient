using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using ReactiveUI;

namespace MyGitClient.Executable.ViewModels;

[DataContract]
public class OpenedHistoryViewModel : ReactiveObject
{
    [DataMember]
    public ObservableCollection<string> PreviouslyOpenedRepositories { get; set; } = [];

    public void AddNew(string path) => PreviouslyOpenedRepositories.Add(path);
}