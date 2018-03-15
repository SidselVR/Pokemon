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

            // INITIALIZE YOUR THREE POKEMONS HERE (I did moves too)

            //creating all the move lists
            List<Move> CharmanderMove = new List<Move>();
            List<Move> BulbasaurMove = new List<Move>();
            List<Move> SquirtleMove = new List<Move>();

            //Making all the moves
            Move Ember = new Move("Ember[0]");
            Move FireBlast = new Move("FireBlast[1]");

            Move Bite = new Move("Bite[0]");
            Move Bubble = new Move("Bubble[1]");

            Move Cut = new Move("Cut[0]");
            Move MegaDrain = new Move("MegaDrain[1]");
            Move RazorLeaf = new Move("RazorLeaf[2]");

            //Adding moves to lists
            CharmanderMove.Add(Ember);
            CharmanderMove.Add(FireBlast);

            SquirtleMove.Add(Bite);
            SquirtleMove.Add(Bubble);

            BulbasaurMove.Add(Cut);
            BulbasaurMove.Add(MegaDrain);
            BulbasaurMove.Add(RazorLeaf);


            //making and initializing pokemon
            Pokemon Charmander = new Pokemon ("Charmander", 3, 52, 43, 39, Elements.Fire, CharmanderMove);
            Pokemon Squirtle = new Pokemon ("Squirtle", 2, 48, 65, 44, Elements.Water, SquirtleMove);
            Pokemon Bulbasaur = new Pokemon ("Bulbasaur", 3, 49, 49, 45, Elements.Grass, BulbasaurMove);
            roster.Add(Charmander);
            roster.Add(Squirtle);
            roster.Add(Bulbasaur);

            Console.WriteLine("Welcome to the world of Pokemon!\nThe available commands are list/fight/heal/quit");

            //what's going to happen/where commands are taken and actions made
            while (true)
            {
                Console.WriteLine("\nPlese enter a command");
                //Reads what command you did and acts accordingly
                switch (Console.ReadLine())
                {
                    case "list":
                        // PRINT THE POKEMONS IN THE ROSTER HERE (pokemon in roseter printed through for loop)
                        Console.WriteLine("The available pokemons are: ");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine(roster[i].Name);
                        }
                        break;

                    case "fight":
                        //PRINT INSTRUCTIONS AND POSSIBLE POKEMONS (SEE SLIDES FOR EXAMPLE OF EXECUTION) (same for loop used)
                        Console.Write("Choose who should fight (Choose two pokemon) : \n");
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine(roster[i].Name);
                        }


                        //READ INPUT, REMEMBER IT SHOULD BE TWO POKEMON NAMES (reads and splits command at each "space" for easier use)
                        string input = Console.ReadLine();
                        string[] inputs = input.Split(' ');

                        //Makes a player and enemy available
                        Pokemon player = null;
                        Pokemon enemy = null;

                        switch (inputs[0])
                        {
                            //Sees which first command is given then decides second, sets players accordingly
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

                                    case "":
                                        continue;
                                }

                                break;

                            case "squirtle":
                            case "Squirtle":
                                switch (inputs[1])
                                {
                                    case "charmander ":
                                    case "Charmander ":
                                        player = roster[1];
                                        enemy = roster[0];
                                        break;

                                    case "bulbasaur":
                                    case "Bulbasaur":
                                        player = roster[1];
                                        enemy = roster[2];
                                        break;

                                    case "":
                                        continue;
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

                                    case "":
                                        continue;
                                }
                                break;

                            case "":
                                continue;

                            default:
                                continue;
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
                                //PRINT POSSIBLE MOVES / moves are checked in the if statement so that each player has the moved for their pokemon printed
                                Console.Write("What move should we use? \n");

                                //Explanation here repeats for the next else if's 
                                if (player == Charmander)
                                {
                                    //prints moves
                                    for (int i = 0; i < 2; i++)
                                    {
                                        Console.WriteLine(roster[0].Moves[i].Name);
                                    }

                                    //Switch for each case of move
                                    switch (Console.ReadLine())
                                    {
                                        case "0":
                                            //making the attack and telling player (damage + hp reduction happens in pokemon script)
                                            player.Attack(enemy);
                                            Console.WriteLine(player.Name + " uses " + player.Moves[0].Name + ". " + enemy.Name + " loses " + player.Damage + " HP");
                                            break;

                                        case "1":
                                            player.Attack(enemy);
                                            Console.WriteLine(player.Name + " uses " + player.Moves[1].Name + ". " + enemy.Name + " loses " + player.Damage + " HP");
                                            break;

                                        default:
                                            Console.WriteLine("Unknown move.");
                                            continue;
                                    }

                                }
                                else if (player == Squirtle)
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        Console.WriteLine(roster[1].Moves[i].Name);
                                    }

                                    switch (Console.ReadLine())
                                    {
                                        case "0":
                                            player.Attack(enemy);
                                            Console.WriteLine(player.Name + " uses " + player.Moves[0].Name + ". " + enemy.Name + " loses " + player.Damage + " HP");
                                            break;

                                        case "1":
                                            player.Attack(enemy);
                                            Console.WriteLine(player.Name + " uses " + player.Moves[1].Name + ". " + enemy.Name + " loses " + player.Damage + " HP");
                                            break;

                                        default:
                                            Console.WriteLine("Unknown move.");
                                            continue;
                                    }
                                }
                                else if (player == Bulbasaur)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        Console.WriteLine(roster[2].Moves[i].Name);
                                    }

                                    switch (Console.ReadLine())
                                    {
                                        case "0":
                                            player.Attack(enemy);
                                            Console.WriteLine(player.Name + " uses " + player.Moves[0].Name + ". " + enemy.Name + " loses " + player.Damage + " HP");
                                            break;

                                        case "1":
                                            player.Attack(enemy);
                                            Console.WriteLine(player.Name + " uses " + player.Moves[1].Name + ". " + enemy.Name + " loses " + player.Damage + " HP");
                                            break;

                                        case "2":
                                            player.Attack(enemy);
                                            Console.WriteLine(player.Name + " uses " + player.Moves[2].Name + ". " + enemy.Name + " loses " + player.Damage + " HP");
                                            break;

                                        default:
                                            Console.WriteLine("Unknown move.");
                                            continue;
                                    }
                                }

                                //GET USER ANSWER, BE SURE TO CHECK IF IT'S A VALID MOVE, OTHERWISE ASK AGAIN (made above)
                                //CALCULATE AND APPLY DAMAGE (done in pokemon script)
                                //print the move and damage (also done above)


                                //if the enemy is not dead yet, it attacks
                                if (enemy.Hp > 0 && player.Hp > 0)
                                {
                                    //CHOOSE A RANDOM MOVE BETWEEN THE ENEMY MOVES AND USE IT TO ATTACK THE PLAYER
                                    Random rand = new Random();
                                    /*the C# random is a bit different than the Unity random
                                     * you can ask for a number between [0,X) (X not included) by writing
                                     * rand.Next(X) 
                                     * where X is a number 
                                     */
                                     //checks which pokemon the enemy is (explanation repeats for next if's)
                                    if (enemy == Charmander)
                                    {
                                        //picks a random number from 0-1 (in Bulbasaur it's from 0-2)
                                        switch (rand.Next(2))
                                        {
                                            //performs attack depending on move
                                            case 0:
                                                enemy.AttackEnemy(player);
                                                Console.WriteLine(enemy.Name + " uses " + enemy.Moves[0].Name + ". " + player.Name + " loses " + enemy.Damage + " HP");
                                                break;

                                            case 1:
                                                enemy.AttackEnemy(player);
                                                Console.WriteLine(enemy.Name + " uses " + enemy.Moves[1].Name + ". " + player.Name + " loses " + enemy.Damage + " HP");
                                                break;
                                        }
                                    }
                                    if (enemy == Squirtle)
                                    {
                                        switch (rand.Next(2))
                                        {
                                            case 0:
                                                enemy.AttackEnemy(player);
                                                Console.WriteLine(enemy.Name + " uses " + enemy.Moves[0].Name + ". " + player.Name + " loses " + enemy.Damage + " HP");
                                                break;

                                            case 1:
                                                enemy.AttackEnemy(player);
                                                Console.WriteLine(enemy.Name + " uses " + enemy.Moves[1].Name + ". " + player.Name + " loses " + enemy.Damage + " HP");
                                                break;
                                        }
                                    }
                                    if (enemy == Bulbasaur)
                                    {
                                        switch (rand.Next(3))
                                        {
                                            case 0:
                                                enemy.AttackEnemy(player);
                                                Console.WriteLine(enemy.Name + " uses " + enemy.Moves[0].Name + ". " + player.Name + " loses " + enemy.Damage + " HP");
                                                break;

                                            case 1:
                                                enemy.AttackEnemy(player);
                                                Console.WriteLine(enemy.Name + " uses " + enemy.Moves[1].Name + ". " + player.Name + " loses " + enemy.Damage + " HP");
                                                break;

                                            case 2:
                                                enemy.AttackEnemy(player);
                                                Console.WriteLine(enemy.Name + " uses " + enemy.Moves[2].Name + ". " + player.Name + " loses " + enemy.Damage + " HP");
                                                break;
                                        }
                                    }

                                    //print the move and damage (done above)
                                    //Console.WriteLine(enemy.Name + " uses " + enemy.Moves[enemyMove].Name + ". " + player.Name + " loses " + enemyDamage + " HP");
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
                        //calls each pokemon's Restore function to heal all of them, then tells the player
                        for (int i = 0; i < 3; i++)
                        {
                            roster[i].Restore();
                        }
                        Console.WriteLine("All pokemons have been healed");
                        break;

                        //quits the game
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
