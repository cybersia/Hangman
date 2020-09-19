using System;
using System.Linq;
using System.Text;

class MainClass
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Let's play Hangman");


        // Generates Random Word for the player 

        #region Randomizer
        string[] listwords = new string[10];
        listwords[0] = "apple";
        listwords[1] = "orange";
        listwords[2] = "banana";
        listwords[3] = "plum";
        listwords[4] = "grape";
        listwords[5] = "berry";
        listwords[6] = "carrot";
        listwords[7] = "tomato";
        listwords[8] = "fork";
        listwords[9] = "spoon";
        Random randGen = new Random();
        var idx = randGen.Next(0, 9);
        string secretWord = listwords[idx];
        #endregion
       

        secretWord = secretWord.ToUpper();
        Console.WriteLine(secretWord);

       
        //Variables

        int lives = 10;
        int counter = -1;
        int wordLength = secretWord.Length;
        char[] secretArray = secretWord.ToCharArray();
        char[] printArray = new char[wordLength];
        char[] guessedLetters = new char[26];
        int numberStore = 0;
        string fullGuess = "";
        bool victory = false;
       


        foreach (char letter in printArray)
        {
            counter++;
            printArray[counter] = '-';
        }

        while (lives > 0)
        {
            counter = -1;
            string printProgress = String.Concat(printArray);
            bool letterFound = false;
            int multiples = 0;

            if (printProgress == secretWord)
            {
                victory = true;
                break;
            }

            if (lives > 1)
            {
                Console.WriteLine("You have {0} lives!", lives);
            }
            else
            {
                Console.WriteLine("You only have {0} life left!!", lives);
            }


            Console.WriteLine("current progress: " + printProgress);

            Console.Write("\n\n\n");
            Console.WriteLine("Guessed letters: [{0}]", string.Join(" ", guessedLetters));
            Console.Write(" Guess a letter or a word : ");
            string playerGuess = Console.ReadLine();

            playerGuess = playerGuess.ToUpper();

          
            // Function to guess the Whole Word if neccessary

            if (playerGuess.Length != 1)
            {
                            
                fullGuess = playerGuess;
                fullGuess = fullGuess.ToUpper();
                
                {
                    if (fullGuess == secretWord)
                    {
                        victory = true;
                        break;
                    }
                    else
                    {
                        lives--;
                        continue;
                    }
                }

            }
            


                       
            char playerChar = Convert.ToChar(playerGuess);
            Console.WriteLine(playerChar);

            if (guessedLetters.Contains(playerChar) == false)
            {

                guessedLetters[numberStore] = playerChar;
                numberStore++;
                
                foreach (char letter in secretArray)
                {
                    counter++;
                    if (letter == playerChar)
                    {
                        printArray[counter] = playerChar;
                        letterFound = true;
                        multiples++;
                    }

                }

                if (letterFound)
                {
                    Console.WriteLine("Found {0} letter {1}!", multiples, playerChar);
                }
                else
                {
                    Console.WriteLine("No letter {0}!", playerChar);
                    lives--;

                    
                   
                }
                Console.WriteLine(GallowView(lives));
            }
            else
            {
                Console.WriteLine("You already guessed {0}!!", playerChar);
            }


        }

        #region Determins If Youve Won

        if (victory)
        {
            Console.WriteLine("\n\nThe word was: {0}", secretWord);
            Console.WriteLine("\n\nYOU WIN!!!!!!!!!!!");
        }
        else
        {
            Console.WriteLine("\n\nThe word was: {0}", secretWord);
            Console.WriteLine("\n\nYOU HAVE LOST!!!!!!!!!");
        }
        #endregion

    }


    // Function to Draw the Hang Man

    #region Drawing
    private static string GallowView (int livesLeft)
    {
        

        string drawHangman = "";

        if (livesLeft < 10)
        {
            drawHangman += "       |\n";
        }

        if (livesLeft < 9)
        {
            drawHangman += "       |\n";

        }

        if (livesLeft < 8)
        {
            drawHangman += "       |\n";
        }

        if (livesLeft < 7)
        {
            drawHangman += "       |\n";
        }

        if (livesLeft < 6)
        {
            drawHangman += "       |\n";
        }

        if (livesLeft < 5)
        {
            drawHangman += "       |\n";
        }

        if (livesLeft < 4)
        {
            drawHangman += "       |\n";
        }

        if (livesLeft < 3)
        {
            drawHangman += "       O\n";
        }

        if (livesLeft < 2)
        {
            drawHangman += "      /|\\ \n";
        }

        if (livesLeft == 0)
        {
            drawHangman += "      / \\ \n";
        }

        return drawHangman;

    }

    #endregion


}