using UnityEngine;

public class FollowYandereScript : MonoBehaviour
{
	public Transform Yandere;

	private void Update()
	{
		base.transform.position = new Vector3(Yandere.position.x, base.transform.position.y, Yandere.position.z);
	}
}
