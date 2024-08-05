using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;

    [SerializeField] private float _lifetime = 4f;

    private Vector3 dir;
    
    void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    public void Init(Vector3 dir)
    {
        this.dir = dir;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * _speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject); 
        }
}