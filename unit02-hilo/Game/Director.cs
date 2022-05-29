using System;
using System.Collections.Generic;


namespace unit02_hilo.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        List<Card> cards = new List<Card>();
        int currentCard = 0;
        int otherCard = 0;
        bool isPlaying = true;
        string highLow = "h";
        int score = 0;
        int totalScore = 300;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            for (int i = 0; i < 2; i++)
            {
                Card card = new Card();
                card.Draw();
                cards.Add(card);
            }
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Asks the user if they want to play.
        /// </summary>
        public void GetInputs()
        {
            Console.Write("Play again? [y/n] ");
            string drawCard = Console.ReadLine();
            isPlaying = (drawCard == "y");
            if (isPlaying)
            {
                Console.Write($"\nThe card is {cards[currentCard].value}");
                Console.Write("\nHigher or Lower? [h/l] ");
                highLow = Console.ReadLine();
            }
        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            if (!isPlaying)
            {
                return;
            }

            if (currentCard == 0)
            {
                otherCard = 1;
            }
            else
            {
                otherCard = 0;
            }

            cards[otherCard].Draw();

            score = 0;
            if ((cards[currentCard].value < cards[otherCard].value && highLow == "h") || 
                (cards[currentCard].value > cards[otherCard].value && highLow == "l"))
                {
                    score += 100;
                }
            else
            {
                score -= 75;
            }
            totalScore += score;

            if (currentCard == 0)
            {
                currentCard = 1;
            }
            else
            {
                currentCard = 0;
            }
        }

        /// <summary>
        /// Displays the next card and the score. Also asks the player if they want to try again. 
        /// </summary>
        public void DoOutputs()
        {
            if (!isPlaying)
            {
                return;
            }

            Console.WriteLine($"Next card was: {cards[otherCard].value}");
            Console.WriteLine($"Your score is: {totalScore}\n");
            isPlaying = (totalScore > 0);
        }
    }
}


