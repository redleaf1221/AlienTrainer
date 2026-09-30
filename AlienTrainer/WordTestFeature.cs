using BepInEx.Configuration;
using UnityEngine;

namespace AlienTrainer;

public static class WordTestFeature {
    private static ConfigEntry<bool> _configEnabled;

    public static bool Enabled {
        get => _configEnabled.Value;
        set => _configEnabled.Value = value;
    }

    public static void Init() {
        _configEnabled = Plugin.Config.Bind("Trainer", "WordTest",
            false, "Show official translation of words.");

        _configEnabled.SettingChanged += (sender, args) => {
            Plugin.Logger.LogInfo($"WordTest changed to {Enabled}.");
            Global.testword = Enabled;
            foreach (var alienCharacter in Object.FindObjectsOfType<AlienCharacter>()) {
                alienCharacter.UpdateEarthText();
            }
        };
    }
}