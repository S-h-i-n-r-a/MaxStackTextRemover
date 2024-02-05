using System;
using HarmonyLib;
using TMPro;


namespace MaxStackTextRemover.Patches
{
    [HarmonyPatch(typeof(InventoryGrid), nameof(InventoryGrid.UpdateGui))]
    public static class InventoryGrid_UpdateGui
    {
        public static void Finalizer(InventoryGrid __instance)
        {
            var width = __instance.m_inventory.GetWidth();
            var inventoryItems = __instance.m_inventory.GetAllItems();

            foreach (ItemDrop.ItemData allItem in inventoryItems)
            {
                if (allItem.m_shared.m_maxStackSize > 1)
                {
                    var element = __instance.GetElement(allItem.m_gridPos.x, allItem.m_gridPos.y, width);
                    element.m_amount.text = allItem.m_stack.ToString();
                    element.m_amount.alignment = TextAlignmentOptions.Right;
                }
            }
        }
    }
}
