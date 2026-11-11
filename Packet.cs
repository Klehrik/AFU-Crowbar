using HarmonyLib;
using Il2Cpp;
using Il2CppPhoton.Client;

namespace Crowbar;

/// <summary>
/// Allows for sending an arbitrary string dictionary to all other players; this should <i>not</i> be done often. <br></br>
/// Works by making use of <c>Realtime.Player.CustomProperties</c>. <br></br><br></br>
/// Do <i>not</i> use the key <c>"__identifier"</c> since that is reserved for internal use.
/// </summary>
public class Packet
{
    private const string CustomPropertyName = "Crowbar_Packet";
    private const string IdentifierKey      = "__identifier";
    private static readonly Dictionary<string, Action<Il2CppPhoton.Realtime.Player, Dictionary<string, string>>> callbacks = new Dictionary<string, Action<Il2CppPhoton.Realtime.Player, Dictionary<string, string>>>();

    /// <summary>
    /// The unique identifier for this packet.
    /// </summary>
    public string Identifier { get; }

    /// <param name="callback">The function to call when the packet is received. <br></br>It is called for every client except the sender.</param>
    public Packet(string identifier, Action<Il2CppPhoton.Realtime.Player, Dictionary<string, string>> callback)
    {
        if (callbacks.ContainsKey(identifier))
        {
            throw new ArgumentException($"Identifier '{identifier}' is already in use.");
        }

        Identifier = identifier;
        callbacks[identifier] = callback;
    }

    /// <summary>
    /// Sends an arbitrary string dictionary to all other clients.
    /// </summary>
    /// <returns><c>true</c> if successful.</returns>
    public bool Send(Dictionary<string, string> dict)
    {
        var controllerInstance = PhotonController.instance;
        var client = controllerInstance.client;
        var room = client.CurrentRoom;
        if (client.CurrentRoom == null) return false;

        // Convert Dictionary to PhotonHashtable
        var table = new PhotonHashtable();
        foreach (var pair in dict)
        {
            if (pair.Key == IdentifierKey)
            {
                throw new ArgumentException("Do not use the key '__identifier'.");
            }
            table.Add(pair.Key, pair.Value);
        }
        table.Add(IdentifierKey, Identifier);

        var properties = new PhotonHashtable();
        properties.Add(CustomPropertyName, table);
        client.LocalPlayer.SetCustomProperties(properties, null);
        return true;
    }

    [HarmonyPatch(typeof(PhotonController), nameof(PhotonController.OnPlayerPropertiesUpdate))]
    public static class PhotonControllerPatch
    {
        static void Postfix(Il2CppPhoton.Realtime.Player targetPlayer, PhotonHashtable changedProps)
        {
            if (targetPlayer.IsLocal) return;
            if (!changedProps.ContainsKey("Crowbar_Packet")) return;

            // Convert PhotonHashtable to Dictionary
            var table = changedProps["Crowbar_Packet"].Cast<PhotonHashtable>();
            var dict = new Dictionary<string, string>();
            string identifier = null;
            foreach (var pair in table)
            {
                var key = pair.Key.ToString();
                var value = pair.Value.ToString();

                if (key == IdentifierKey)
                {
                    identifier = value;
                }
                else
                {
                    dict[key] = value;
                }
            }

            if (identifier != null && callbacks.ContainsKey(identifier))
            {
                callbacks[identifier](targetPlayer, dict);
            }
        }
    }
}