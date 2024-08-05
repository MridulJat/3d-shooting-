using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletp; 
    [SerializeField] private Transform shootingPoint; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            Shootings();
        }
    }

    void Shootings()
    {
        Debug.Log("Shootings");
        var gameObj = Instantiate(bulletp, shootingPoint.position, shootingPoint.rotation);
        var bullet = gameObj.GetComponent<Bullet>();
        bullet.Init(-shootingPoint.forward); 
    }
}