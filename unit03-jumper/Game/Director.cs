using System;

namespace unit03_jumper.Game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private Jumper jumper = new Jumper();
        private Word word = new Word();
        private Guess guess = new Guess();
        private bool isPlaying = true;
        private TerminalService terminalService = new TerminalService();

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            bool firstRun = true;
            while (isPlaying)
            {
                if (firstRun)
                {
                    string hint = string.Join("",word.GetHint(jumper));
                    terminalService.WriteText(hint);
                    terminalService.WriteText("");
                    jumper.DisplayJumper();
                    firstRun = false;
                }
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Moves the seeker to a new location.
        /// </summary>
        private void GetInputs()
        {
            // terminalService.WriteText(word.location.ToString());
            string guess_string = terminalService.ReadText("\nGuess a letter [a-z]: ");
            guess.UpdateLetter(guess_string);
        }

        /// <summary>
        /// Keeps watch on where the seeker is moving.
        /// </summary>
        private void DoUpdates()
        {
            word.WatchGuess(guess);
        }

        /// <summary>
        /// Provides a hint for the seeker to use.
        /// </summary>
        private void DoOutputs()
        {
            string hint = string.Join("",word.GetHint(jumper));
            terminalService.WriteText(hint);
            terminalService.WriteText("");
            jumper.DisplayJumper();
            if (word.IsFound() || jumper.GetDead())
            {
                isPlaying = false;
            }
            
        }
    }
}