using UnityEngine;

namespace LevelGeneration
{
    // destroys any segment that passed a trigger completely (TriggerExit)
    // and tells the Segment Spawner to spawn a new one
    // only gets triggered by objects holding the SEGMENT TAG
    public class SegmentKillZone : MonoBehaviour
    {
        [SerializeField] private SegmentSpawner segmentSpawner;
    
        private void OnTriggerExit(Collider other)
        {
            if (!HasSegmentTag(other)) return;
            
            Destroy(other.gameObject);
            // inform the segment spawner that a segment was destroyed and a new one should be generated
            segmentSpawner.SpawnNext();
        }

        private bool HasSegmentTag(Collider other)
        {
            return other.CompareTag("Segment");
        }
    }
}
