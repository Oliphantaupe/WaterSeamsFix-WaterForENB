using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Synthesis.Settings;

namespace WaterSeamsFix.Settings;

public class Settings
{
    [SynthesisSettingName("Main Water for ENB Plugin")]
    [SynthesisTooltip(
        "Select ONLY your main Water for ENB plugin. Common options:\n\n" +
        "Standard Colors:\n" +
        "• Water for ENB.esp\n" +
        "• Water for ENB (iNeed).esp\n" +
        "• Water for ENB (Wavy Rivers).esp\n" +
        "• Water for ENB (Wavy Rivers) (iNeed).esp\n" +
        "• Water for ENB (Vanilla).esp\n" +
        "• Water for ENB (Vanilla) (iNeed).esp\n\n" +
        "Alternative Colors:\n" +
        "• Water for ENB (Mineral Teal).esp\n" +
        "• Water for ENB (Mineral Teal) (iNeed).esp\n" +
        "• Water for ENB (Tropical Green).esp\n" +
        "• Water for ENB (Tropical Green) (iNeed).esp\n\n" +
        "Shades of Skyrim (Regional Colors):\n" +
        "• Water for ENB (Shades of Skyrim).esp\n" +
        "• Water for ENB (Shades of Skyrim) (Less Transparent).esp\n" +
        "• Water for ENB (Shades of Skyrim) (Darker).esp\n" +
        "• Water for ENB (Shades of Skyrim) (iNeed).esp\n" +
        "• Water for ENB (Shades of Skyrim) (Less Transparent) (iNeed).esp\n" +
        "• Water for ENB (Shades of Skyrim) (Darker) (iNeed).esp\n\n" +
        "DO NOT select patches here (JK's, Lux, etc.) - they are auto-detected.")]
    public ModKey WaterForEnbPlugin { get; set; } = ModKey.FromNameAndExtension("Water for ENB (Shades of Skyrim).esp");

    [SynthesisSettingName("Include Base ESM (Shades of Skyrim users)")]
    [SynthesisTooltip(
        "Only relevant if using Shades of Skyrim.\n\n" +
        "When enabled, also processes 'Water for ENB.esm' alongside the Shades of Skyrim ESP.\n" +
        "This ensures both base water changes AND regional colors are forwarded.\n\n" +
        "If you're using standard 'Water for ENB.esp', this setting has no effect.")]
    public bool IncludeBaseEsm { get; set; } = true;

    [SynthesisSettingName("Mods to Skip")]
    [SynthesisTooltip(
        "Patches that should KEEP their water changes instead of being overwritten.\n\n" +
        "Use this for mods that intentionally modify water in specific areas.\n\n" +
        "Leave empty if you want all water to match W4ENB.")]
    public List<ModKey> ModsToSkip { get; set; } = new();

    [SynthesisSettingName("Verbose Logging")]
    [SynthesisTooltip(
        "Shows every cell/worldspace being patched in the console.\n" +
        "Useful for debugging. Disabled by default for cleaner output.")]
    public bool VerboseOutput { get; set; } = false;
}
