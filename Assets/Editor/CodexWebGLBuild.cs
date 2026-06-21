using UnityEditor;
using UnityEditor.Build.Reporting;

public static class CodexWebGLBuild
{
    public static void Build()
    {
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Disabled;
        PlayerSettings.WebGL.decompressionFallback = false;

        var options = new BuildPlayerOptions
        {
            scenes = new[] { "Assets/Scenes/MainScene.unity" },
            locationPathName = "Build",
            target = BuildTarget.WebGL,
            options = BuildOptions.None
        };

        BuildReport report = BuildPipeline.BuildPlayer(options);
        if (report.summary.result != BuildResult.Succeeded)
        {
            throw new System.Exception($"WebGL build failed: {report.summary.result}");
        }
    }
}
