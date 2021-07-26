using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public CharacterManager characterManager;
    public UIManager uiManager;
    public int selectedGun = 0;

    private AudioSource holsterSound;

    void Awake()
    {
        //SelectGun();
    }

    void Start()
    {
        holsterSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        int alreadySelectedGun = selectedGun;

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedGun >= transform.childCount - 1)
            {
                selectedGun = 0;
            }
            else
            {
                selectedGun++;
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedGun <= 0)
            {
                selectedGun = transform.childCount - 1;
            }
            else
            {
                selectedGun--;
            }
        }

        if(alreadySelectedGun != selectedGun)
        {
            SelectGun();
        }
    }

    public void SelectGun()
    {
        int i = 0;
        //holsterSound.Play();

        foreach(Transform gun in transform)
        {
            if (i == selectedGun)
            {
                characterManager._currentGun = gun.GetComponent<Gun1>();
                gun.gameObject.SetActive(true);
                uiManager.GetActiveGun(gun.gameObject);
            }
            else
            {
                //gun.GetComponent<Animator>().SetTrigger("Reset");
                //Debug.Log("RESETTED");
                gun.GetComponent<Gun1>().canShoot = false;
                gun.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
