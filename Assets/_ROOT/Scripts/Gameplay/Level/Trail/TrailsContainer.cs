namespace SnakeRunner.Gameplay.Level
{
    using System.Collections.Generic;
    using UnityEngine;

    public class TrailsContainer : MonoBehaviour
    {
        public List<Trail> Trails;

        public Trail InitialTrail()
        {
            var index = Trails.Count / 2;

            return Trails[index];
        }

        public Trail ToTheLeftFrom(Trail trail)
        {
            int currentTrailIndex = Trails.IndexOf(trail);

            return currentTrailIndex > 0 ? Trails[currentTrailIndex - 1] : null;
        }

        public Trail ToTheRightFrom(Trail trail)
        {
            int currentTrailIndex = Trails.IndexOf(trail);

            return currentTrailIndex < Trails.Count - 1 ?Trails[currentTrailIndex + 1] : null;
        }
    }
}