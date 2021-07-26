using UnityEngine;

public class Gun1 : MonoBehaviour
{
    //public PlayerMovement1 playerMovement;
    private Camera cam;
    public Transform turret;
    public Transform bulletCaseSpawner;
    //private CameraScript camScript;
    public ParticleSystem shootingFlash;
    public GameObject bulletCaseFX;
    public GameObject bloodFX;
    public GameObject[] impactFXs;
    public TrailRenderer tracerEffect;

    [Header("Sounds")]
    public AudioSource shootingSound;
    public AudioSource reloadSound;

    [Header("Gun Settings")]
    public Sprite icon;
    public float walkingSpreadFactor;
    public float normalSpreadFactor;
    public float range = 100000f;
    public float fireRate;
    public bool isReloading;
    public bool canShoot;
    private float spreadFactor;

    [Header("Bullet Numbers")]
    public int totalBullets = 120;
    public int maxMagazineSize = 30;
    public int bulletCountAtStart;
    public int magazineSize;

    [Header("Damage Settings")]
    [SerializeField] float headDamage = 400f;
    [SerializeField] float torsoDamage = 20f;
    [SerializeField] float armsDamage = 10f;
    [SerializeField] float legsDamage = 5f;
    [SerializeField] float deathForce = 10f;
    [HideInInspector] public float avgDamage;

    [Header("Recoil Settings")]
    private float upRecoil;
    private float sideRecoil;
    [SerializeField] Vector2[] recoilPattern;

    private GameSceneManager _gameSceneManager = null;
    private int _aiBodyPartLayer = -1;
    private Animator anim;
    private float time;
    private int index;

    void Start()
    {
        cam = Camera.main;
        //camScript = cam.GetComponent<CameraScript>();
        anim = GetComponent<Animator>();

        bulletCountAtStart = totalBullets;
        magazineSize = maxMagazineSize;
    }

    void Update()
    {
        //anim.speed = 1;
        time += Time.deltaTime;

        //if (magazineSize > 0)
        //{
        //    if (gameObject.tag == "Pistol")
        //    {
        //        if (Input.GetButtonDown("Fire1") && canShoot)
        //        {
        //            Shoot();
        //            shootingSound.Play();
        //            //magazineSize--;
        //        }
        //    }
        //    else
        //    {
        //        if (Input.GetButton("Fire1") && time >= fireRate && canShoot)
        //        {
        //            Shoot();
        //            shootingSound.Play();

        //            //magazineSize--;
        //            //time = 0f;
        //        }
        //        else if (Input.GetButtonUp("Fire1"))
        //        {
        //            index = 0;
        //        }
        //    }
        //}
        //else
        //{
        //    index = 0;
        //}

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    anim.SetTrigger("Inspect");
        //}
    }

    int GetNextIndex(int i)
    {
        return (i + 1) % recoilPattern.Length;
    }

    void GenerateRecoil()
    {
        sideRecoil = recoilPattern[index].x;
        upRecoil = recoilPattern[index].y;

        index = GetNextIndex(index);
    }

    //void DoDamage(int hitDir = 0)
    //{
    //    Ray ray;
    //    RaycastHit hit;
    //    bool isSomethingHit = false;

    //    ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

    //    isSomethingHit = Physics.Raycast(ray, out hit, 1000.0f, 1 << _aiBodyPartLayer);

    //    if (isSomethingHit)
    //    {
    //        AIStateMachine stateMachine = _gameSceneManager.GetAIStateMachine(hit.rigidbody.GetInstanceID());
    //        if (stateMachine)
    //        {
    //            stateMachine.TakeDamage(hit.point, ray.direction * 1.0f, 50, hit.rigidbody, this, 0);
    //        }
    //    }
    //}

    public void Shoot()
    {
        //if (magazineSize > 0)
        //{
        //    if (time >= fireRate && canShoot)
        //    {
                anim.SetBool("Aim", true);
                shootingSound.Play();
                anim.Play("Fire", -1, 0);
                shootingFlash.Play();

                Vector3 dir = cam.transform.forward;
                //spreadFactor = playerMovement.isSprinting ? walkingSpreadFactor : normalSpreadFactor;
                dir.x += Random.Range(-spreadFactor, spreadFactor);
                dir.y += Random.Range(-spreadFactor, spreadFactor);
                dir.z += Random.Range(-spreadFactor, spreadFactor);

                var tracer = Instantiate(tracerEffect, turret.position, Quaternion.identity);
                tracer.AddPosition(turret.position);
                magazineSize--;
                time = 0;
                //RaycastHit hit;
                //if(Physics.Raycast(cam.transform.position,dir, out hit, range))
                //{
                //    Debug.Log("HIT");
                //    var tracer = Instantiate(tracerEffect, turret.position, Quaternion.identity);
                //    tracer.AddPosition(turret.position);

                //    //Instantiate(bulletCaseFX, bulletCaseSpawner.position, Quaternion.identity, bulletCaseSpawner);

                //    TakeDamage takeDamage = hit.collider.GetComponent<TakeDamage>();
                //    if (takeDamage != null)
                //    {
                //        //if (hit.collider.GetType() == typeof(CapsuleCollider))
                //        Instantiate(bloodFX, hit.point, Quaternion.LookRotation(hit.normal));
                //        //hit.transform.root.GetComponent<Animator>().SetTrigger("Damage");
                //        switch (takeDamage.damageType)
                //        {
                //            case TakeDamage.CollisionType.head:
                //                takeDamage.Hit(headDamage);
                //                break;
                //            case TakeDamage.CollisionType.arms:
                //                takeDamage.Hit(armsDamage);
                //                break;
                //            case TakeDamage.CollisionType.torso:
                //                takeDamage.Hit(torsoDamage);
                //                break;
                //            case TakeDamage.CollisionType.legs:
                //                takeDamage.Hit(legsDamage);
                //                break;
                //        }

                //        if (hit.transform.GetComponent<Rigidbody>() != null)
                //        {
                //            hit.transform.GetComponent<Rigidbody>().AddForce(-hit.normal * deathForce, ForceMode.Impulse);
                //            Debug.Log("Force applied");
                //        }
                //    }
                //    else
                //    {
                //       foreach (GameObject impactFX in impactFXs)
                //       {
                //           Instantiate(impactFX, hit.point, Quaternion.LookRotation(hit.normal));
                //       }
                //    }
                //tracer.transform.position = hit.point;
        //    }
        //}
    }

    void Reload()
    {
        if (totalBullets <= 0 || magazineSize == maxMagazineSize)
        {
            return;
        }
        canShoot = false;
        anim.SetTrigger("Reload");
        reloadSound.Play();
        magazineSize = maxMagazineSize;
        totalBullets -= magazineSize;
    }

    public void CalculateAvgDamage()
    {
        avgDamage = (headDamage + torsoDamage + armsDamage + legsDamage) / 4;
    }
    public void CanShoot()
    {
        canShoot = true;
    }
}
//GenerateRecoil();
//camScript.AddRecoil(sideRecoil, upRecoil, recoilPattern);






//}
