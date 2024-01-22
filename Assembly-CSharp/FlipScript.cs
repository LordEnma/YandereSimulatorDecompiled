using UnityEngine;

public class FlipScript : MonoBehaviour
{
	public GameObject[] Dress;

	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			if (Dress[0].activeInHierarchy)
			{
				Dress[0].SetActive(value: false);
				Dress[1].SetActive(value: true);
			}
			else
			{
				Dress[1].SetActive(value: false);
				Dress[0].SetActive(value: true);
			}
		}
	}
}
