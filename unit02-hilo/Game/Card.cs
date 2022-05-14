using System;


namespace unit02_hilo.Game
{

    /// <summary>
    /// A piece of paper with a number between 1 and 13 on one face of it.
    /// 
    /// The responsibility of card is to keep track of its currently drawn value.
    /// </summary> 
    public class Card
    {
        public int value;

        /// <summary>
        /// Constructs a new instance of Die.
        /// </summary>
        public Card()
        {

        }
    
        /// <summary>
        /// Generates a new random value and calculates the points for the die. Fives are 
        /// worth 50 points, ones are worth 100 points, everything else is worth 0 points.
        /// </summary>
        public void Draw()
        {
            Random card = new Random();
            value = card.Next(1, 13 + 1);
        }
    
    }

}