using Content.Shared.Clothing.EntitySystems;
using Content.Shared.Inventory;
using Robust.Shared.Audio;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Shared.Clothing.Components;

/// <summary>
///     This handles entities which can be equipped.
/// </summary>
[NetworkedComponent]
[Access(typeof(ClothingSystem), typeof(InventorySystem))]
public abstract class SharedClothingComponent : Component
{
    [DataField("clothingVisuals")]
    [Access(typeof(ClothingSystem), typeof(InventorySystem), Other = AccessPermissions.ReadExecute)] // TODO remove execute permissions.
    public Dictionary<string, List<SharedSpriteComponent.PrototypeLayerData>> ClothingVisuals = new();

    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("quickEquip")]
    public bool QuickEquip = true;

    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("slots", required: true)]
    [Access(typeof(ClothingSystem), typeof(InventorySystem), Other = AccessPermissions.ReadExecute)]
    public SlotFlags Slots = SlotFlags.NONE;

    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("equipSound")]
    public SoundSpecifier? EquipSound;

    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("unequipSound")]
    public SoundSpecifier? UnequipSound;

    [Access(typeof(ClothingSystem))]
    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("equippedPrefix")]
    public string? EquippedPrefix;

    [ViewVariables(VVAccess.ReadWrite)]
    [DataField("sprite")]
    public string? RsiPath;
}

[Serializable, NetSerializable]
public sealed class ClothingComponentState : ComponentState
{
    public string? EquippedPrefix;

    public ClothingComponentState(string? equippedPrefix)
    {
        EquippedPrefix = equippedPrefix;
    }
}
