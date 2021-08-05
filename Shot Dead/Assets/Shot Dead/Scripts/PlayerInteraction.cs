using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public KillCounter killCounter;
    public bool hasResqued;

    [SerializeField] float rayDist = 5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rayDist))
            {
                if (hit.collider.CompareTag("NPC") )
                {
                    Npc npc = hit.transform.GetComponent<Npc>();
                    if(npc != null)
                    {
                        if (npc.inRange)
                        {
                            if (!npc.resqued)
                            {
                                npc.resqued = true;
                                killCounter.livesRescued++;
                            }
                        }
                    }
                }
                if (hit.collider.CompareTag("Door"))
                {
                    hit.transform.GetComponent<Door>().ChangeState();
                }
                if (hit.collider.CompareTag("Ammo"))
                {
                    hit.transform.GetComponent<Ammo>().PickUpAmmo();
                }
                if (hit.collider.CompareTag("Aid"))
                {
                    hit.transform.GetComponent<Aid>().RegenerateHealth();
                }
            }
        }
    }
}
