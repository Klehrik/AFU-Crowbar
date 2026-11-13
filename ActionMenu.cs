using HarmonyLib;
using Il2CppHUD;

namespace Crowbar;

/// <summary>
/// Allows for adding new options to the action menu. <br></br>
/// Works by hijacking <c>SpecialActionCommand</c> and using unique action IDs.
/// </summary>
public static class ActionMenu
{
    private static readonly List<Action> callbacks = new List<Action>();
    private static readonly Dictionary<int, string> indexToLabel = new Dictionary<int, string>();
    private static int currentIndex = 0;
    private static bool collecting = false;
    private static RadialMenu_Component.Actions instance;

    /// <summary>
    /// Registers a function to be called whenever option collection happens for the menu.
    /// </summary>
    /// <param name="callback"><c>AddOption</c> should be called in here to add options.</param>
    public static void RegisterForCollection(Action callback)
    {
        callbacks.Add(callback);
    }

    /// <summary>
    /// Adds an option to the action menu.
    /// </summary>
    /// <param name="selectable">If <c>false</c>, the option will be grayed out. <br></br><c>true</c> by default.</param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void AddOption(Option option, string label, bool selectable = true)
    {
        if (!collecting)
        {
            throw new InvalidOperationException("Cannot add options outside of collection time.");
        }
        instance.AddItem(option.ID, !selectable);
        indexToLabel[currentIndex++] = label;
    }

    /// <summary>
    /// Adds an option to the action menu.
    /// </summary>
    /// <param name="selectable">If <c>false</c>, the option will be grayed out. <br></br><c>true</c> by default.</param>
    /// <exception cref="InvalidOperationException"></exception>
    public static void AddOption(Option option, bool selectable = true)
    {
        AddOption(option, option.Label, selectable);
    }

    private static void CollectOptions()
    {
        currentIndex = instance.items.Count;
        collecting = true;
        foreach (var callback in callbacks)
        {
            callback();
        }
        collecting = false;
    }

    /// <summary>
    /// Represents an action menu option.
    /// </summary>
    public class Option
    {
        private static int idCounter = 10000;
        internal static readonly Dictionary<int, Action> callbacks = new Dictionary<int, Action>();

        /// <summary>
        /// The unique action ID of the option. <br></br>
        /// These start at <c>10000</c>.
        /// </summary>
        public int ID { get; }

        /// <summary>
        /// The default label for the option. <br></br>
        /// Used if one is not explicitly passed to <c>AddOption</c>.
        /// </summary>
        public string Label { get; set; }

        /// <param name="callback">The function to call when the option is selected.</param>
        public Option(Action callback, string label)
        {
            ID = idCounter++;
            Label = label;
            callbacks[ID] = callback;
        }

        /// <param name="callback">The function to call when the option is selected.</param>
        public Option(Action callback) : this(callback, "unknown")
        {
        }
    }

    [HarmonyPatch(typeof(RadialMenu_Component.Actions))]
    public static class RadialMenu_Component_ActionsPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(RadialMenu_Component.Actions.RefreshItems))]
        static void RefreshItemsPostfix(RadialMenu_Component.Actions __instance)
        {
            // `RadialMenu_Component.RefreshItems()` calls `RM_C.Actions.RefreshItems()`
            // first before `SetItem`, so collect options in here.
            instance = __instance;
            CollectOptions();
        }

        [HarmonyPostfix]
        [HarmonyPatch(nameof(RadialMenu_Component.Actions.GetOptionName))]
        static void GetOptionNamePostfix(RadialMenu_Component.Actions __instance, ref string __result, ref int index)
        {
            // This runs multiple times after
            // `RM_C.Actions.RefreshItems()` for every option.
            if (indexToLabel.TryGetValue(index, out string label))
            {
                __result = label;
            }
        }
    }

    [HarmonyPatch(typeof(RadialMenu_Component))]
    public static class RadialMenu_ComponentPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(nameof(RadialMenu_Component.HandleSelection))]
        static void HandleSelectionPostfix(Il2CppHUD.RadialMenu_Component __instance, ref int selectedItemIndex, ref int selectedItemValue)
        {
            // Intercept action IDs that are used here
            if (Option.callbacks.ContainsKey(selectedItemValue))
            {
                Option.callbacks[selectedItemValue]();

                // Set these to `-1` so they don't end
                // up doing anything for other players.
                // Intercepting this method does not prevent DeterministicCommands
                // from being queued, since that happens in the body.
                // I tried to fix this by intercepting Serialize writing but despite
                // my attempts I have no idea what the format is for the BitStream.
                selectedItemIndex = -1;
                selectedItemValue = -1;
            }
        }
    }
}