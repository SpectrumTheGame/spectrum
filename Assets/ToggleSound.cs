using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour {

    public Button soundButton;
    private bool on;

    private Sprite vOn;
    private Sprite vOff;

	// Use this for initialization
	void Start () {
        Button btn = soundButton.GetComponent<Button>();
        btn.onClick.AddListener(Toggle);
        on = true;
        PlayerPrefs.SetInt("sound", 1);

        vOn = Resources.Load<Sprite>("volume on") as Sprite;
        vOff = Resources.Load<Sprite>("volume off") as Sprite;
    }

    void Toggle()
    {
        Image img = soundButton.GetComponent<Image>();

        if (on)
        {            
            on = false;
            PlayerPrefs.SetInt("sound", 0);
            img.sprite = vOff;

        } else
        {
            // swtich image
            on = true;
            PlayerPrefs.SetInt("sound", 1);
            img.sprite = vOn;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
