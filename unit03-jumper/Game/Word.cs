using System;
using System.Collections.Generic;
using unit03_jumper.Game;


namespace unit03_jumper.Game 
{
    /// <summary>
    /// <para>The word the user is trying to find.</para>
    /// <para>
    /// The responsibility of Word is to keep track of its location and distance from the seeker.
    /// </para>
    /// </summary>
    public class Word
    {
        public List<string> words = new List<string>()
        {"frame", "bread", "stove", "pears", "drags", "clock"};
        public string word;
        private List<char> guesses = new List<char>();
        private List<char> hint = new List<char>()
        {'_', ' ', '_', ' ', '_', ' ', '_', ' ', '_'};
        bool first_run = true;

        Guess hi = new Guess();

        /// <summary>
        /// Constructs a new instance of Word. 
        /// </summary>
        public Word()
        {
            Random random = new Random();
            word = words[random.Next(6)];
        }

        /// <summary>
        /// Updates the hint. 
        /// </summary>
        private void UpdateHint(Jumper jumper)
        {
            int letterIndex = 0;
            bool found = false;

            if (! first_run)
            {
                foreach(char letter in word)
                {
                    if (! found && guesses[guesses.Count - 1] == letter)
                    {
                        found = true;
                        hint[letterIndex * 2] = letter;
                    }
                    letterIndex += 1;
                }
                if (! found)
                {
                    jumper.UpdateIncorrectGuesses();
                }
            }
            else
            {
                first_run = false;
            }
        }

        /// <summary>
        /// Gets a hint for the user.
        /// </summary>
        /// <returns>A new hint.</returns>
        public List<char> GetHint(Jumper jumper)
        {
            UpdateHint(jumper);
            return hint;
        }

        /// <summary>
        /// Whether or not the Word has been found.
        /// </summary>
        /// <returns>True if found; false if otherwise.</returns>
        public bool IsFound()
        {
            bool found = false;

            foreach(char character in hint)
            {
                if(character == '_')
                {
                    found = true;
                }
            }
            return found;
        }

        /// <summary>
        /// Watches the seeker by keeping track of how far away it is.
        /// </summary>
        /// <param name="seeker">The seeker to watch.</param>
        public void WatchGuess(Guess guess)
        {
            guesses.Add(guess.GetLetter());
        }
    }
}