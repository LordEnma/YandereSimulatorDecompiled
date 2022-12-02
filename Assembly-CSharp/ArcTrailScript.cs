using UnityEngine;

public class ArcTrailScript : MonoBehaviour
{
	private static readonly Color TRAIL_TINT_COLOR = new Color(1f, 0f, 0f, 1f);

	public TrailRenderer Trail;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			Trail.material.SetColor("_TintColor", TRAIL_TINT_COLOR);
		}
	}
}
