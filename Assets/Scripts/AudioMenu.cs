using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{

    [System.Serializable]
    private class AudioProperties
    {
        public AudioMixer theMixer;
        [Space(1)]

        [Header("Sliders")]
        public Slider masterSlider = null;
        public Slider musicSlider = null;
        public Slider sfxSlider = null;
        [Space(1)]

        [Header("Labels")]
        public TMP_Text masterLabel = null;
        public TMP_Text musicLabel = null;
        public TMP_Text sfxLabel = null;

        
    }
    [SerializeField] private AudioProperties audioProperties;

    private new LoadAudio audio;

    public void Start()
    {
        
        //audio = GetComponent<LoadAudio>();

        
        if (PlayerPrefs.GetInt("VolumeSet") == 1)
        {
            getAssignedValuesToSlider();
        }
        else
        {
            getInitialValuesToSlider();
        }
    }
    public void SetMasterVol()
    {
        audioProperties.masterLabel.text = Mathf.RoundToInt(audioProperties.masterSlider.value *100).ToString();
        audioProperties.theMixer.SetFloat("MasterValue", Mathf.Log10(audioProperties.masterSlider.value) *20);
    }
    public void SetMusicVol()
    {
        audioProperties.musicLabel.text = Mathf.RoundToInt(audioProperties.musicSlider.value *100).ToString();
        audioProperties.theMixer.SetFloat("MusicValue", Mathf.Log10(audioProperties.musicSlider.value) *20);
    }
    public void SetSFXVol()
    {
        audioProperties.sfxLabel.text = Mathf.RoundToInt(audioProperties.sfxSlider.value *100).ToString();
        audioProperties.theMixer.SetFloat("SfxValue", Mathf.Log10(audioProperties.sfxSlider.value) *20);
    }
    public void SaveVolumeButton()
    {
        PlayerPrefs.SetFloat("MasterValue", audioProperties.masterSlider.value);
        PlayerPrefs.SetFloat("MusicValue", audioProperties.musicSlider.value);
        PlayerPrefs.SetFloat("SfxValue", audioProperties.sfxSlider.value);

        PlayerPrefs.SetInt("VolumeSet", 1);
    }

    void getInitialValuesToSlider()
    {

        float masterValue = PlayerPrefs.GetFloat("MasterValue", 1.0f);
        audioProperties.masterSlider.value = masterValue;


        float musicValue = PlayerPrefs.GetFloat("MusicValue", 0.6f);
        audioProperties.musicSlider.value = musicValue;
 

        float sfxValue = PlayerPrefs.GetFloat("SfxValue", 0.6f);
        audioProperties.sfxSlider.value = sfxValue;


        PlayerPrefs.SetInt("VolumeSet", 0);
        PlayerPrefs.SetFloat("MasterValue", masterValue);
        PlayerPrefs.SetFloat("MusicValue", musicValue);
        PlayerPrefs.SetFloat("SfxValue", sfxValue);
    }

    void getAssignedValuesToSlider()
    {
        float masterValue = PlayerPrefs.GetFloat("MasterValue");
        audioProperties.masterSlider.value = masterValue;
        

        float musicValue = PlayerPrefs.GetFloat("MusicValue");
        audioProperties.musicSlider.value = musicValue;
        

        float sfxValue = PlayerPrefs.GetFloat("SfxValue");
        audioProperties.sfxSlider.value = sfxValue;
        
    }
}