using UnityEngine;

public class CheckmarkScript : MonoBehaviour
{
	public GameObject[] Checkmarks;

	public int ButtonPresses;

	public int ID;

	private void Start()
	{
		while (ID < Checkmarks.Length)
		{
			Checkmarks[ID].SetActive(value: false);
			ID++;
		}
		ID = 0;
	}

	private void Update()
	{
		if (Input.GetKeyDown("space") && ButtonPresses < 26)
		{
			ButtonPresses++;
			ID = Random.Range(0, Checkmarks.Length - 4);
			while (Checkmarks[ID].active)
			{
				ID = Random.Range(0, Checkmarks.Length - 4);
			}
			Checkmarks[ID].SetActive(value: true);
		}
	}
}
