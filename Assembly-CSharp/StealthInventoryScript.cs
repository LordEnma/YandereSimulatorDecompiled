using UnityEngine;

public class StealthInventoryScript : MonoBehaviour
{
	public bool GateKey;

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			GateKey = true;
		}
	}
}
