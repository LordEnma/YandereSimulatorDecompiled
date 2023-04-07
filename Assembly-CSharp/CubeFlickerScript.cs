using UnityEngine;

public class CubeFlickerScript : MonoBehaviour
{
	public Transform[] Cube;

	private void Update()
	{
		Transform[] cube = Cube;
		foreach (Transform obj in cube)
		{
			obj.localScale = new Vector3(Random.Range(0f, 0.1f), Random.Range(0f, 0.1f), Random.Range(0f, 0.1f));
			obj.position = base.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(0f, 2f), Random.Range(-1f, 1f));
		}
	}
}
