// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomDoorPermissions
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using Interactables.Interobjects;
    using Interactables.Interobjects.DoorUtils;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnInteractingDoor(InteractingDoorEventArgs)"/>
        public void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (ev.Player.IsScp && !ev.Door.IsLocked && plugin.Config.ScpAccess.Contains(ev.Door.Type))
                ev.IsAllowed = true;
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnWaitingForPlayers()"/>
        public void OnWaitingForPlayers()
        {
            foreach (Door door in Door.List)
            {
                foreach (var kvp in plugin.Config.Permissions)
                {
                    if (door.Type == kvp.Key)
                    {
                        door.RequiredPermissions.RequiredPermissions = 0ul;
                        foreach (KeycardPermissions additionalPermission in kvp.Value)
                            door.RequiredPermissions.RequiredPermissions |= additionalPermission;
                    }
                }

                if (plugin.Config.GrenadeImmune.Contains(door.Type) && door.Base is BreakableDoor breakableDoor)
                    breakableDoor._ignoredDamageSources |= DoorDamageType.Grenade;
            }
        }
    }
}