using UnityEngine;

namespace LevelGeneration
{
    // destroys any segment that passed a trigger completely (TriggerExit)
    // and tells the Segment Spawner to spawn a new one
    // only gets triggered by objects holding the SEGMENT TAG or INTERMEDIATE TAG
    // INTERMEDIATE TAGs don't trigger spawning as they are spawned together with a segment (else too much spawned) 
    public class SegmentKillZone : MonoBehaviour
    {
        [SerializeField] private SegmentSpawner segmentSpawner;

        private void OnTriggerExit(Collider other)
        {
            if (!HasCorrectTag(other)) return;

            // destroy objects that passed the camera completely
            Destroy(other.gameObject);

            // only trigger new segment to spawn if you are a segment (otherwise exponential growth of #segments)
            if (HasIntermediateTag(other)) return;
            // inform the segment spawner that a segment was destroyed and a new one should be generated
            segmentSpawner.SpawnNext();
        }


        // check what tag the object has
        #region TagChecks

        private bool HasCorrectTag(Collider other)
        {
            return HasSegmentTag(other) || HasIntermediateTag(other);
        }

        private bool HasSegmentTag(Collider other)
        {
            return other.CompareTag("Segment");
        }


        private bool HasIntermediateTag(Collider other)
        {
            return other.CompareTag("Intermediate");
        }

        #endregion
    }
}