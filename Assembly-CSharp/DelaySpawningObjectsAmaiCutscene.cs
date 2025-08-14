using System.Collections;
using UnityEngine;

public class DelaySpawningObjectsAmaiCutscene : MonoBehaviour
{
	public GameObject DelayObjects;

	public float delay = 0.5f;

	private void Start()
	{
		DelayObjects.SetActive(value: false);
		StartCoroutine(AtivarObjetoDepoisDoTempo());
	}

	private IEnumerator AtivarObjetoDepoisDoTempo()
	{
		yield return new WaitForSeconds(delay);
		DelayObjects.SetActive(value: true);
	}
}
