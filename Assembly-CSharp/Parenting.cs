using UnityEngine;

public class Parenting : MonoBehaviour
{
	public Transform target;

	public bool copyRotation;

	public bool copyScale;

	private void Update()
	{
		if (target != null)
		{
			base.transform.position = target.position;
			if (copyRotation)
			{
				base.transform.rotation = target.rotation;
			}
			if (copyScale)
			{
				base.transform.localScale = target.localScale;
			}
		}
	}
}
