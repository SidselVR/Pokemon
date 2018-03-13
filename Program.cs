using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> roster = new List<Pokemon>();

            // INITIALIZE YOUR THREE POKEMONS HERE

            //creating all the move lists
            List<Move> CharmanderMove = new List<Move>();
            List<Move> BulbasaurMove = new List<Move>();
            List<Move> SquirtleMove = new List<Move>();

            //Making all the moves
            Move Ember = new Move("Tail[0]");
            Move FireBlast = new Move("Fire Blast[1]");

            Move Bite = new Move("Bite[0]");
            Move Bubble = new Move("Bubble[1]");

            Move Cut = new Move("Cut[0]");
            Move MegaDrain = new Move("Mega Drain[0]");
            Move RazorLeaf = new Move("Razor Leaf[1]");

            //Adding moves to lists
            CharmanderMove.Add(Ember);
            CharmanderMove.Add(FireBlast);

            SquirtleMove.Add(Bite);
            SquirtleMove.Add(Bubble);

            BulbasaurMove.Add(Cut);
            BulbasaurMove.Add(MegaDrain);
            BulbasaurMove.Add(RazorLeaf);


            //initializing pokemon
            Pokemon Charmander = new Pokemon ("Charmander", 3, 52, 43, 39, Elements.Fire, CharmanderMove);
            Pokemon Squirtle = new Pokemon ("Squirtle", 2, 48, 65, 44, Elements.Water, SquirtleMove);
            Pokemon Bulbasaur = new Pokemon ("Bulbasaur", 3, 49, 49, 45, Elements.Grass, BulbasaurMove);
            roster.Add(Charmander);
            roster.Add(Squirtle);
            roster.Add(Bulbasaur);

            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit");

            while (true)
            {
                Console.WriteLine("\nPlese enter a command");
                switch (Console.ReadLine())
                {
                    case "list":
                        // PRINT THE POKEMONS IN THE ROSTER HERE
                        Console.WriteLine("The available pokemons are: ");
                        break;

                    case "fight":
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION)
                        Console.Write("Choose who should fight (Choose two) : " /*FIGURE OUT HOW TO PRINT ROSTER LIST*/);

                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES
                        string input = Console.ReadLine();
                        string[] inputs = input.Split(' ');

                        //Makes a player and enemy available
                        Pokemon player = null;
                        Pokemon enemy = null;

                        switch (inputs[0])
                        {
                            //Sees which first command is given then decides second
                            case "charmander":
                            case "Charmander":
                                switch (inputs[1])
                                {
                                    case "squirtle":
                                    case "Squirtle":
                                        player = roster[0];
                                        enemy = roster[1];
                                        break;

                                    case "bulbasaur":
                                    case "Bulbasaur":
                                        player = roster[0];
                                        enemy = roster[2];
                                        break;
                                }
                                break;

                            case "squirtle":
                            case "Squirtle":
                                switch (inputs[1])
                                {
                                    case "charmander":
                                    case "Charmander":
                                        player = roster[1];
                                        enemy = roster[0];
                                        break;

                                    case "bulbasaur":
                                    case "Bulbasaur":
                                        player = roster[1];
                                        enemy = roster[2];
                                        break;
                                }
                                break;

                            case "bulbasaur":
                            case "Bulbasaur":
                                switch (inputs[1])
                                {
                                    case "charmander":
                                    case "Charmander":
                                        player = roster[2];
                                        enemy = roster[0];
                                        break;

                                    case "squirtle":
                                    case "Squirtle":
                                        player = roster[2];
                                        enemy = roster[1];
                                        break;
                                }
                                break;

                            default:
                                break;
                        }

                        //BE SURE TO CHECK THE POKEMON NAMES THE USER WROTE ARE VALID (IN THE ROSTER) AND IF THEY ARE IN FACT 2!
                        

                        //if everything is fine and we have 2 pokemons let's make them fight
                        if (player != null && enemy != null && player != enemy)
                        {
                            Console.WriteLine("A wild " + enemy.Name + " appears!");
                            Console.Write(player.Name + " I choose you! ");

                            //BEGIN FIGHT LOOP
                            while (player.Hp > 0 && enemy.Hp > 0)
                            {
                                //PRINT POSSIBLE MOVES
                                Console.Write("What move should we use? (" + player.Moves + " )");

                                if (player == Charmander)
                                {
                                    switch (Console.ReadLine())
                                    {
                                        case "Ember":
                                        case "FireBlast":
                                            //Pokemon.Attack(Pokemon.enemy);
                                        break;
                                    }
                                }
                                else if (player == Squirtle)
                                {
                                    switch (Console.ReadLine())
                                    {
                                        case "Bite":
                                        case "Bubble":

                                        break;
                                    }
                                }
                                else if (player == Bulbasaur)
                                {
                                    switch (Console.ReadLine())
                                    {
                                        case "Cut":
                                        case "MegaDrain":
                                        case "RazorLeaf":

                                        break;
                                    }
                                }

                                //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN
                                int move = -1; //change this

                                //CALCULATE AND APPLY DAMAGE
                                int damage = -1; //change this

                                //print the move and damage
                                Console.WriteLine(player.Name + " uses " + player.Moves[move].Name + ". " + enemy.Name + " loses " + damage + " HP");

                                //if the enemy is not dead yet, it attacks
                                if (enemy.Hp > 0)
                                {
                                    //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                    Random rand = new Random();
                                    /*the C# random is a bit different than the Unity random
                                     * you can ask for a number between [0,X) (X not included) by writing
                                     * rand.Next(X) 
                                     * where X is a number 
                                     */
                                    int enemyMove = -1; //change this and the lower one
                                    int enemyDamage = -1;

                                    //print the move and damage
                                    Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");
                                }
                            }
                            //The loop is over, so either we won or lost
                            if (enemy.Hp <= 0)
                            {
                                Console.WriteLine(enemy.Name + " faints, you won!");
                            }
                            else
                            {
                                Console.WriteLine(player.Name + " faints, you lost...");
                            }
                        }
                        //otherwise let's print an error message
                        else
                        {
                            Console.WriteLine("Invalid pokemons");
                        }
                        break;

                    case "heal":
                        //RESTORE ALL POKEMONS IN THE ROSTER

                        Console.WriteLine("All pokemons have been healed");
                        break;

                    case "quit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }
    }
}
