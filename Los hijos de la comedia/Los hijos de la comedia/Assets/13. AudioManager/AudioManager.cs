using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;

    [SerializeField] AudioSource saltoSource;
    [SerializeField] List<AudioClip> saltoClips = new List<AudioClip>();


    public const string MASTER_KEY = "master";
    public const string MUSIC_KEY = "music";
    public const string SFX_KEY = "SFX";
    public const string VOCES_KEY = "Voces";

    public const string LOWPASS_KEY = "LowPass";


    private float transitionDuration = 1f; // Duración de la transición en segundos

    private float transitionTimer = 0.0f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LowPassChangeNormal();
    }

    public void SaltoSFX()
    {
        AudioClip clip = saltoClips[Random.Range(0, saltoClips.Count)];
        saltoSource.PlayOneShot(clip);
    }

    void LoadVolume() //Volume saved in volumeSetting.cs
    {
        float MasterVolume = PlayerPrefs.GetFloat(MASTER_KEY, 1f);
        float MusicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float SFXVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);
        float VocesVolume = PlayerPrefs.GetFloat(VOCES_KEY, 1f);

        mixer.SetFloat(VolumeSettings.MIXER_MASTER, Mathf.Log10(MasterVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(MusicVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, Mathf.Log10(SFXVolume) * 20);
        mixer.SetFloat(VolumeSettings.MIXER_VOCES, Mathf.Log10(VocesVolume) * 20);
    }


    public IEnumerator LowPassSmoothTransition(float start, float end)
    {
        float startTime = Time.time;
        while (transitionTimer < transitionDuration)
        {
            transitionTimer = Time.time - startTime;

            float t = Mathf.Clamp01(transitionTimer / transitionDuration);

            // Interpola linealmente entre el valor inicial y final
            float currentValue = Mathf.Lerp(start, end, t);

            // Aplica el valor al mixer
            mixer.SetFloat(VolumeSettings.MIXER_LOWPASS, currentValue);

            yield return null;
        }

        // Asegúrate de que al final la frecuencia de corte sea exactamente el valor final
        mixer.SetFloat(VolumeSettings.MIXER_LOWPASS, end);

        // Restablece el temporizador
        transitionTimer = 0.0f;
    }

    public void LowPassChangeNormal()
    {
        mixer.SetFloat(VolumeSettings.MIXER_LOWPASS, 15000.0f);
    }
}
