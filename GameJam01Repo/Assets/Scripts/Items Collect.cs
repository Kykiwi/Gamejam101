using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemsCollect : MonoBehaviour
{
    int collNum = 0;
    [SerializeField] TMP_Text collectText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectables"))
        {
            Destroy(collision.gameObject);
            collNum++;
            collectText.text = " x " + collNum;
        }
    }
}

