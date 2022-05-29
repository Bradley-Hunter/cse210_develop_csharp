using System;


namespace unit03_jumper.Game
{
    /// <summary>
    /// <para>The person looking for the Hider.</para>
    /// <para>
    /// The responsibility of a Seeker is to keep track of its location.
    /// </para>
    /// </summary>
    public class Guess
    {
        private char currentLetter;
        
        /// <summary>
        /// Constructs a new instance of Seeker.
        /// </summary>
        public Guess()
        {
            
        }
               
        /// <summary>
        /// Gets the current location.
        /// </summary>
        /// <returns>The current letter as a char.</returns>
        public char GetLetter()
        {
            return currentLetter;
        }
                
        /// <summary>
        /// Moves to the given letter.
        /// </summary>
        /// <param name="letter">The given letter.</param>
        public void UpdateLetter(string letter)
        {
            currentLetter= char.Parse(letter);
        }
    }
}