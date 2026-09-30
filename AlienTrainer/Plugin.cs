using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using BepInEx.Unity.Mono;
using HarmonyLib;

namespace AlienTrainer;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
    public new static ManualLogSource Logger;
    
    public new static ConfigFile Config;
    
    public static Harmony HarmonyInstance;


    private void Awake() {
        // Plugin startup logic
        Logger = base.Logger;
        Config = base.Config;
        
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        
        HarmonyInstance = new Harmony(MyPluginInfo.PLUGIN_NAME);
        HarmonyInstance.PatchAll(typeof(DemoPatch));
        
        WordTestFeature.Init();

        gameObject.AddComponent<HotkeyManager>();
    }
}