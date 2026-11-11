using UnityEngine;
using Il2CppQuantum;
using Il2CppView_Humanoid;

namespace AFUtils;

/// <summary>
/// Contains miscellaneous helper methods.
/// </summary>
public static class Misc
{
    private static Humanoid_View localHumanoidView;

    /// <summary>
    /// Returns the <c>Humanoid_View</c> belonging to the local player.
    /// </summary>
    public static Humanoid_View GetLocalHumanoidView()
    {
        if (localHumanoidView != null) return localHumanoidView;

        var views = GameObject.FindObjectsByType<Humanoid_View>(FindObjectsSortMode.None);
        foreach (var view in views)
        {
            if (view.isLocal)
            {
                localHumanoidView = view;
                return view;
            }
        }
        return null;
    }

    /// <summary>
    /// Returns <c>true</c> if this client is the room host. <br></br>
    /// Always <c>true</c> outside of an online room.
    /// </summary>
    public static bool IsHost()
    {
        var controllerInstance = Il2Cpp.PhotonController.instance;
        return controllerInstance.IsMasterClient();
    }

    /// <summary>
    /// Prints a list of components belonging to a Quantum entity.
    /// </summary>
    public static void PrintComponentList(EntityRef r)
    {
        var game = QuantumRunner.Default?.Game;
        if (game == null) return;
        var frame = game.Frames.Verified;
        var sb = new System.Text.StringBuilder($"\nEntity '{r}' components:\n");

        if (frame.Has<Il2CppQuantum.Transform2D>(r)) sb.Append("Il2CppQuantum.Transform2D\n");
        if (frame.Has<Il2CppQuantum.Transform3D>(r)) sb.Append("Il2CppQuantum.Transform3D\n");
        if (frame.Has<Il2CppQuantum.Transform2DVertical>(r)) sb.Append("Il2CppQuantum.Transform2DVertical\n");
        if (frame.Has<Il2CppQuantum.PhysicsCollider2D>(r)) sb.Append("Il2CppQuantum.PhysicsCollider2D\n");
        if (frame.Has<Il2CppQuantum.PhysicsBody2D>(r)) sb.Append("Il2CppQuantum.PhysicsBody2D\n");
        if (frame.Has<Il2CppQuantum.PhysicsCollider3D>(r)) sb.Append("Il2CppQuantum.PhysicsCollider3D\n");
        if (frame.Has<Il2CppQuantum.PhysicsBody3D>(r)) sb.Append("Il2CppQuantum.PhysicsBody3D\n");
        if (frame.Has<Il2CppQuantum.PhysicsJoints2D>(r)) sb.Append("Il2CppQuantum.PhysicsJoints2D\n");
        if (frame.Has<Il2CppQuantum.PhysicsJoints3D>(r)) sb.Append("Il2CppQuantum.PhysicsJoints3D\n");
        if (frame.Has<Il2CppQuantum.PhysicsCallbacks2D>(r)) sb.Append("Il2CppQuantum.PhysicsCallbacks2D\n");
        if (frame.Has<Il2CppQuantum.PhysicsCallbacks3D>(r)) sb.Append("Il2CppQuantum.PhysicsCallbacks3D\n");
        if (frame.Has<Il2CppQuantum.CharacterController2D>(r)) sb.Append("Il2CppQuantum.CharacterController2D\n");
        if (frame.Has<Il2CppQuantum.CharacterController3D>(r)) sb.Append("Il2CppQuantum.CharacterController3D\n");
        if (frame.Has<Il2CppQuantum.NavMeshPathfinder>(r)) sb.Append("Il2CppQuantum.NavMeshPathfinder\n");
        if (frame.Has<Il2CppQuantum.NavMeshSteeringAgent>(r)) sb.Append("Il2CppQuantum.NavMeshSteeringAgent\n");
        if (frame.Has<Il2CppQuantum.NavMeshAvoidanceAgent>(r)) sb.Append("Il2CppQuantum.NavMeshAvoidanceAgent\n");
        if (frame.Has<Il2CppQuantum.NavMeshAvoidanceObstacle>(r)) sb.Append("Il2CppQuantum.NavMeshAvoidanceObstacle\n");
        if (frame.Has<Il2CppQuantum.View>(r)) sb.Append("Il2CppQuantum.View\n");
        if (frame.Has<Il2CppQuantum.MapEntityLink>(r)) sb.Append("Il2CppQuantum.MapEntityLink\n");
        if (frame.Has<Il2CppQuantum.AffectedByRain>(r)) sb.Append("Il2CppQuantum.AffectedByRain\n");
        if (frame.Has<Il2CppQuantum.Airplane>(r)) sb.Append("Il2CppQuantum.Airplane\n");
        if (frame.Has<Il2CppQuantum.AirplaneTraffic>(r)) sb.Append("Il2CppQuantum.AirplaneTraffic\n");
        if (frame.Has<Il2CppQuantum.Ammo>(r)) sb.Append("Il2CppQuantum.Ammo\n");
        if (frame.Has<Il2CppQuantum.AntiYeetWorkaround>(r)) sb.Append("Il2CppQuantum.AntiYeetWorkaround\n");
        if (frame.Has<Il2CppQuantum.Armor>(r)) sb.Append("Il2CppQuantum.Armor\n");
        if (frame.Has<Il2CppQuantum.AutoAim>(r)) sb.Append("Il2CppQuantum.AutoAim\n");
        if (frame.Has<Il2CppQuantum.AutoAimTarget>(r)) sb.Append("Il2CppQuantum.AutoAimTarget\n");
        if (frame.Has<Il2CppQuantum.AutoResetButton>(r)) sb.Append("Il2CppQuantum.AutoResetButton\n");
        if (frame.Has<Il2CppQuantum.AutoTurret>(r)) sb.Append("Il2CppQuantum.AutoTurret\n");
        if (frame.Has<Il2CppQuantum.AwayCircuitPlayers>(r)) sb.Append("Il2CppQuantum.AwayCircuitPlayers\n");
        if (frame.Has<Il2CppQuantum.Axe>(r)) sb.Append("Il2CppQuantum.Axe\n");
        if (frame.Has<Il2CppQuantum.Bat>(r)) sb.Append("Il2CppQuantum.Bat\n");
        if (frame.Has<Il2CppQuantum.BigScreen>(r)) sb.Append("Il2CppQuantum.BigScreen\n");
        if (frame.Has<Il2CppQuantum.BigScreen_PongGame>(r)) sb.Append("Il2CppQuantum.BigScreen_PongGame\n");
        if (frame.Has<Il2CppQuantum.BigScreen_Vote>(r)) sb.Append("Il2CppQuantum.BigScreen_Vote\n");
        if (frame.Has<Il2CppQuantum.BlockFlag>(r)) sb.Append("Il2CppQuantum.BlockFlag\n");
        if (frame.Has<Il2CppQuantum.BoxingBagBase>(r)) sb.Append("Il2CppQuantum.BoxingBagBase\n");
        if (frame.Has<Il2CppQuantum.Caltrops>(r)) sb.Append("Il2CppQuantum.Caltrops\n");
        if (frame.Has<Il2CppQuantum.Car>(r)) sb.Append("Il2CppQuantum.Car\n");
        if (frame.Has<Il2CppQuantum.CarLODMinusOne>(r)) sb.Append("Il2CppQuantum.CarLODMinusOne\n");
        if (frame.Has<Il2CppQuantum.Chain>(r)) sb.Append("Il2CppQuantum.Chain\n");
        if (frame.Has<Il2CppQuantum.Chainsaw>(r)) sb.Append("Il2CppQuantum.Chainsaw\n");
        if (frame.Has<Il2CppQuantum.CheckPoint>(r)) sb.Append("Il2CppQuantum.CheckPoint\n");
        if (frame.Has<Il2CppQuantum.CheckpointSpawner>(r)) sb.Append("Il2CppQuantum.CheckpointSpawner\n");
        if (frame.Has<Il2CppQuantum.ChromeLocker>(r)) sb.Append("Il2CppQuantum.ChromeLocker\n");
        if (frame.Has<Il2CppQuantum.Collectable>(r)) sb.Append("Il2CppQuantum.Collectable\n");
        if (frame.Has<Il2CppQuantum.CollectablePickupPending>(r)) sb.Append("Il2CppQuantum.CollectablePickupPending\n");
        if (frame.Has<Il2CppQuantum.CollectableShop>(r)) sb.Append("Il2CppQuantum.CollectableShop\n");
        if (frame.Has<Il2CppQuantum.CollectableShopPickup>(r)) sb.Append("Il2CppQuantum.CollectableShopPickup\n");
        if (frame.Has<Il2CppQuantum.ConfettiCannon_Stationary>(r)) sb.Append("Il2CppQuantum.ConfettiCannon_Stationary\n");
        if (frame.Has<Il2CppQuantum.ConfettiGun>(r)) sb.Append("Il2CppQuantum.ConfettiGun\n");
        if (frame.Has<Il2CppQuantum.ConsumablesRespawner>(r)) sb.Append("Il2CppQuantum.ConsumablesRespawner\n");
        if (frame.Has<Il2CppQuantum.Controllable>(r)) sb.Append("Il2CppQuantum.Controllable\n");
        if (frame.Has<Il2CppQuantum.ConveyorBelt>(r)) sb.Append("Il2CppQuantum.ConveyorBelt\n");
        if (frame.Has<Il2CppQuantum.ConveyorBeltTempMovingTerrain>(r)) sb.Append("Il2CppQuantum.ConveyorBeltTempMovingTerrain\n");
        if (frame.Has<Il2CppQuantum.Crowbar>(r)) sb.Append("Il2CppQuantum.Crowbar\n");
        if (frame.Has<Il2CppQuantum.DependencyDespawn>(r)) sb.Append("Il2CppQuantum.DependencyDespawn\n");
        if (frame.Has<Il2CppQuantum.Despawn>(r)) sb.Append("Il2CppQuantum.Despawn\n");
        if (frame.Has<Il2CppQuantum.Door>(r)) sb.Append("Il2CppQuantum.Door\n");
        if (frame.Has<Il2CppQuantum.EMPgrenade>(r)) sb.Append("Il2CppQuantum.EMPgrenade\n");
        if (frame.Has<Il2CppQuantum.Electrocuted>(r)) sb.Append("Il2CppQuantum.Electrocuted\n");
        if (frame.Has<Il2CppQuantum.EnterShopMessageTracker>(r)) sb.Append("Il2CppQuantum.EnterShopMessageTracker\n");
        if (frame.Has<Il2CppQuantum.EntityProjectile>(r)) sb.Append("Il2CppQuantum.EntityProjectile\n");
        if (frame.Has<Il2CppQuantum.Equipment>(r)) sb.Append("Il2CppQuantum.Equipment\n");
        if (frame.Has<Il2CppQuantum.Explosion>(r)) sb.Append("Il2CppQuantum.Explosion\n");
        if (frame.Has<Il2CppQuantum.Fire>(r)) sb.Append("Il2CppQuantum.Fire\n");
        if (frame.Has<Il2CppQuantum.FloatOnOcean>(r)) sb.Append("Il2CppQuantum.FloatOnOcean\n");
        if (frame.Has<Il2CppQuantum.FoamBlob>(r)) sb.Append("Il2CppQuantum.FoamBlob\n");
        if (frame.Has<Il2CppQuantum.FreeMovingPickup>(r)) sb.Append("Il2CppQuantum.FreeMovingPickup\n");
        if (frame.Has<Il2CppQuantum.Grenade>(r)) sb.Append("Il2CppQuantum.Grenade\n");
        if (frame.Has<Il2CppQuantum.Gun>(r)) sb.Append("Il2CppQuantum.Gun\n");
        if (frame.Has<Il2CppQuantum.HangGlider>(r)) sb.Append("Il2CppQuantum.HangGlider\n");
        if (frame.Has<Il2CppQuantum.Healing>(r)) sb.Append("Il2CppQuantum.Healing\n");
        if (frame.Has<Il2CppQuantum.Health>(r)) sb.Append("Il2CppQuantum.Health\n");
        if (frame.Has<Il2CppQuantum.HeldByHumanoid>(r)) sb.Append("Il2CppQuantum.HeldByHumanoid\n");
        if (frame.Has<Il2CppQuantum.HeldByPickup>(r)) sb.Append("Il2CppQuantum.HeldByPickup\n");
        if (frame.Has<Il2CppQuantum.Horses>(r)) sb.Append("Il2CppQuantum.Horses\n");
        if (frame.Has<Il2CppQuantum.HoverBike>(r)) sb.Append("Il2CppQuantum.HoverBike\n");
        if (frame.Has<Il2CppQuantum.Humanoid>(r)) sb.Append("Il2CppQuantum.Humanoid\n");
        if (frame.Has<Il2CppQuantum.HumanoidOnMovingTerrain>(r)) sb.Append("Il2CppQuantum.HumanoidOnMovingTerrain\n");
        if (frame.Has<Il2CppQuantum.InventoryStashSafe>(r)) sb.Append("Il2CppQuantum.InventoryStashSafe\n");
        if (frame.Has<Il2CppQuantum.Jerrycan>(r)) sb.Append("Il2CppQuantum.Jerrycan\n");
        if (frame.Has<Il2CppQuantum.Kalashnikov>(r)) sb.Append("Il2CppQuantum.Kalashnikov\n");
        if (frame.Has<Il2CppQuantum.KillerTagTracker>(r)) sb.Append("Il2CppQuantum.KillerTagTracker\n");
        if (frame.Has<Il2CppQuantum.Laser>(r)) sb.Append("Il2CppQuantum.Laser\n");
        if (frame.Has<Il2CppQuantum.Machete>(r)) sb.Append("Il2CppQuantum.Machete\n");
        if (frame.Has<Il2CppQuantum.MeleeAttack>(r)) sb.Append("Il2CppQuantum.MeleeAttack\n");
        if (frame.Has<Il2CppQuantum.Minigun>(r)) sb.Append("Il2CppQuantum.Minigun\n");
        if (frame.Has<Il2CppQuantum.MoneyFountain>(r)) sb.Append("Il2CppQuantum.MoneyFountain\n");
        if (frame.Has<Il2CppQuantum.MovingHazard>(r)) sb.Append("Il2CppQuantum.MovingHazard\n");
        if (frame.Has<Il2CppQuantum.MovingTerrain>(r)) sb.Append("Il2CppQuantum.MovingTerrain\n");
        if (frame.Has<Il2CppQuantum.ParticipatingPlayer>(r)) sb.Append("Il2CppQuantum.ParticipatingPlayer\n");
        if (frame.Has<Il2CppQuantum.PathBlocker>(r)) sb.Append("Il2CppQuantum.PathBlocker\n");
        if (frame.Has<Il2CppQuantum.Pickup>(r)) sb.Append("Il2CppQuantum.Pickup\n");
        if (frame.Has<Il2CppQuantum.PickupLockedForEntity>(r)) sb.Append("Il2CppQuantum.PickupLockedForEntity\n");
        if (frame.Has<Il2CppQuantum.PillsAddiction>(r)) sb.Append("Il2CppQuantum.PillsAddiction\n");
        if (frame.Has<Il2CppQuantum.Pipe>(r)) sb.Append("Il2CppQuantum.Pipe\n");
        if (frame.Has<Il2CppQuantum.PlasmaBall>(r)) sb.Append("Il2CppQuantum.PlasmaBall\n");
        if (frame.Has<Il2CppQuantum.PlasmaBall_Erratic>(r)) sb.Append("Il2CppQuantum.PlasmaBall_Erratic\n");
        if (frame.Has<Il2CppQuantum.PlasmaGun>(r)) sb.Append("Il2CppQuantum.PlasmaGun\n");
        if (frame.Has<Il2CppQuantum.PlayArea>(r)) sb.Append("Il2CppQuantum.PlayArea\n");
        if (frame.Has<Il2CppQuantum.Player>(r)) sb.Append("Il2CppQuantum.Player\n");
        if (frame.Has<Il2CppQuantum.PoliceCoordinator>(r)) sb.Append("Il2CppQuantum.PoliceCoordinator\n");
        if (frame.Has<Il2CppQuantum.PoliceHelicopter>(r)) sb.Append("Il2CppQuantum.PoliceHelicopter\n");
        if (frame.Has<Il2CppQuantum.PoliceVehicleGunman>(r)) sb.Append("Il2CppQuantum.PoliceVehicleGunman\n");
        if (frame.Has<Il2CppQuantum.QuickStrike>(r)) sb.Append("Il2CppQuantum.QuickStrike\n");
        if (frame.Has<Il2CppQuantum.RaceGameState>(r)) sb.Append("Il2CppQuantum.RaceGameState\n");
        if (frame.Has<Il2CppQuantum.RaceParticipator>(r)) sb.Append("Il2CppQuantum.RaceParticipator\n");
        if (frame.Has<Il2CppQuantum.RainStorm>(r)) sb.Append("Il2CppQuantum.RainStorm\n");
        if (frame.Has<Il2CppQuantum.Rebar>(r)) sb.Append("Il2CppQuantum.Rebar\n");
        if (frame.Has<Il2CppQuantum.RebarGun>(r)) sb.Append("Il2CppQuantum.RebarGun\n");
        if (frame.Has<Il2CppQuantum.RetainOwnershipOnRespawn>(r)) sb.Append("Il2CppQuantum.RetainOwnershipOnRespawn\n");
        if (frame.Has<Il2CppQuantum.RiotShield>(r)) sb.Append("Il2CppQuantum.RiotShield\n");
        if (frame.Has<Il2CppQuantum.RiotStick>(r)) sb.Append("Il2CppQuantum.RiotStick\n");
        if (frame.Has<Il2CppQuantum.SandboxRespawn>(r)) sb.Append("Il2CppQuantum.SandboxRespawn\n");
        if (frame.Has<Il2CppQuantum.ShopState>(r)) sb.Append("Il2CppQuantum.ShopState\n");
        if (frame.Has<Il2CppQuantum.Shotgun>(r)) sb.Append("Il2CppQuantum.Shotgun\n");
        if (frame.Has<Il2CppQuantum.Shuriken>(r)) sb.Append("Il2CppQuantum.Shuriken\n");
        if (frame.Has<Il2CppQuantum.SkyYeetFinder>(r)) sb.Append("Il2CppQuantum.SkyYeetFinder\n");
        if (frame.Has<Il2CppQuantum.Sledgehammer>(r)) sb.Append("Il2CppQuantum.Sledgehammer\n");
        if (frame.Has<Il2CppQuantum.SleepWithJoint>(r)) sb.Append("Il2CppQuantum.SleepWithJoint\n");
        if (frame.Has<Il2CppQuantum.SlotMachine>(r)) sb.Append("Il2CppQuantum.SlotMachine\n");
        if (frame.Has<Il2CppQuantum.SnapBudget>(r)) sb.Append("Il2CppQuantum.SnapBudget\n");
        if (frame.Has<Il2CppQuantum.SnapToOffset>(r)) sb.Append("Il2CppQuantum.SnapToOffset\n");
        if (frame.Has<Il2CppQuantum.SpawnShop>(r)) sb.Append("Il2CppQuantum.SpawnShop\n");
        if (frame.Has<Il2CppQuantum.SpecialArenaBehavior>(r)) sb.Append("Il2CppQuantum.SpecialArenaBehavior\n");
        if (frame.Has<Il2CppQuantum.Spectator>(r)) sb.Append("Il2CppQuantum.Spectator\n");
        if (frame.Has<Il2CppQuantum.StartLineGate>(r)) sb.Append("Il2CppQuantum.StartLineGate\n");
        if (frame.Has<Il2CppQuantum.StickyWeapon>(r)) sb.Append("Il2CppQuantum.StickyWeapon\n");
        if (frame.Has<Il2CppQuantum.StraggleBoostSpawner>(r)) sb.Append("Il2CppQuantum.StraggleBoostSpawner\n");
        if (frame.Has<Il2CppQuantum.Stuck>(r)) sb.Append("Il2CppQuantum.Stuck\n");
        if (frame.Has<Il2CppQuantum.StunState>(r)) sb.Append("Il2CppQuantum.StunState\n");
        if (frame.Has<Il2CppQuantum.SwitchButton>(r)) sb.Append("Il2CppQuantum.SwitchButton\n");
        if (frame.Has<Il2CppQuantum.SwitchTriggeredMovingTerrain>(r)) sb.Append("Il2CppQuantum.SwitchTriggeredMovingTerrain\n");
        if (frame.Has<Il2CppQuantum.Television>(r)) sb.Append("Il2CppQuantum.Television\n");
        if (frame.Has<Il2CppQuantum.TrackAndShootAI>(r)) sb.Append("Il2CppQuantum.TrackAndShootAI\n");
        if (frame.Has<Il2CppQuantum.TradePod>(r)) sb.Append("Il2CppQuantum.TradePod\n");
        if (frame.Has<Il2CppQuantum.TrafficCarriageStaticDataComponent>(r)) sb.Append("Il2CppQuantum.TrafficCarriageStaticDataComponent\n");
        if (frame.Has<Il2CppQuantum.TrafficCarriageTag>(r)) sb.Append("Il2CppQuantum.TrafficCarriageTag\n");
        if (frame.Has<Il2CppQuantum.TrafficCarriages>(r)) sb.Append("Il2CppQuantum.TrafficCarriages\n");
        if (frame.Has<Il2CppQuantum.TrafficReactions>(r)) sb.Append("Il2CppQuantum.TrafficReactions\n");
        if (frame.Has<Il2CppQuantum.TrafficRoad>(r)) sb.Append("Il2CppQuantum.TrafficRoad\n");
        if (frame.Has<Il2CppQuantum.TrafficSign>(r)) sb.Append("Il2CppQuantum.TrafficSign\n");
        if (frame.Has<Il2CppQuantum.TrafficTruckStaticDataComponent>(r)) sb.Append("Il2CppQuantum.TrafficTruckStaticDataComponent\n");
        if (frame.Has<Il2CppQuantum.TrainTrack>(r)) sb.Append("Il2CppQuantum.TrainTrack\n");
        if (frame.Has<Il2CppQuantum.TramTrack>(r)) sb.Append("Il2CppQuantum.TramTrack\n");
        if (frame.Has<Il2CppQuantum.TransferJoints>(r)) sb.Append("Il2CppQuantum.TransferJoints\n");
        if (frame.Has<Il2CppQuantum.Tutorial>(r)) sb.Append("Il2CppQuantum.Tutorial\n");
        if (frame.Has<Il2CppQuantum.UnderWater>(r)) sb.Append("Il2CppQuantum.UnderWater\n");
        if (frame.Has<Il2CppQuantum.UniqueEquipment>(r)) sb.Append("Il2CppQuantum.UniqueEquipment\n");
        if (frame.Has<Il2CppQuantum.Vehicle>(r)) sb.Append("Il2CppQuantum.Vehicle\n");
        if (frame.Has<Il2CppQuantum.VictoryCelebration>(r)) sb.Append("Il2CppQuantum.VictoryCelebration\n");
        if (frame.Has<Il2CppQuantum.Wet>(r)) sb.Append("Il2CppQuantum.Wet\n");

        Core.Logger.Msg(sb.ToString());
    }
}