using UnityEngine;

public class BushSpawnerScript : MonoBehaviour
{
	public GameObject Bush;

	public bool Begin;

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			Begin = true;
		}
		if (Begin)
		{
			Object.Instantiate(Bush, new Vector3(Random.Range(-16f, 16f), Random.Range(0f, 4f), Random.Range(-16f, 16f)), Quaternion.identity);
		}
	}
}
