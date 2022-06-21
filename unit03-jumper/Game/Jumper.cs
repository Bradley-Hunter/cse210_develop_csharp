using System;
using System.Collections.Generic;

namespace unit03_jumper.Game
{
    /// <summary>
    /// <para>The person looking for the Hider.</para>
    /// <para>
    /// The responsibility of a Seeker is to keep track of its location.
    /// </para>
    /// </summary>
    public class Jumper
    {
        private int numIncorrectGuesses = 0;
        private List<string> jumperAlive = new List<string>()
        {@"  ___", @" /___\", @" \   /", @"  \ /", @"   0", @"  /|\", @"  / \", "", @"^^^^^^^"};
        private List<string> jumperDead = new List<string>()
        {@"   X", @"  /|\", @"  / \", "", @"^^^^^^^"};
        bool dead = false;
        private TerminalService terminalService = new TerminalService();

        /// <summary>
        /// Constructs a new instance of Seeker.
        /// </summary>
        public Jumper()
        {
            // DisplayJumper();
        }
           
        /// <summary>
        /// Gets the current location.
        /// </summary>
        /// <returns>The current location as an int.</returns>
        public void DisplayJumper()
        {
            if (numIncorrectGuesses < 4)
            {
                for(int i = numIncorrectGuesses; i < jumperAlive.Count; i++)
                {
                    terminalService.WriteText(jumperAlive[i]);
                }
            }
            else 
            {
                foreach(string line in jumperDead)
                {
                    terminalService.WriteText(line);
                }
                UpdateDead(true);
            }
        }

        private void UpdateDead(bool isDead)
        {
            dead = isDead;
        }

        public bool GetDead()
        {
            return dead;
        }
            
        /// <summary>
        /// Moves to the given location.
        /// </summary>
        /// <param name="location">The given location.</param>
        public void UpdateIncorrectGuesses()
        {
            numIncorrectGuesses += 1;
        }
    }
}