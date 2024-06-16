using UnityEngine;

public class FixHeightScript : MonoBehaviour
{
	public LayerMask groundLayer;

	public float Timer;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (!(Timer > 10f))
		{
			return;
		}
		foreach (Transform item in base.transform)
		{
			AdjustHeight(item.GetChild(0));
		}
		Timer = 0f;
	}

	private void AdjustHeight(Transform child)
	{
		if (Physics.Raycast(child.position + Vector3.up, Vector3.down, out var hitInfo, float.PositiveInfinity, groundLayer) && hitInfo.collider.gameObject.layer == 8)
		{
			child.position = new Vector3(child.position.x, hitInfo.point.y, child.position.z);
		}
	}
}
