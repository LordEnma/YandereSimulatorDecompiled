using UnityEngine;

public class MopHeadScript : MonoBehaviour
{
	public BloodPoolScript BloodPool;

	public MopScript Mop;

	private void OnTriggerStay(Collider other)
	{
		if (!(Mop.Bloodiness < 100f) || !(other.tag == "Puddle"))
		{
			return;
		}
		BloodPool = other.gameObject.GetComponent<BloodPoolScript>();
		if (BloodPool != null)
		{
			BloodPool.Grow = false;
			other.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
			if (BloodPool.Blood)
			{
				Mop.Bloodiness += Time.deltaTime * 10f;
				Mop.UpdateBlood();
			}
			Mop.StudentBloodID = BloodPool.StudentBloodID;
			if (other.transform.localScale.x < 0.1f)
			{
				Object.Destroy(other.gameObject);
			}
		}
		else
		{
			FootprintScript component = other.transform.GetChild(0).GetComponent<FootprintScript>();
			if (component != null)
			{
				Mop.StudentBloodID = component.StudentBloodID;
			}
			Object.Destroy(other.gameObject);
		}
	}
}
