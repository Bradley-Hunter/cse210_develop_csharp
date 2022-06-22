using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // List<Actor> snakes = (Actor)cast.GetActors("cycles");

            Cycle cycle1 = (Cycle)cast.GetFirstActor("cycles");
            Cycle cycle2 = (Cycle)cast.GetSecondActor("cycles");

            List<Cycle> cycles = new List<Cycle>();
            cycles.Add(cycle1);
            cycles.Add(cycle2);

            foreach(Cycle cycle in cycles)
            {
            List<Actor> segments = cycle.GetSegments();
            videoService.DrawActors(segments);
            }

            // Actor score1 = cast.GetFirstActor("score");
            // Actor score2 = cast.GetSecondActor("score");

            // List<Actor> scores = new List<Actor>();
            // scores.Add(score1);
            // scores.Add(score2);

            // foreach(Score score in scores)
            // {
            // videoService.DrawActor(score);
            
            // }



            // Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            // videoService.DrawActor(food);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}