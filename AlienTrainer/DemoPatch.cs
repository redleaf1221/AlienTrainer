using HarmonyLib;

namespace AlienTrainer;

[HarmonyPatch]
public class DemoPatch {
    [HarmonyPrefix]
    [HarmonyPatch(typeof(Global), nameof(Global.Init))]
    public static void InitPatch() {
        Global.isDemo = false;
    }
}