using MelonLoader;

[assembly: MelonInfo(typeof(Crowbar.Core), "Crowbar", "1.0.6", "Klehrik", null)]
[assembly: MelonGame("Videocult", "Airframe")]

namespace Crowbar;

public class Core : MelonMod
{
    internal static MelonLogger.Instance Logger => Melon<Core>.Logger;
}