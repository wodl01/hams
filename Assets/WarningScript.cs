using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningScript : MonoBehaviour
{
    [SerializeField] int appearingTime;
    [SerializeField] Text text;
    public string InputWord;

    private void Start()
    {
        text.text = InputWord;
        StartCoroutine(appear());
    }
    IEnumerator appear()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
