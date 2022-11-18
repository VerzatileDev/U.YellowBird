using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer theMixer;

    [SerializeField] private Slider masterSlider = null;
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private Slider sfxSlider = null;

    [SerializeField] private TMP_Text masterLabel = null;
    [SerializeField] private TMP_Text musicLabel = null;
    [SerializeField] private TMP_Text sfxLabel = null;


    public void Start()
    {
        if(PlayerPrefs.GetFloat("VolumeSet") == 1)
        {
            LoadValues();
        }
        else
        {
            LoadInitialValues();
        }
        //LoadValues();
        //PlayerPrefs.SetFloat("MasterVol", 0.5f);
        //PlayerPrefs.SetFloat("MusicVol", 0.5f);
        //PlayerPrefs.SetFloat("SFXVol", 0.5f);
        
    }
    public void SetMasterVol()
    {
        masterLabel.text = Mathf.RoundToInt(masterSlider.value *100).ToString(); // Visual Update to player " Text
        theMixer.SetFloat("MasterValue", Mathf.Log10(masterSlider.value) *20); // Update Slider Values in the Mixer
        //PlayerPrefs.SetFloat("MasterVol", masterSlider.value); 
    }
    public void SetMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value *100).ToString(); // Visual Update to Player " Text
        theMixer.SetFloat("MusicValue", Mathf.Log10(musicSlider.value) *20); // Update Slider Values
        //PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
    public void SetSFXVol()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value *100).ToString(); // Visual Update to Player " Text
        theMixer.SetFloat("SfxValue", Mathf.Log10(sfxSlider.value) *20); // Update Slider Values
        //PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
    public void SaveVolumeButton()
    {
        float masterValue = masterSlider.value;
        PlayerPrefs.SetFloat("MasterValue", masterValue);

        float musicValue = musicSlider.value;
        PlayerPrefs.SetFloat("MusicValue", musicValue);

        float sfxValue = sfxSlider.value;
        PlayerPrefs.SetFloat("SfxValue", sfxValue);

        PlayerPrefs.SetFloat("VolumeSet", 1);

        //LoadValues();
    }

    void LoadInitialValues()
    {
        float masterValue = 1.0f; // gets the Float value for Master
        masterSlider.value = masterValue;  // Sets MasterSlider Values to the Information gained to masterValue
        AudioListener.volume = masterValue; // Sets AudioListener Volume 

        float musicValue = 0.5f;
        musicSlider.value = musicValue;
        AudioListener.volume = musicValue;

        float sfxValue = 0.5f;
        sfxSlider.value = sfxValue;
        AudioListener.volume = sfxValue;
    }

    void LoadValues()
    {
        float masterValue = PlayerPrefs.GetFloat("MasterValue"); // gets the Float value for Master
        masterSlider.value = masterValue;  // Sets MasterSlider Values to the Information gained to masterValue
        AudioListener.volume = masterValue; // Sets AudioListener Volume 

        float musicValue = PlayerPrefs.GetFloat("MusicValue");
        musicSlider.value = musicValue;
        AudioListener.volume = musicValue;

        float sfxValue = PlayerPrefs.GetFloat("SfxValue");
        sfxSlider.value =sfxValue;
        AudioListener.volume = sfxValue;
    }
}