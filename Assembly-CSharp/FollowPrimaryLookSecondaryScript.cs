using UnityEngine;

public class FollowPrimaryLookSecondaryScript : MonoBehaviour
{
	public Transform FollowTarget;

	public Transform LookTarget;

	private void Update()
	{
		base.transform.position = FollowTarget.position;
		base.transform.rotation = FollowTarget.rotation;
	}
}
