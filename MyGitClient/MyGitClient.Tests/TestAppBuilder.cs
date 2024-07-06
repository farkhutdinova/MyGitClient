using Avalonia;
using Avalonia.Headless;
using Avalonia.ReactiveUI;
using MyGitClient.Executable;
using MyGitClient.Tests;

[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]

namespace MyGitClient.Tests;

public class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() => 
        AppBuilder.Configure<App>()
        .UseHeadless(new AvaloniaHeadlessPlatformOptions())
        .UseReactiveUI();
}