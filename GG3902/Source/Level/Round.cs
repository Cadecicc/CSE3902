using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GG3902
{
    // This class is for the management of the round of zombies when in the zombie arena
    public class Round
    {
        public int roundNumber;
        public bool over;
        private Dictionary<string, int> entityCounts;
        private Dictionary<string, int> scoreValue;
        private List<Enemy> zombies;
        private Player player;
        private Random rand;
        private bool tookDamage;
        private bool roundStarted;
        private bool roundEnded;
        private bool allEnemiesSpawned;
        private bool allEnemiesKilled;
        private float startTime;
        private float period;
        private float spawnTime;
        private float endTime;

        private static int score = 0;
        private static int numOfKills = 0;

        public int NumOfKills => numOfKills;

        public Round(int roundNumber, Dictionary<string, int> entityCounts, Dictionary<string, int> scoreValue, Player player)
        {
            this.roundNumber = roundNumber;
            this.entityCounts = entityCounts;
            this.scoreValue = scoreValue;
            zombies = new List<Enemy>();
            rand = new Random();
            GenerateEnemies("Walker");
            GenerateEnemies("Runner");
            GenerateEnemies("Spitter");
            GenerateEnemies("Tank");
            this.player = player;
            player.OnTakeDamage += PlayerHealthListener;
            tookDamage = false;
            roundStarted = false;
            roundEnded = false;
            allEnemiesKilled = false;
            allEnemiesSpawned = false;
            over = false;
            startTime = 5.0f;
            period = 10.0f / Convert.ToSingle(zombies.Count);
            spawnTime = period;
            endTime = 3.0f;
        }

        public static void Reset()
        {
            numOfKills = 0;
            score = 0;
        }

        // Uses boolean logic to tell what state of the round it is in, then proceeds accordingly
        public int Update(GameTime gameTime)
        {
            if (!roundStarted)
                roundStarted = StartRound(gameTime);
            else if (!roundEnded)
                roundEnded = ContinueRound(gameTime);
            else if (!over)
                over = EndRound(gameTime);

            return score;
        }

        private void GenerateEnemies(string name)
        {
            Vector2 position;
            for (int i = 0; i < entityCounts[name]; i++)
            {
                double angle = rand.NextDouble() * 2 * Math.PI;
                float radius = 704;

                position = new Vector2((radius * (float)Math.Cos(angle)), (radius * (float)Math.Sin(angle)));

                zombies.Add(new Enemy(position, name));
            }
            entityCounts.Remove(name);
        }

        // Starts the round with a set amount of time 
        private bool StartRound(GameTime gameTime)
        {
            if (startTime > 0)
            {
                // These if statements could allow for animations to indicate a countdown in the future
                startTime -= gameTime.DeltaTime(); 
                //if (startTime < 1)
                //    //Debug.WriteLine("1..");
                //else if (startTime < 2)
                //    //Debug.WriteLine("2..");
                //else if (startTime < 3)
                //    //Debug.WriteLine("3..");
                return false;
            }
            else
            {
                // changes the bool return to start the next phase of the round
                //Debug.WriteLine("Round " + roundNumber.ToString() + " Start!");
                return true;
            }
        }

        // This method is for enemy spawning and score tracking
        private bool ContinueRound(GameTime gameTime)
        {
            // switch for moving on to endround
            bool readyToEnd = false;

            // the round doesn't check if all enemies are dead until no enemies are left to spawn
            if (!allEnemiesSpawned && spawnTime < 0)
            {

                int index = rand.Next(0, zombies.Count);
                zombies[index].Initialize();
                zombies[index].Position += player.Position;

                // multiplier is a multiple of 8, 8 health per bullet required to kill
                zombies[index].MaxHealth *= (int)Math.Log2(roundNumber) + 2;
                zombies[index].Heal(zombies[index].MaxHealth - zombies[index].CurrentHealth);
                zombies[index].OnDeath += EnemyDeathListener;

                // Remove zombie from spawn list
                zombies.Remove(zombies[index]);

                // checks if no enemies are left to be spawned after enemy is spawned
                if (zombies.Count == 0)
                    allEnemiesSpawned = true;

                // reset timer
                spawnTime = period;
            }
            // this is for keeping each enemy spawn spaced out between a certain period of time
            else if (!allEnemiesSpawned && spawnTime > 0)
                spawnTime -= gameTime.DeltaTime();
            // once all enemies have been spawned, iterate through entity list until no more enemies remain
            else if (!allEnemiesKilled)
            {
                allEnemiesKilled = true;
                foreach (IEntity entity in EntityManager.Instance.Entities)
                {
                    if (entity is Enemy)
                        allEnemiesKilled = false;
                }
            }
            else
                readyToEnd = true;

            return readyToEnd;
        }

        // Ends the round and calculates round score
        private bool EndRound(GameTime gameTime)
        {
            if (endTime > 0)
            {
                endTime -= gameTime.DeltaTime();
                return false;
            }
            else
            {
                ItemPickup item;
                foreach (KeyValuePair<string, int> kvp in entityCounts)
                {
                    item = new ItemPickup(new Vector2(-3904, -2040), kvp.Key);
                    item.Initialize();
                    
                }

                score += scoreValue["Round Finish"];
                if (!tookDamage)
                {
                    score += scoreValue["No Damage Taken"];
                }
                return true;
            }
        }

        private void EnemyDeathListener(string name)
        {
            if (scoreValue.ContainsKey(name + " Kill"))
            {
                score += scoreValue[name + " Kill"];
                numOfKills++;
            }
        }

        private void PlayerHealthListener(int health)
        {
            tookDamage = true;
        }
    }
}
