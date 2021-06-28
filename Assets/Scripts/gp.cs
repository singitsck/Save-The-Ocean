using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gp : MonoBehaviour
{
    public Transform go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = go.position;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, go.eulerAngles.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.parent = transform;

        go.parent.GetComponent<play>().Mystate = play.State.Takeback;
    }
}
