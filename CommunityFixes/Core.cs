using BepInEx;
using BepInEx.Logging;
using RogueLibsCore;
using System;
using System.Diagnostics;

namespace CommunityFixes
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency(RogueLibs.GUID, RogueLibs.CompiledVersion)]
    public class Core : BaseUnityPlugin
    {
        public const string PluginGuid = "freiling87.streetsofrogue.communityfixes";
        public const string PluginName = "Community Fixes";
        public const string PluginVersion = "0.1.0";

        public new static ManualLogSource Logger = null!;

        public void Awake()
        {
            Logger = base.Logger;
            RogueLibs.LoadFromAssembly();
        }
    }
}

public static class CFLogger
{
    private static string GetLoggerName(Type containingClass)
    {
        return $"CF_{containingClass.Name}";
    }

    public static ManualLogSource GetLogger()
    {
        Type containingClass = new StackFrame(1, false).GetMethod().ReflectedType;
        return Logger.CreateLogSource(GetLoggerName(containingClass));
    }
}