using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpscam;
    public ParticleSystem GunFlash;
    public GameObject HitEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        GunFlash.Play();
        RaycastHit hit;

        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
               {
            Debug.Log("POPO" + hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }
            if(hit.rigidbody !=null)
            {
                hit.rigidbody.AddForce(-hit.normal * 250f);
            }
            GameObject EffectGo = Instantiate(HitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(EffectGo, 1f);
        }
        
    }
}
