using BepInEx.Configuration;
using BepInEx.Unity.Mono.Configuration;
using UnityEngine;

namespace AlienTrainer;

public class HotkeyManager : MonoBehaviour {
    private static ConfigEntry<KeyboardShortcut> _configWordTestHotkey;
    
    public void Awake() {
        _configWordTestHotkey = Plugin.Config.Bind("Hotkeys", "WordTestHotkey",
            new KeyboardShortcut(KeyCode.F9), "Hotkey of word test (translation)");
    }

    public void Update() {
        if (_configWordTestHotkey.Value.IsDown()) {
            WordTestFeature.Enabled = !WordTestFeature.Enabled;
        }
    }
}