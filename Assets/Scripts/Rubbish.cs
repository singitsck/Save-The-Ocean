using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : MonoBehaviour
{
    public int Value;//data
    private GamingUI GaUI;
    // Start is called before the first frame update
    void Start()
    {
        //find Canvas's gamingUI
        GaUI = GameObject.Find("Canvas").GetComponent<GamingUI>();
    }

    //fraction add
    private void OnDestroy()
    {
        GaUI.OnMoney(Value);
    }
}
