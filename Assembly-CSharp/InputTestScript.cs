using UnityEngine;

public class InputTestScript : MonoBehaviour
{
	public GameObject Bullet;

	public Transform Origin;

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			Object.Instantiate(Bullet, Origin.position, Quaternion.identity);
		}
	}
}
