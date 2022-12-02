using UnityEngine;

public class FallingOsanaScript : MonoBehaviour
{
	public StudentScript Osana;

	public GameObject GroundImpact;

	private void Update()
	{
		if (base.transform.position.y > 0f)
		{
			base.transform.position += new Vector3(0f, -1.0001f, 0f);
		}
		if (base.transform.position.y < 0f)
		{
			base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
			Object.Instantiate(GroundImpact, base.transform.position, Quaternion.identity);
		}
	}
}
