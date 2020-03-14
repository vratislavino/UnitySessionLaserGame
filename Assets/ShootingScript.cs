using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    AudioPlayer player;
    public AudioClip fireClip;
    public AudioClip boomClip;

    Camera cam;
    public float force = 500;
    public GameObject explosion;
    public Transform firePoint;
    public Transform hand;

    public Animator animator;

    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        lineRenderer = GetComponent<LineRenderer>();
        player = GetComponentInChildren<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Enchant");
            Invoke("StartEnchant", 0.6f);
        }

        if(Input.GetMouseButtonDown(0))
        {
            player.PlayMe(fireClip);
            Vector2 mys = Input.mousePosition;
            Ray paprsek = cam.ScreenPointToRay(mys);
            hand.localScale *= 1.1f;
            animator.SetTrigger("Fire");
            RaycastHit hit;
            if(Physics.Raycast(paprsek, out hit, 1000)) {

                lineRenderer.enabled = true;
                lineRenderer.SetPositions(new Vector3[] {
                    firePoint.position + Vector3.down*0.2f,
                    hit.point
                });
                Invoke("DisableLaser", 0.3f);

                //GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = hit.point;

                var cols = Physics.OverlapSphere(hit.point, 4f);
                foreach (var col in cols)
                {
                    Rigidbody rb = col.GetComponent<Rigidbody>();
                    if(rb != null)
                    {
                        rb.AddExplosionForce(force, hit.point, 4f);
                    }
                }
                player.PlayMe(boomClip);

                Transform t = Instantiate(explosion, hit.point, Quaternion.identity).transform;
                t.localScale *= 0.5f;
                Destroy(t.gameObject, 5);
            } else
            {
                lineRenderer.enabled = true;
                lineRenderer.SetPositions(new Vector3[] {
                    firePoint.position + Vector3.down*0.2f,
                    firePoint.position + paprsek.direction * 1000f
                });
                Invoke("DisableLaser", 0.3f);
            }
        }
    }
    void DisableLaser()
    {
        lineRenderer.enabled = false;
        hand.localScale = Vector3.one * 0.4306f;
    }

    void StartEnchant()
    {
        var kostky = GameObject.FindGameObjectsWithTag("Kostka").ToList();
        kostky.ForEach((k) =>
        {
            k.GetComponentInChildren<Rigidbody>().AddTorque(Vector3.up * 5000);
        });
    }
}
