using System.Collections;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] GameObject[] projectile;
    [SerializeField] Transform spawnNoktasi;

    int projectileIndex;

    void Start()
    {
        StartCoroutine(Atesle());
    }

    IEnumerator Atesle()
    {
        while(true)
        {
            if(projectileIndex != projectile.Length - 1)
            {
                projectile[projectileIndex].transform.position = spawnNoktasi.position;
                projectile[projectileIndex].SetActive(true);
                projectileIndex++;
            }
            else
            {
                projectileIndex = 0;
            }

            yield return new WaitForSeconds(.1f);

        }
    }
}
