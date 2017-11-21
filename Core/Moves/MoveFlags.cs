using System;

namespace Poke
{
    [Flags]
    public enum MoveFlags
    {
        /// <summary>
        /// Default
        /// </summary>
        Default = 0,

        /// <summary>
        /// Ignores a target's substitute.
        /// </summary>
        Authentic = 1 << 0,

        /// <summary>
        /// Power is multiplied by 1.5 when used by a Pokemon with the Ability Strong Jaw.
        /// </summary>
        Bite = 1 << 1,

        /// <summary>
        /// Has no effect on Pokemon with the Ability Bulletproof.
        /// </summary>
        Bullet = 1 << 2,

        /// <summary>
        /// The user is unable to make a move between turns.
        /// </summary>
        Charge = 1 << 3,

        /// <summary>
        /// Makes contact.
        /// </summary>
        Contact = 1 << 4,

        /// <summary>
        /// When used by a Pokemon, other Pokemon with the Ability Dancer can attempt to execute the same move.
        /// </summary>
        Dance = 1 << 5,

        /// <summary>
        /// Thaws the user if executed successfully while the user is frozen.
        /// </summary>
        Defrost = 1 << 6,

        /// <summary>
        /// Can target a Pokemon positioned anywhere in a Triple Battle.
        /// </summary>
        Distance = 1 << 7,

        /// <summary>
        /// Prevented from being executed or selected during Gravity's effect.
        /// </summary>
        Gravity = 1 << 8,

        /// <summary>
        /// Prevented from being executed or selected during Heal Block's effect.
        /// </summary>
        Heal = 1 << 9,

        /// <summary>
        /// Can be copied by Mirror Move.
        /// </summary>
        Mirror = 1 << 10,

        /// <summary>
        /// Unknown effect.
        /// </summary>
        Mystery = 1 << 11,

        /// <summary>
        /// Prevented from being executed or selected in a Sky Battle.
        /// </summary>
        NonSky = 1 << 12,

        /// <summary>
        /// Has no effect on Grass-type Pokemon, Pokemon with the Ability Overcoat, and Pokemon holding Safety Goggles.
        /// </summary>
        Powder = 1 << 13,

        /// <summary>
        /// Blocked by Detect, Protect, Spiky Shield, and if not a Status move, King's Shield.
        /// </summary>
        Protect = 1 << 14,

        /// <summary>
        /// Power is multiplied by 1.5 when used by a Pokemon with the Ability Mega Launcher.
        /// </summary>
        Pulse = 1 << 15,

        /// <summary>
        /// Power is multiplied by 1.2 when used by a Pokemon with the Ability Iron Fist.
        /// </summary>
        Punch = 1 << 16,

        /// <summary>
        /// If this move is successful, the user must recharge on the following turn and cannot make a move.
        /// </summary>
        Recharge = 1 << 17,

        /// <summary>
        /// Bounced back to the original user by Magic Coat or the Ability Magic Bounce.
        /// </summary>
        Reflectable = 1 << 18,

        /// <summary>
        /// Can be stolen from the original user and instead used by another Pokemon using Snatch.
        /// </summary>
        Snatch = 1 << 19,

        /// <summary>
        /// Has no effect on Pokemon with the Ability Soundproof.
        /// </summary>
        Sound = 1 << 20
    }
}