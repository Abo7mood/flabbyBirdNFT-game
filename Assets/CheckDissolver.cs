using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDissolver : MonoBehaviour
{

    [SerializeField] GameObject[] TubesGroup;

    private void Awake()
    {
        int rand = Random.Range(0, 6);
        TubesGroup[rand].SetActive(true);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
            return;
        else
        {
            Destroy(this.gameObject, 10f);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject, 10f);
        }
          
    }
}
