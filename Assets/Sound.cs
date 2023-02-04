using UnityEngine;

namespace DefaultNamespace
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;

        [Range(0f, 1f)] public float volume;
        [Range(0f, 1f)] public float pitch;

        public bool loop;
        public float speed = 1f;
        [HideInInspector]
        public AudioSource source;
    }
}