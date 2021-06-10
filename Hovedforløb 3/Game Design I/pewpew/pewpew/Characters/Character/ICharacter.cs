using pewpew.Items;

namespace pewpew.Characters
{
    public interface ICharacter : IPositionMe
    {
        Directions CurrentDirection { get; }

        /// <summary>
        /// Handler for <see cref="HealthUpdate"/> event
        /// </summary>
        /// <param name="character">Character whose damage was updated</param>
        /// <param name="health">Updated Health</param>
        delegate void HealthUpdatedHandler(ICharacter character, int health);
        /// <summary>
        /// Raised when <see cref="Health"/> is modified
        /// </summary>
        event HealthUpdatedHandler HealthUpdate;

        /// <summary>
        /// Handler for <see cref="DamageUpdate"/> event
        /// </summary>
        /// <param name="character">Character whose damage was updated</param>
        /// <param name="damage">Updated damage</param>
        delegate void DamageUpdateHandler(ICharacter character, int damage);
        /// <summary>
        /// Raised when <see cref="Damage"/> is modified
        /// </summary>
        event DamageUpdateHandler DamageUpdate;

        /// <summary>
        /// Handler for <see cref="Death"/> event
        /// </summary>
        /// <param name="character">Character that died</param>
        delegate void DeathHandler(ICharacter character);
        /// <summary>
        /// Raised when character dies
        /// </summary>
        public event DeathHandler Death;

        /// <summary>
        /// Hanlder for <see cref="Move"/> event
        /// </summary>
        /// <param name="character">Character that moved</param>
        /// <param name="direction">Direction character is moving</param>
        delegate void MoveHandler(ICharacter character, Directions direction);
        /// <summary>
        /// Raised when character moves
        /// </summary>
        public event MoveHandler Move;

        /// <summary>
        /// Character shoots
        /// </summary>
        /// <param name="direction">Direction bullet should be going</param>
        /// <returns>Bullet that was shot</returns>
        Bullet Shoot(Directions direction);
        void Die();

        /// <summary>
        /// Handler for <see cref="Shot"/> event
        /// </summary>
        /// <param name="damage">How much damage was output</param>
        /// <returns>Current <see cref="Health"/></returns>
        delegate int ShotHandler(int damage);
        /// <summary>
        /// Raised when shot
        /// </summary>
        event ShotHandler Shot;
    }
}
