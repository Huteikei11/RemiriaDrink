using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public int ActiveCanvas = 0;
    public Canvas Onomimono;
    public Canvas Osewa;
    public Canvas Okigae;
    public Canvas Echi;
    // Start is called before the first frame update
    void Start()
    {
        InActiveCanvas();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InActiveCanvas()
    {
        ActiveCanvas = 0;
        Onomimono.enabled = false;
        Osewa.enabled = false;
        Okigae.enabled = false;
        Echi.enabled = false;
    }
    public void Onomimono_Active()
    {
        ActiveCanvas = 1;
        Onomimono.enabled = !Onomimono.enabled;
        Osewa.enabled = false;
        Okigae.enabled = false;
        Echi.enabled = false;
    }

    public void Osewa_Active()
    {
        ActiveCanvas = 2;
        Onomimono.enabled = false; ;
        Osewa.enabled = !Osewa.enabled;
        Okigae.enabled = false;
        Echi.enabled = false;
    }

    public void Okigae_Active()
    {
        ActiveCanvas = 3;
        Onomimono.enabled = false;
        Osewa.enabled = false;
        Okigae.enabled = !Okigae.enabled;
        Echi.enabled = false;
    }

    public void Ecchi_Active()
    {
        ActiveCanvas = 4;
        Onomimono.enabled = false;
        Osewa.enabled = false;
        Okigae.enabled = false;
        Echi.enabled = !Echi.enabled;
    }
}
