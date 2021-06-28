using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public enum State
    {
        swing,
        Extension,
        Takeback

    }

    public State Mystate;

    private float Speed = 60f;
    private Vector3 v3;

    private float Length=1;
    private float LSpeed=2.0f;

    public Transform go;

    public GameObject gp;

    void Start()
    {
        v3 = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mystate == State.swing)
        {
            OnSwing();
            if(Input.GetMouseButtonDown(0))
            {
                Mystate = State.Extension;
                source.PlayOneShot(clip);//play audio
            }

        }
        else if(Mystate == State.Extension)
        {
            OnExtension();
        }
        else
        {
            OnTakeback();
        }
    }

    private void OnSwing()
    {
        transform.Rotate(v3 * Speed * Time.deltaTime);

        if(transform.localRotation.z>0.4f)
        {
            v3 = Vector3.back;
        }else if(transform.localRotation.z < -0.4f)
        {
            v3 = Vector3.forward;
        }
    }
    private void OnExtension()
    {
        Length += Time.deltaTime * LSpeed;
        transform.localScale = new Vector3(transform.localScale.x, Length, transform.localScale.z);

        if (Length>5.5)
        {
            Mystate=State.Takeback;
        }
    }


    private void OnTakeback()
    {
        Length -= Time.deltaTime * LSpeed;
        transform.localScale = new Vector3(transform.localScale.x, Length, transform.localScale.z);
        if(Length <= 1)
        {
            
            Mystate = State.swing;

            if (gp.transform.childCount >= 1)
            {
                Destroy(gp.transform.GetChild(0).gameObject);
            }
        }
    }
}
