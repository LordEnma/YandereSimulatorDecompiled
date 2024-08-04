using UnityEngine;

public class HardwareManagerScript : MonoBehaviour
{
	public YandereScript Yandere;

	public WeaponScript[] Hardware;

	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			if (Hardware[i] != null)
			{
				Hardware[i].gameObject.SetActive(value: false);
			}
		}
		if (PlayerGlobals.BringingHardware == 1 || PlayerGlobals.BringingItem == 3)
		{
			Hardware[1].gameObject.SetActive(value: true);
			base.gameObject.SetActive(value: false);
		}
		if (PlayerGlobals.BringingHardware > 1)
		{
			Yandere.transform.position = new Vector3(9f, 0f, -95f);
			Hardware[PlayerGlobals.BringingHardware].gameObject.SetActive(value: true);
			base.gameObject.SetActive(value: true);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
