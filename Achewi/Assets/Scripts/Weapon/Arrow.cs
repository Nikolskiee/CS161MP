using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] Camera cam;
    Rigidbody rb;
    BoxCollider bx;
    Target target;
    bool disableRotation;
    public float destroyTime = 10f;
    AudioSource arrowAudio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();
        target = GetComponent<Target>();
        arrowAudio = GetComponent<AudioSource>();

        Destroy(this.gameObject, destroyTime);
    }
    void Update()
    {
        if(!disableRotation)
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.tag != "Player"))
        {
            arrowAudio.Play();
            disableRotation = true;
            rb.isKinematic = true;
            bx.isTrigger = true;

            if(collision.gameObject.tag == "Target")
            {
                ScoreScript.scoreValue += 10;
                Target target = collision.gameObject.GetComponent<Target>();
                target.Hit();
                Destroy(this.gameObject);
            }
        }
    }
}
