using MelonLoader;

[assembly: MelonInfo(typeof(AFUtils.Core), "AFUtils", "1.0.3", "Klehrik", null)]
[assembly: MelonGame("Videocult", "Airframe")]

namespace AFUtils;

public class Core : MelonMod
{
    internal static MelonLogger.Instance Logger => Melon<Core>.Logger;

    public override void OnInitializeMelon()
    {
        var option = new ActionMenu.Option(
            () =>
            {
                Logger.Msg("Hello world!");
            },

            "hello world"
        );

        ActionMenu.RegisterForCollection(
            () =>
            {
                // Add option with default label
                ActionMenu.AddOption(option);

                // Add option with specified text
                ActionMenu.AddOption(option, "specific text");
            }
        );
    }
}