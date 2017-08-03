using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfSheeps
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource SfxSource;
        public AudioSource MusicSource;

        public static SoundManager Instance = null;

        public float LowPitchRange = .95f;
        public float HighPitchRange = 1.05f;

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public void PlaySingleSfx(AudioClip clip)
        {
            SfxSource.clip = clip;
            SfxSource.Play();
        }

        public void PlayRandomizeSfx(params AudioClip[] clips)
        {
            var randomClipIndex = Random.Range(0, clips.Length);
            var randomPitch = Random.Range(LowPitchRange, HighPitchRange);
            SfxSource.pitch = randomPitch;
            SfxSource.clip = clips[randomClipIndex];
            SfxSource.Play();
        }

        void Update()
        {

        }
    }
}