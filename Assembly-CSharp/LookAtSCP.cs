using UnityEngine;

public class LookAtSCP : MonoBehaviour
{
	public Transform SCP;

	private void Start()
	{
		if (SCP == null)
		{
			SCP = GameObject.Find("SCPTarget").transform;
		}
		base.transform.LookAt(SCP);
	}

	private void LateUpdate()
	{
		base.transform.LookAt(SCP);
	}
}
