using UnityEngine;

public class ArcScript : MonoBehaviour
{
	private static readonly Vector3 NEW_ARC_RELATIVE_FORCE = Vector3.forward * 375f;

	public GameObject ArcTrail;

	public float Timer;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 0.5f)
		{
			GameObject obj = Object.Instantiate(ArcTrail, base.transform.position, base.transform.rotation);
			obj.transform.parent = base.transform;
			obj.GetComponent<Rigidbody>().AddRelativeForce(NEW_ARC_RELATIVE_FORCE);
			Timer = 0f;
		}
	}
}
