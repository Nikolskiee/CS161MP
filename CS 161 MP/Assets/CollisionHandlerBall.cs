using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollisionHandlerBall : MonoBehaviour
{
    public Vector3 defaultLocation;

    public List<GameObject> floors;
    public List<GameObject> active_floors;

    private void OnTriggerEnter(Collider collision) {
        Debug.Log(collision.transform.tag);

        if(collision.transform.tag == "floor") {
            int index = Random.Range(0, floors.Count);
            int altitude = Random.Range(-3,3);
            GameObject floor = Instantiate(floors[index], collision.transform.position + new Vector3(0f, 0f + altitude, 60f), Quaternion.identity);
            active_floors.Add(floor);

            if(active_floors.Count > 10) {
                GameObject.Destroy(active_floors[0]);
                active_floors.RemoveAt(0);
            }
        }
        else {
            transform.position = defaultLocation;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
