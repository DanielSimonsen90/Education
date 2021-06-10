using pewpew.Characters;
using pewpew.Items;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace pewpew
{
    public class Game : IGame
    {
        public Heading Heading { get; }
        public Map Map { get; }
        public Player Player;
        public Wave Waves;

        public bool Playing { get; set; } = false;

        public Game(string playername)
        {
            Player = new Player(playername);
            Player.HealthUpdate += OnICharacterHealthUpdate;
            Player.Move += (ICharacter character, Directions direction) => OnPlayerMoved(character as IPlayer, direction);
            Player.Death += (ICharacter character) => OnPlayerDeath(character as IPlayer);

            Heading = new Heading(Player);
            Map = new Map(Player, new GameConsole());
            Waves = new Wave(enemyCount: 2, 
                minHealth: 3, maxHealth: 5, 
                minDamage: 2, maxDamage: 5
            );
        }

        #region Basic
        public virtual void Start()
        {
            Playing = true;
            Run();
        }
        protected virtual void Run()
        {
            bool nextWavePause = false; //True if player killed all enemies in wave - giving player a break from enemies shooting
            int nextWaveWait = 3; //Time until next wave should occur

            while (Playing)
            {
                KeyPressed();

                while (!Console.KeyAvailable)
                {
                    Task.Run(() =>
                    {
                        HandleEnemies(ref nextWavePause, ref nextWaveWait);
                        Thread.Sleep(1000);
                    });
                }
            }
        }
        public virtual void Pause()
        {
            Playing = !Playing;
        }
        public virtual void Stop()
        {
            Playing = false;
        }
        #endregion

        protected virtual void HandleEnemies(ref bool nextWavePause, ref int nextWaveWait)
        {
            if (!nextWavePause && Map.Enemies.Count > 0)
            {
                foreach (Enemy enemy in Map.Enemies)
                    enemy.ShootCheck();
            }
            else
            {
                if (nextWaveWait != 0) nextWaveWait--;
                else
                {
                    nextWavePause = false;
                    nextWaveWait = 3;
                    Map.SpawnEnemies(Waves.Next(this, enemy =>
                    {
                        enemy.Death += (ICharacter character) => OnEnemyDeath(character as IEnemy);
                        enemy.HealthUpdate += OnICharacterHealthUpdate;
                    }));
                }
            }
        }
        protected virtual void KeyPressed()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape: Pause(); break;
                case ConsoleKey.Spacebar: 
                    Bullet bullet = Player.Shoot(Player.CurrentDirection);
                    Map.MoveIPosition(bullet, bullet.Direction, bullet.Direction == Directions.LEFT ? 1 : -1);
                    break;
                case ConsoleKey.LeftArrow: case ConsoleKey.A: Player.MoveToThe(Directions.LEFT); break;
                case ConsoleKey.UpArrow: case ConsoleKey.W: Player.MoveToThe(Directions.JUMP); break;
                case ConsoleKey.RightArrow: case ConsoleKey.D: Player.MoveToThe(Directions.RIGHT); break;
            }
        }

        #region ICharacter Events
        protected virtual void OnICharacterHealthUpdate(ICharacter character, int health)
        {
            if (health < 0)
                character.Die();
        }
        #endregion

        #region Enemy Events
        protected void OnEnemyDeath(IEnemy enemy) => Map.Enemies.RemoveAndErase(enemy as Enemy);
        #endregion

        #region Player Events
        protected virtual void OnPlayerMoved(IPlayer player, Directions direction)
        {
            //The more down/right you go, the higher the number
            int toDirection = direction == Directions.FALL || direction == Directions.RIGHT ? 1 : -1;
            Map.MoveIPosition(player as Player, direction, toDirection);
        }
        protected virtual void OnPlayerDeath(IPlayer player) => Map.GameOver("Game over!", Heading);
        #endregion

    }
}
