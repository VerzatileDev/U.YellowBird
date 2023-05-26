using UnityEngine;
using UnityEngine.Audio;

public class LoadPlayerAudio : MonoBehaviour
{
    public AudioMixer theMixer;
    public float DefaultMasterValue = 1.0f;
    public float DefaultMusicValue = 0.5f;
    public float DefaultSfxValue = 0.5f;

    private void Start()
    {
        if (PlayerPrefs.HasKey("VolumeSet") & PlayerPrefs.GetInt("VolumeSet") == 1)
        {
            GetPlayerGameAudioToMixer();
        }
        else
        {
            SetDefaultGameAudioSettingsToPlayerPrefs();
            SetDefaultGameAudioToMixer();
        }
    }

    public void SetDefaultGameAudioSettingsToPlayerPrefs()
    {
        PlayerPrefs.SetInt("VolumeSet", 0); // Stating the Values are Un-set
        PlayerPrefs.SetFloat("MasterValue", DefaultMasterValue);
        PlayerPrefs.SetFloat("MusicValue", DefaultMusicValue);
        PlayerPrefs.SetFloat("SfxValue", DefaultSfxValue);
    }

    public void SetDefaultGameAudioToMixer()
    {
        theMixer.SetFloat("MasterValue", Mathf.Log10(DefaultMasterValue) * 20);
        theMixer.SetFloat("MusicValue", Mathf.Log10(DefaultMusicValue) * 20);
        theMixer.SetFloat("SfxValue", Mathf.Log10(DefaultSfxValue) * 20);
    }

    public void GetPlayerGameAudioToMixer()
    {
        theMixer.SetFloat("MasterValue", Mathf.Log10(PlayerPrefs.GetFloat("MasterValue")) * 20);
        theMixer.SetFloat("MusicValue", Mathf.Log10(PlayerPrefs.GetFloat("MusicValue")) * 20);
        theMixer.SetFloat("SfxValue", Mathf.Log10(PlayerPrefs.GetFloat("SfxValue")) * 20);
    }
}
