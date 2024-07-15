using UnityEngine;

public class PedestrianManagerScript : MonoBehaviour
{
	public GameObject[] PedestrianPrefabs;

	public GameObject[] Pedestrians;

	public int ID;

	private void Start()
	{
		while (ID < 100)
		{
			GameObject gameObject = Object.Instantiate(PedestrianPrefabs[Random.Range(0, PedestrianPrefabs.Length)], base.transform.position + new Vector3(Random.Range(-60f, 18f), 0f, Random.Range(0f, 4f)), Quaternion.identity);
			if (Random.Range(0, 2) == 0)
			{
				gameObject.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
			}
			else
			{
				gameObject.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
			}
			Pedestrians[ID] = gameObject;
			ID++;
		}
	}

	public void MovePedestrians()
	{
		Debug.Log("Moving all the pedestrians so they can't possibly clip into the camera.");
		for (ID = 0; ID < 100; ID++)
		{
			Pedestrians[ID].SetActive(value: false);
		}
	}
}
