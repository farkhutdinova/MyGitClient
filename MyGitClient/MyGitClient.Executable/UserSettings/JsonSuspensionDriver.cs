using System;
using System.IO;
using System.Reactive;
using System.Reactive.Linq;
using System.Text.Json;
using MyGitClient.Executable.ViewModels;
using ReactiveUI;

namespace MyGitClient.Executable.UserSettings;

internal sealed class JsonSuspensionDriver(string file) : ISuspensionDriver
{
    public IObservable<object> LoadState()
    {
        var jsonString = File.ReadAllText(file);
        var state = JsonSerializer.Deserialize<OpenedHistoryViewModel>(jsonString); // TODO @evgn it hould not know about the type, or?
        return Observable.Return(state);
    }

    public IObservable<Unit> SaveState(object state)
    {
        var jsonString = JsonSerializer.Serialize(state);
        File.WriteAllText(file, jsonString);
        return Observable.Return(Unit.Default);
    }

    public IObservable<Unit> InvalidateState()
    {
        if (File.Exists(file)) 
            File.Delete(file);
        return Observable.Return(Unit.Default);
    }
}