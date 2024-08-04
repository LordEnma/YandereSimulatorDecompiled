using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
	public Transform Player;

	private void Update()
	{
		base.transform.position = Player.position;
	}
}
