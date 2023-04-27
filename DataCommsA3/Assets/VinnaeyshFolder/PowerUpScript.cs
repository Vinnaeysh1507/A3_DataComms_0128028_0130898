using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField] private float LiveTimer;
    [SerializeField] private float LiveTimer2 = 5.0f;


    [SerializeField] private GameObject PowerUpPoint1;
    [SerializeField] private GameObject PowerUpPoint2;
    [SerializeField] private GameObject PowerUpPoint3;
    [SerializeField] private GameObject PowerUpPoint4;
    [SerializeField] private GameObject PowerUpPoint5;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = PowerUpPoint1.transform.position;
        StartCoroutine(ChangePos());
    }

    private void Update()
    {
        if (LiveTimer2 <= 0.0f)
        {
            LiveTimer2 = 5.0f;
            
        }
        else
        {
            LiveTimer2 -= Time.deltaTime;
        }
        
    }

    public IEnumerator ChangePos()
    { 
        yield return new WaitForSeconds(LiveTimer);

        transform.position = PowerUpPoint2.transform.position;

        yield return new WaitForSeconds(LiveTimer);

        transform.position = PowerUpPoint3.transform.position;

        yield return new WaitForSeconds(LiveTimer);

        transform.position = PowerUpPoint4.transform.position;

        yield return new WaitForSeconds(LiveTimer);

        transform.position = PowerUpPoint5.transform.position;

        yield return new WaitForSeconds(LiveTimer);

        transform.position = PowerUpPoint1.transform.position;


    }
}
