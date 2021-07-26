using UnityEngine;

public class GunAnimController : MonoBehaviour
{
    [SerializeField] Gun1 gun = null;
    [SerializeField] AudioSource sliderSound = null;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        InputManager();
    }

    void InputManager()
    {
        anim.speed = 1;
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    anim.SetTrigger("Reload");
        //}


       
    }

    public void SliderSound()
    {
        if (sliderSound != null)
        {
            sliderSound.Play();
        }
    }
}
