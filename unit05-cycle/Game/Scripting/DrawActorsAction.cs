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

            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}