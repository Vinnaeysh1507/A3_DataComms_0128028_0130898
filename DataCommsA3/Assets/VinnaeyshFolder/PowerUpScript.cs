using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField] private int LiveTimer;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ChangePos());
    }

    public IEnumerator ChangePos()
    { 
        yield return new WaitForSeconds(LiveTimer);

        Destroy(this);
    }
}
