using UnityEngine;

public class GasLeakScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject GasExplosion;

	private void Update()
	{
		if (Yandere.PickUp != null && Yandere.PickUp.OpenFlame && Vector3.Distance(Yandere.transform.position, base.transform.position) < 2f)
		{
			GasExplosion.SetActive(value: true);
			base.enabled = false;
		}
	}
}
