using UnityEngine;

public class Projectile : MonoBehaviour
{

    void Update()
    {
        transform.Translate(Time.deltaTime * 10f * Vector3.forward);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Duvar"))
            gameObject.SetActive(false);
    }
}
