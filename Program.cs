using System;

namespace mis321_pa2_ajstevenson1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to the Battle of Calypso's maelstrom!");
            DisplayMainMenu();
            int userInput = TestInputInt();
            while (userInput != 3)
            {
                if(userInput == 1)
                {
                    PlayAI();
                }
                else
                {
                    TwoPlayer();
                }
                DisplayMainMenu();
                userInput = TestInputInt();
            }
            
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Please select one of the following: \n1. Play against AI \n2. 2 Player \n3. Exit");
        }

        static void CharacterMenu()
        {
            System.Console.WriteLine("Please select a character: \n1. Jack Sparrow \n2. Will Turner \n3. Davy Jones");
        }

        static int TestInputInt()
        {
            int userInput;
            bool test = int.TryParse(Console.ReadLine(), out userInput);
            while(test == false || userInput < 1 || userInput > 3)
            {
                System.Console.WriteLine("ERROR: Invalid input. Try again");
                test = int.TryParse(Console.ReadLine(), out userInput);
            }
            return userInput;
        }

        static void TwoPlayer()
        {
            Console.Clear();
            System.Console.WriteLine("Player 1, select your character:");
            CharacterMenu();
            int firstUserInput = TestInputInt();
            Console.Clear();
            System.Console.WriteLine("Player 1, please enter your name:");
            string firstName = Console.ReadLine();
            Console.Clear();
            System.Console.WriteLine("Player 2, select your character:");
            CharacterMenu();
            int secondUserInput = TestInputInt();
            Console.Clear();
            System.Console.WriteLine("Player 2, please enter your name:");
            string secondName = Console.ReadLine();
            Console.Clear();
            Character player1 = new Character();
            DetermineCharacter(firstUserInput, firstName, ref player1);
            Character player2 = new Character();
            DetermineCharacter(secondUserInput, secondName, ref player2);
            player1.SetAttackBehavior(player2);
            player2.SetAttackBehavior(player1);

            int goFirst = DetermineFirst();
            if(goFirst == 1)
            {
                System.Console.WriteLine($"{player1.PlayerName} attacks first!");
                PressKeyToContinue();
                while (player1.Health > 0 && player2.Health > 0)
                {
                    player1.AttackBehavior.Attack(player1, player2);
                    PressKeyToContinue();
                    if(player2.Health > 0)
                    {
                       player2.AttackBehavior.Attack(player2, player1);
                       PressKeyToContinue();
                    }
                    player1.DisplayStats();
                    System.Console.WriteLine();
                    player2.DisplayStats();
                    System.Console.WriteLine();
                    PressKeyToContinue();
                    player1.UpdateAttackDefend(); // fix this pls
                    player2.UpdateAttackDefend();
                }
                
            }
            else
            {
                System.Console.WriteLine($"{player2.PlayerName} attacks first!");
                PressKeyToContinue();
                while (player1.Health > 0 && player2.Health > 0)
                {
                    player2.AttackBehavior.Attack(player2, player1);
                    PressKeyToContinue();
                    if(player1.Health > 0)
                    {
                       player1.AttackBehavior.Attack(player1, player2);
                       PressKeyToContinue();
                    }
                    player1.DisplayStats();
                    System.Console.WriteLine();
                    player2.DisplayStats();
                    System.Console.WriteLine();
                    PressKeyToContinue();
                    player1.UpdateAttackDefend(); // fix this pls
                    player2.UpdateAttackDefend();
                }
            }
            if(player2.Health == 0)
            {
                System.Console.WriteLine($"{player2.PlayerName} has lost all of their health!");
                System.Console.WriteLine($"{player1.PlayerName} wins!");
            }
            else
            {
                System.Console.WriteLine($"{player1.PlayerName} has lost all of their health!");
                System.Console.WriteLine($"{player2.PlayerName} wins!");
            }
            PressKeyToContinue();

        }

        static void PlayAI()
        {

        }

        static void DetermineCharacter(int userInput, string name, ref Character player)
        {
            if(userInput == 1)
            {
                player = new JackSparrow(name);
            }
            else if(userInput == 2)
            {
                player = new WillTurner(name);
            }
            else
            {
                player = new DavyJones(name);
            }
        }

        static int DetermineFirst()
        {
            Random random = new Random();
            int number = random.Next(2);
            number++;
            return number;
        }

        static void PressKeyToContinue()
        {
            System.Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
