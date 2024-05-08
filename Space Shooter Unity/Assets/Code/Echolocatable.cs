using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Echolocatable : MonoBehaviour
{
    public Transform darkForm;
    public Transform trueForm;

    public float secondsRevelead = 2f;

    bool canSwitchForms;

    private void Start()
    {
        trueForm.transform.localScale = Vector3.zero;
    }

    public void SwitchForms()
    {
        if (canSwitchForms)
        {
            StartCoroutine(SwitchFormsCo());
        }
    }

    IEnumerator SwitchFormsCo()
    {
        canSwitchForms = false;
        darkForm.transform.localScale = Vector3.zero;
        trueForm.transform.localScale = Vector3.one;
        yield return new WaitForSeconds(secondsRevelead);
        darkForm.transform.localScale = Vector3.one;
        trueForm.transform.localScale = Vector3.zero;
        canSwitchForms = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(SwitchFormsCo());
        }
    }
}
