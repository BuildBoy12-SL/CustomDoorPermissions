// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomDoorPermissions
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Enums;
    using Exiled.API.Interfaces;
    using KeycardPermissions = Interactables.Interobjects.DoorUtils.KeycardPermissions;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets all doors that should have grenade immunity added.
        /// </summary>
        [Description("All doors that should have grenade immunity added.")]
        public DoorType[] GrenadeImmune { get; set; } =
        {
            DoorType.HczArmory,
        };

        /// <summary>
        /// Gets or sets a collection of doors paired with a set of custom permissions.
        /// </summary>
        [Description("A collection of doors paired with a set of custom permissions.")]
        public Dictionary<DoorType, KeycardPermissions[]> Permissions { get; set; } = new Dictionary<DoorType, KeycardPermissions[]>
        {
            [DoorType.HczArmory] = new[]
            {
                KeycardPermissions.ArmoryLevelThree,
            },
            [DoorType.CheckpointEntrance] = new[]
            {
                KeycardPermissions.Checkpoints,
            },
            [DoorType.CheckpointLczA] = new[]
            {
                KeycardPermissions.Checkpoints,
            },
            [DoorType.CheckpointLczB] = new[]
            {
                KeycardPermissions.Checkpoints,
            },
        };

        /// <summary>
        /// Gets or sets a collection of doors that scps can open.
        /// </summary>
        [Description("A collection of doors that scps can open.")]
        public List<DoorType> ScpAccess { get; set; } = new List<DoorType>
        {
            DoorType.Scp106Primary,
            DoorType.Scp106Secondary,
            DoorType.Scp106Bottom,
        };
    }
}