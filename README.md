# Water Seams Fix - Water for ENB

A [Synthesis](https://github.com/Mutagen-Modding/Synthesis) patcher for Skyrim Special Edition that forwards Water for ENB edits to win conflicts.

## The Problem

Water for ENB makes extensive changes to cells - setting water types, water heights, environment maps, and LOD water. When other mods edit the same cells for unrelated reasons (adding NPCs, trees, objects, etc.), they can accidentally overwrite W4ENB's water changes, causing visible seams and inconsistencies.

## What This Patcher Does

1. **Finds** your main Water for ENB plugin
2. **Auto-detects** all patches that depend on it (JK's, Lux, etc.)
3. **Compares** each cell's water data against the current winning override
4. **Forwards** W4ENB's water edits when they differ from the winner
5. **Skips** cells where W4ENB is already winning (prevents output bloat)

### Fields Patched

| Field | Description |
|-------|-------------|
| `Water` (XCWT) | Reference to water type used in cell |
| `WaterEnvironmentMap` | Cubemap for water reflections |
| `WaterHeight` | Water surface elevation |
| `HasWater` flag | Cell flag indicating water presence |
| `LodWater` | Worldspace LOD water type |

---

## Understanding Water for ENB Setups

Water for ENB offers multiple water color variants. You'll have ONE of these main plugins installed:

### Standard Single-Color Variants

| Water Style | Main Plugin File |
|-------------|------------------|
| Standard Blue | `Water for ENB.esp` or `Water for ENB (iNeed).esp` |
| Wavy Rivers | `Water for ENB (Wavy Rivers).esp` or `Water for ENB (Wavy Rivers) (iNeed).esp` |
| Vanilla-like | `Water for ENB (Vanilla).esp` or `Water for ENB (Vanilla) (iNeed).esp` |
| Mineral Teal | `Water for ENB (Mineral Teal).esp` or `Water for ENB (Mineral Teal) (iNeed).esp` |
| Tropical Green | `Water for ENB (Tropical Green).esp` or `Water for ENB (Tropical Green) (iNeed).esp` |

### Shades of Skyrim (Regional Colors)

Shades of Skyrim uses **two plugins** working together:
- `Water for ENB.esm` (or `Water for ENB (iNeed).esm`) - base water definitions
- `Water for ENB (Shades of Skyrim).esp` - **this is your main plugin to select**

Shades of Skyrim also has transparency/darkness variants:
- `Water for ENB (Shades of Skyrim).esp` - standard
- `Water for ENB (Shades of Skyrim) (Less Transparent).esp`
- `Water for ENB (Shades of Skyrim) (Darker).esp`

iNeed versions add `(iNeed)` to the filename.

---

**Compatibility Patches:** All other `.esp` files (JK's patches, Lux patches, etc.) are compatibility patches that have your main plugin as a master. These are **auto-detected** by the patcher - don't select them manually.

---

## Settings

### Main Water for ENB Plugin

**Select ONLY your main W4ENB plugin** (the one you chose during FOMOD installation):

**Standard Colors:**
- `Water for ENB.esp` / `Water for ENB (iNeed).esp`
- `Water for ENB (Wavy Rivers).esp` / `Water for ENB (Wavy Rivers) (iNeed).esp`
- `Water for ENB (Vanilla).esp` / `Water for ENB (Vanilla) (iNeed).esp`

**Alternative Colors:**
- `Water for ENB (Mineral Teal).esp` / `Water for ENB (Mineral Teal) (iNeed).esp`
- `Water for ENB (Tropical Green).esp` / `Water for ENB (Tropical Green) (iNeed).esp`

**Shades of Skyrim (Regional Colors):**
- `Water for ENB (Shades of Skyrim).esp`
- `Water for ENB (Shades of Skyrim) (Less Transparent).esp`
- `Water for ENB (Shades of Skyrim) (Darker).esp`
- iNeed versions: add `(iNeed)` before `.esp`

> ⚠️ **DO NOT select patches here** (JK's, Lux, etc.) - they are detected automatically because they have your main plugin as a master.

---

### Include Base ESM (Shades of Skyrim users only)

**Default: Enabled**

| Your Setup | What This Does |
|------------|----------------|
| Standard (`Water for ENB.esp`) | Has no effect - ignore this setting |
| Shades of Skyrim | When enabled, processes both `Water for ENB.esm` AND `Water for ENB (Shades of Skyrim).esp` |

> **Recommendation:** Keep enabled if using Shades of Skyrim to forward all water changes.

---

### Mods to Skip

Add patches that should **KEEP their intentional water changes**.

> **Leave empty** if you want all water to match the main W4ENB style.

---

### Verbose Logging

**Default: Disabled**

When enabled, prints every cell/worldspace being patched. Useful for debugging.

---

## Quick Setup Guide

### Setup A: Single-Color Variants

Applies to: Standard, Wavy Rivers, Vanilla, Mineral Teal, Tropical Green

```
Your load order:
  Water for ENB.esp (or your chosen variant)
  └─ Water for ENB - Patch - JKs Skyrim.esp
  └─ Water for ENB - Patch - Lux.esp
  └─ ... other patches ...
```

**Settings:**
- Main Plugin: Your main W4ENB plugin (e.g., `Water for ENB (Mineral Teal).esp`)
- Include Base ESM: Doesn't matter (no ESM in these setups)
- Mods to Skip: Add any patches you want to preserve

---

### Setup B: Shades of Skyrim

Applies to: All Shades of Skyrim variants (standard, Less Transparent, Darker)

```
Your load order:
  Water for ENB.esm
  └─ Water for ENB - Patch - JKs Skyrim.esp
  └─ Water for ENB - Patch - Lux.esp
  Water for ENB (Shades of Skyrim).esp (or Darker/Less Transparent variant)
  └─ Natural Waterfalls - Water for ENB Patch (Shades of Skyrim).esp
  └─ ... other SoS patches ...
```

**Settings:**
- Main Plugin: Your Shades variant (e.g., `Water for ENB (Shades of Skyrim) (Darker).esp`)
- Include Base ESM: `Enabled` (recommended to process both ESM and ESP)
- Mods to Skip: Add any patches you want to preserve

---

## Auto-Skipped Mods

These are automatically skipped (no need to add manually):
- `Synthesis.esp`
- `DynDOLOD.esm` / `DynDOLOD.esp`
- `Occlusion.esp`
- `Water Seams Fix.esp`

---

## How It Works

For each cell in your load order:

```
1. Get water data from W4ENB (or W4ENB patch)
2. Get the "winning" override (last mod to edit that cell)
3. Compare: Water type, environment map, height, HasWater flag
4. If ANY field differs AND winner is not W4ENB:
   → Create patch with W4ENB's values
5. If W4ENB already wins:
   → Skip (no bloat)
```

---

## Installation

1. Open Synthesis
2. Click **Git Repository**
3. Add the repository URL
4. Configure settings (see Quick Setup Guide)
5. Run

## Output Placement

Place your output plugin (whatever esp name you chose in Synthesis, usually Synthesis.esp) **last** after all W4ENB mods:

```
Water for ENB.esm (if using SoS)
Water for ENB.esp OR Water for ENB (Shades of Skyrim).esp
  ... all W4ENB patches ...
Synthesis.esp  ← HERE (output)
```

---

## Requirements

- Skyrim Special Edition
- Water for ENB (any variant)
- [Synthesis](https://github.com/Mutagen-Modding/Synthesis)
- [.NET 8.0 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)

---

## Troubleshooting

| Issue | Solution |
|-------|----------|
| "Water for ENB not found" | Ensure W4ENB is installed and you selected the correct main plugin |
| Too many patched records | Expected if mods overwrite W4ENB cells. Use "Mods to Skip" for intentional changes |
| Zero patched records | W4ENB is already winning - no patch needed! |
| Build errors | Ensure .NET 8.0 SDK installed |

---

## License

MIT
