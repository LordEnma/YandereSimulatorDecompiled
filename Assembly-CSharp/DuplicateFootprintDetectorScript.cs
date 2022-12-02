using UnityEngine;

public class DuplicateFootprintDetectorScript : MonoBehaviour
{
	public FootprintScript Footprint;

	public bool Right;

	public int Frame;

	private void Update()
	{
		Frame++;
		if (Frame > 1)
		{
			base.enabled = false;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (base.enabled && other.gameObject.layer == 14)
		{
			if (Right)
			{
				Footprint.Yandere.RightFootprintSpawner.Bloodiness++;
			}
			else
			{
				Footprint.Yandere.LeftFootprintSpawner.Bloodiness++;
			}
			Object.Destroy(base.gameObject);
		}
	}
}
