using UnityEngine;

public class PhoneReticleScript : MonoBehaviour
{
	public int CurrentNumber;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<PhoneNumberScript>() != null)
		{
			other.gameObject.GetComponent<PhoneNumberScript>().MyRenderer.enabled = true;
			CurrentNumber = other.gameObject.GetComponent<PhoneNumberScript>().Number;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.GetComponent<PhoneNumberScript>() != null)
		{
			other.gameObject.GetComponent<PhoneNumberScript>().MyRenderer.enabled = false;
			CurrentNumber = 10;
		}
	}
}
