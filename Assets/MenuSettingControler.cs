using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSettingControler : MonoBehaviour
{
    //
    public GameObject InfomationPannel;
    public UnityEngine.UI.Slider SoundSlider;
    public UnityEngine.UI.Text SoundValue;
    // Start is called before the first frame update
    void Start()
    {
        SliderSoundChange();
    }
    // Update is called once per frame
    void Update()
    {
        SliderSoundChange();
        SoundValueUpdate();
    }
    public void InfomationButtonClick() {
        InfomationPannel.gameObject.active = !InfomationPannel.gameObject.active;
    }
    public void ReloadButtonClick() {
        SceneManager.LoadScene("MainScene");
    }
    public void HomeButtonClick(){
        Application.Quit();
    }
    public void SettingButtonClick() {
        SoundSlider.gameObject.active = !SoundSlider.gameObject.active;
    }
    public void SliderSoundChange()
    {
        AudioListener.volume = SoundSlider.value;
    }
    public void SoundValueUpdate() {
        SoundValue.text = " " + (int)(SoundSlider.value * 100);
    }
}
