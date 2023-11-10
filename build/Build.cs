using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;

class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode


    public static int Main() => Execute<Build>(x => x.Compile);

    private readonly string ProjectFile = RootDirectory / "Todos.sln";

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    private Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
        });

    private Target Restore => _ => _
        .Executes(() =>
        {
            DotNetTasks.DotNetRestore((settings) => settings
                .SetProjectFile(ProjectFile));
        });

    private Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetTasks.DotNetBuild((settings) => settings
                .EnableNoLogo()
                .EnableNoRestore()
                .SetProjectFile(ProjectFile));
        });

    private Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTasks.DotNetTest((settings) => settings
                .EnableNoLogo()
                .EnableNoRestore()
                .EnableNoBuild()
                .SetConfiguration(Configuration)
                .SetProjectFile(ProjectFile));
        });
}
