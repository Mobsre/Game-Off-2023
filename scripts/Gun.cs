using UnityEngine;

public class gun : MonoBehaviour
{
    [SerializeField] private movement iHave;
    public float damage = 10f;
    public Camera fpsCam;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

    }

    void Attack()
    {
        if(iHave.namen == true)
        {
            Shoot();
        }
    }
    void Shoot ()
    {
        muzzleFlash.Play();
        FindObjectOfType<AudioManager>().Play("shooting");
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);
            target trget = hit.transform.GetComponent<target>();
            if(trget != null)
            {
                trget.TakeDamage(damage);
            }
            Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

        }
    }
}
