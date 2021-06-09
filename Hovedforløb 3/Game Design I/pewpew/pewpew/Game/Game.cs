using pewpew.Characters;
using System;
using System.Threading;

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
            Player.DamageUpdate += (ICharacter character, int damage) => OnPlayerDamageUpdated(character as IPlayer, damage);
            Player.HealthUpdate += (ICharacter character, int health) => OnPlayerHealthUpdated(character as IPlayer, health);
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
        public void Start()
        {
            Playing = true;
            Run();
        }
        private void Run()
        {
            bool nextWavePause = false; //True if player killed all enemies in wave - giving player a break from enemies shooting
            int nextWaveWait = 3; //Time until next wave should occur

            while (Playing)
            {
                KeyPressed();

                while (!Console.KeyAvailable)
                {
                    HandleEnemies(ref nextWavePause, ref nextWaveWait);
                }

                Thread.Sleep(1000);
            }
        }

        public void Pause()
        {
            Playing = !Playing;
        }
        public void Stop()
        {
            Playing = false;
        }
        #endregion

        private void HandleEnemies(ref bool nextWavePause, ref int nextWaveWait)
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
                    Map.SpawnEnemies(Waves.Next(this));
                }
            }
        }
        private void KeyPressed()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Escape: Pause(); break;
                case ConsoleKey.Spacebar: Player.Shoot(Player.CurrentDirection); break;
                case ConsoleKey.LeftArrow: case ConsoleKey.A: Player.MoveToThe(Directions.LEFT); break;
                case ConsoleKey.UpArrow: case ConsoleKey.W: Player.MoveToThe(Directions.JUMP); break;
                case ConsoleKey.RightArrow: case ConsoleKey.D: Player.MoveToThe(Directions.RIGHT); break;
            }
        }

        #region Enemy Events
        public void OnEnemyDamageUpdated(IEnemy enemy, int damage)
        {
            throw new NotImplementedException();
        }
        public void OnEnemyHealthUpdated(IEnemy enemy, int health)
        {
            throw new NotImplementedException();
        }
        public void OnEnemyMoved(IEnemy enemy, Directions direction)
        {
            throw new NotImplementedException();
        }
        public void OnEnemyDeath(IEnemy enemy)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Player events
        protected void OnPlayerDamageUpdated(IPlayer player, int damage)
        {
            throw new NotImplementedException();
        }
        protected void OnPlayerHealthUpdated(IPlayer player, int health)
        {
            if (health < 0) (player as Player).Die();
        }
        protected void OnPlayerMoved(IPlayer player, Directions direction)
        {
            switch (direction)
            {
                case Directions.JUMP: Map.MovePlayerVertical(player as Player, 1); break;
                case Directions.LEFT: Map.MovePlayerHorizontal(player as Player, -1); break;
                case Directions.FALL: Map.MovePlayerVertical(player as Player, -1); break;
                case Directions.RIGHT: Map.MovePlayerHorizontal(player as Player, 1); break;
            }
        }
        protected void OnPlayerDeath(IPlayer player)
        {
            Map.Erase(player);
            Map.GameOver("Game over!", Heading);
        }
        #endregion
    }
}
