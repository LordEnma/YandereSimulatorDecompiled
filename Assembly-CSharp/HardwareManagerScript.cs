using UnityEngine;

public class HardwareManagerScript : MonoBehaviour
{
	public YandereScript Yandere;

	public WeaponScript[] Hardware;

	public GameObject Carrots;

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
			Debug.Log("PlayerGlobals.BringingHardware is: " + PlayerGlobals.BringingHardware);
			Yandere.transform.position = new Vector3(9f, 0f, -95f);
			Hardware[PlayerGlobals.BringingHardware].gameObject.SetActive(value: true);
			base.gameObject.SetActive(value: true);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		if (PlayerGlobals.BroughtCarrotsToSchool || PlayerGlobals.BringingItem == 12)
		{
			Debug.Log("PlayerGlobals.BroughtCarrotsToSchool is: " + PlayerGlobals.BroughtCarrotsToSchool);
			Debug.Log("PlayerGlobals.BringingItem is: " + PlayerGlobals.BringingItem);
			Yandere.transform.position = new Vector3(9f, 0f, -95f);
			base.gameObject.SetActive(value: true);
			if (PlayerGlobals.BroughtCarrotsToSchool)
			{
				Carrots.SetActive(value: true);
			}
		}
	}
}
