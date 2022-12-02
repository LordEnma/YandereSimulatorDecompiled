using UnityEngine;

public class PuddleDetectorScript : MonoBehaviour
{
	public PowerSwitchScript PowerSwitch;

	public int Frame;

	private void Update()
	{
		if (Frame > 0)
		{
			Object.Destroy(base.gameObject);
		}
		Frame++;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Puddle" && other.gameObject.GetComponent<BloodPoolScript>().Water)
		{
			PowerSwitch.NewPuddle = other.gameObject;
			PowerSwitch.Electricity.transform.position = PowerSwitch.NewPuddle.transform.position;
			PowerSwitch.Electricity.SetActive(true);
		}
	}
}
