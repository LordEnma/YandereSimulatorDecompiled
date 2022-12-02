using UnityEngine;

public class SplashSpawnerScript : MonoBehaviour
{
	public GameObject BloodSplash;

	public Transform Yandere;

	public bool Bloody;

	public bool FootUp;

	public float DownThreshold;

	public float UpThreshold;

	public float Height;

	private void Update()
	{
		if (!FootUp)
		{
			if (base.transform.position.y > Yandere.transform.position.y + UpThreshold)
			{
				FootUp = true;
			}
		}
		else if (base.transform.position.y < Yandere.transform.position.y + DownThreshold)
		{
			FootUp = false;
			if (Bloody)
			{
				GameObject gameObject = Object.Instantiate(BloodSplash, new Vector3(base.transform.position.x, Yandere.position.y, base.transform.position.z), Quaternion.identity);
				gameObject.transform.eulerAngles = new Vector3(-90f, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
				Bloody = false;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			Bloody = true;
		}
	}
}
