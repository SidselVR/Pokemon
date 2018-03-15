using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    /// <summary>
    /// The possible elemental types
    /// </summary>
    public enum Elements
    {
        Fire,
        Water,
        Grass
    }

    public class Pokemon
    {
        //fields
        int level;
        int baseAttack;
        int baseDefence;
        int hp;
        int maxHp;
        Elements element;

        //properties, imagine them as private fields with a possible get/set property (accessors)
        //in this case used to allow other objects to read (get) but not write (no set) these variables
        public string Name { get; }
        //example of how to make the string Name readable AND writable  
        //  public string Name { get; set; }
        public List<Move> Moves { get; }
        //can also be used to get/set other private fields
        public int Hp { get => hp; }
        //Added 3 ints to keep track of Damage, defence and elementalEffect
        public int Damage;
        public int defence;
        public int elementalEffect;

        /// <summary>
        /// Constructor for a Pokemon, the arguments are fairly self-explanatory
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <param name="baseAttack"></param>
        /// <param name="baseDefence"></param>
        /// <param name="hp"></param>
        /// <param name="element"></param>
        /// <param name="moves">This needs to be a List of Move objects</param>
        public Pokemon(string name, int level, int baseAttack,
            int baseDefence, int hp, Elements element,
            List<Move> moves)
        {
            this.level = level;
            this.baseAttack = baseAttack;
            this.baseDefence = baseDefence;
            this.Name = name;
            this.hp = hp;
            this.maxHp = hp;
            this.element = element;
            this.Moves = moves;
        }

        /// <summary>
        /// performs an attack and returns total damage, check the slides for how to calculate the damage
        /// IMPORTANT: should also apply the damage to the enemy pokemon
        /// </summary>
        /// <param name="enemy">This is the enemy pokemon that we are attacking</param>
        /// <returns>The amount of damage that was applied so we can print it for the user</returns>
        //Performs an attack, explanation repeats in the next function, just with the enemy and player switched
        public int Attack(Pokemon enemy)
        {
            //first calculates enemy defense and player elemental effect
            enemy.CalculateDefence();
            CalculateElementalEffects(enemy.element);
            //performs attack taking attack, level, elementaleffect and defence in consideration
            this.Damage = (this.baseAttack * this.level) * this.elementalEffect - (enemy.defence);

            //in case the damage is - we want it to be 0, as we do not want to heal the opposing pokemon
            if (this.Damage < 0)
            {
                this.Damage = 0;
            }
            //Applies damage to the enemy pokemon
            enemy.ApplyDamage(this.Damage);
            //returns damage
            return Damage;
        }

        public int AttackEnemy(Pokemon player)
        {
            player.CalculateDefence();
            CalculateElementalEffects(player.element);
            this.Damage = (this.baseAttack * this.level) * this.elementalEffect - (player.defence);

            if (this.Damage < 0)
            {
                this.Damage = 0;
            }
            player.ApplyDamage(this.Damage);
            return Damage;
        }

        /// <summary>
        /// calculate the current amount of defence points
        /// </summary>
        /// <returns> returns the amount of defence points considering the level as well</returns>
        //calculates defence of a pokemon and returns said defence
        public int CalculateDefence()
        {
            this.defence= this.baseDefence * this.level;
            return defence;
        }

        /// <summary>
        /// Calculates elemental effect, check table at https://bulbapedia.bulbagarden.net/wiki/Type#Type_chart for a reference
        /// </summary>
        /// <param name="damage">The amount of pre elemental-effect damage</param>
        /// <param name="enemyType">The elemental type of the enemy</param>
        /// <returns>The damage post elemental-effect</returns>
        //first explanation repeats throughout the entire function. 
        //I decided to take away the "int damage" and make the function a "void" instead of "int" as i found this easier to implement and work with 
        public void CalculateElementalEffects(Elements enemyType)
        {
            //checks which element the pokemon calling this is
            if (this.element == Elements.Fire)
            {
                //hereafter checks the other pokemon's element
                if (enemyType == Elements.Water)
                {
                    //Gives elementaleffect according to the two elements
                    this.elementalEffect = (1/2);
                }
                else if (enemyType == Elements.Grass)
                {
                    this.elementalEffect = 2;
                }
            }
            if (this.element == Elements.Water)
            {
                if (enemyType == Elements.Grass)
                {
                    this.elementalEffect = (1/2);
                }
                else if (enemyType == Elements.Fire)
                {
                    this.elementalEffect = 2;
                }
            }
            if (this.element == Elements.Grass)
            {
                if (enemyType == Elements.Fire)
                {
                    this.elementalEffect = (1/2);
                }
                else if (enemyType == Elements.Water)
                {
                    this.elementalEffect = 2;
                }
            }
        }

        /// <summary>
        /// Applies damage to the pokemon
        /// </summary>
        /// <param name="damage"></param>
        //applies damage to pokemon
        public void ApplyDamage(int damage)
        {
            this.hp = this.hp - damage;
        }

        /// <summary>
        /// Heals the pokemon by resetting the HP to the max
        /// </summary>
        //Restores the health of the pokemon
        public void Restore()
        {
            hp = maxHp;
        }
    }
}
