using UnityEngine;

public class LoadAudio : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);// Stop destroying when next scene.
        if (PlayerPrefs.GetInt("VolumeSet") == 1)
        {
            LoadValues();
        }
        else
        {
            LoadInitialValues();
        }
    }

    public void LoadInitialValues()
    {
        float masterValue = 1.0f; // gets the Float value for Master
        AudioListener.volume = masterValue; // Sets AudioListener Volume 

        float musicValue = 0.5f;
        AudioListener.volume = musicValue;

        float sfxValue = 0.5f;
        AudioListener.volume = sfxValue;
        PlayerPrefs.SetInt("VolumeSet", 0);
    }

    public void LoadValues()
    {
        float masterValue = PlayerPrefs.GetFloat("MasterValue"); // gets the Float value for Master
        //masterSlider.value = masterValue;  // Sets MasterSlider Values to the Information gained to masterValue
        AudioListener.volume = masterValue; // Sets AudioListener Volume 

        float musicValue = PlayerPrefs.GetFloat("MusicValue");
        //musicSlider.value = musicValue;
        AudioListener.volume = musicValue;

        float sfxValue = PlayerPrefs.GetFloat("SfxValue");
        //sfxSlider.value = sfxValue;
        AudioListener.volume = sfxValue;
    }


}
