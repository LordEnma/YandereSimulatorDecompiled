using UnityEngine;

public class HomeYandereDetectorScript : MonoBehaviour
{
	public bool YandereDetected;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			YandereDetected = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			YandereDetected = false;
		}
	}
}
