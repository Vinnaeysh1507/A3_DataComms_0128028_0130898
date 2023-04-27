using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class SyncVarDemo : NetworkBehaviour
{
    //[SyncVar]
    [SyncVar(hook = nameof(SetColor))]
    private Color32 _color = Color.red;

    public override void OnStartServer()
    {
        base.OnStartServer();
        StartCoroutine(_RandomColor());
    }

    private void SetColor(Color32 oldColor, Color32 newColor)
    { 
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = newColor;
    }

    private IEnumerator _RandomColor() 
    {
        WaitForSeconds wait  = new WaitForSeconds(2f);

        while (true) 
        {
            yield return wait;

            _color = Random.ColorHSV(0f,1f,1f,1f,0f,1f,1f,1f);
        }
    }
}
