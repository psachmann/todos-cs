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

public class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.Compile);

    private readonly AbsolutePath Solution = RootDirectory / "Todos.sln";
    private readonly AbsolutePath SrcDirectory = RootDirectory / "src";
    private readonly AbsolutePath TestDirectory = RootDirectory / "test";

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SrcDirectory.GlobDirectories("**/bin", "**/obj").ForEach(dir => dir.DeleteDirectory());
            TestDirectory.GlobDirectories("**/bin", "**/obj").ForEach(dir => dir.DeleteDirectory());
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetTasks.DotNetRestore(_ => _
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetTasks.DotNetBuild(_ => _
                .SetNoLogo(true)
                .SetNoRestore(true)
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration));
        });

    Target Test => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetTasks.DotNetTest(_ => _
                .SetNoLogo(true)
                .SetNoRestore(true)
                .SetNoBuild(true)
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration));
        });
}
