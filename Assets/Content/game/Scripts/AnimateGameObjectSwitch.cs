using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.InteractiveTutorials;

public class AnimateGameObjectSwitch : MonoBehaviour
{
    public GameObject gameObjectToAnimate;
    public float delayInSeconds;
	public GameObject key;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<IPlayerAvatar>() != null)
        {
            StopAllCoroutines();
            StartCoroutine(Animate());
			DeleteKey();
        }
    }

    private IEnumerator Animate()
    {
        yield return new WaitForSeconds(delayInSeconds);

        gameObjectToAnimate.GetComponent<Animator>().SetBool("SwitchTriggered", true);
    }

	private void DeleteKey(){
		Destroy (key);
	}
}
