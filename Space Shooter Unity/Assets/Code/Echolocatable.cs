using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Echolocatable : MonoBehaviour
{
    public Transform darkForm;
    public Transform trueForm;

    public float secondsRevelead = 2f;

    bool canSwitchForms = true;

    AudioSource revealedSound;

    public RandomMovement randomMovement;

    private void Start()
    {
        trueForm.transform.localScale = Vector3.zero;
        revealedSound = GetComponent<AudioSource>();
    }

    public void TrySwitchForms()
    {
        if (canSwitchForms)
        {
            revealedSound.Play();
            StartCoroutine(SwitchFormsCo());
        }
    }

    IEnumerator SwitchFormsCo()
    {
        canSwitchForms = false;
        darkForm.transform.localScale = Vector3.zero;
        trueForm.transform.localScale = Vector3.one;
        if (randomMovement != null)
        {
            randomMovement.enabled = true;
        }
        yield return new WaitForSeconds(secondsRevelead);
        darkForm.transform.localScale = Vector3.one;
        trueForm.transform.localScale = Vector3.zero;
        canSwitchForms = true;

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            TrySwitchForms();
        }
    }
}
