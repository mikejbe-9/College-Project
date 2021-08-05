using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OptionsMenu : MonoBehaviour
{
    public Resolution[] resolutions;
    public TextMeshProUGUI resolutionLabel;
    public Toggle fullScreenTogg;
    public Toggle vSyncTogg;
    public int selectedResolution;
    void Start()
    {
        fullScreenTogg.isOn = Screen.fullScreen;
        if(QualitySettings.vSyncCount == 0)
        {
            vSyncTogg.isOn = false;
        }
        else
        {
            vSyncTogg.isOn = true;
        }
        bool foundRes = false;
        for(int i = 0; i < resolutions.Length; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedResolution = i;
                UpdateResolutionText();
            }
        }
        if (!foundRes)
        {
            resolutionLabel.text = Screen.width.ToString() + " X " + Screen.height.ToString();
        }
    }
    public void DecreaseResolution()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
    }
    public void IncreaseResolution()
    {
        selectedResolution++;
        if(selectedResolution > resolutions.Length - 1)
        {
            selectedResolution = resolutions.Length - 1;
        }
    }
    void UpdateResolutionText()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " X " + resolutions[selectedResolution].vertical.ToString();
    }
    public void ApplyGraphics()
    {
        if(vSyncTogg.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullScreenTogg.isOn);
    }
}

[System.Serializable]
public class Resolution
{
    public int horizontal;
    public int vertical;
}
