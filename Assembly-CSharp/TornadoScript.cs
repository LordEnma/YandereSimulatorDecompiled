using UnityEngine;

public class TornadoScript : MonoBehaviour
{
	public GameObject FemaleBloodyScream;

	public GameObject MaleBloodyScream;

	public GameObject Scream;

	public Collider MyCollider;

	public float Strength = 10000f;

	public float Timer;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			MyCollider.enabled = true;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				Scream = Object.Instantiate(component.Male ? MaleBloodyScream : FemaleBloodyScream, component.transform.position + Vector3.up, Quaternion.identity);
				Scream.transform.parent = component.HipCollider.transform;
				Scream.transform.localPosition = Vector3.zero;
				component.DeathType = DeathType.EasterEgg;
				component.BecomeRagdoll();
				Rigidbody obj = component.Ragdoll.AllRigidbodies[0];
				obj.isKinematic = false;
				obj.AddForce(Vector3.up * Strength);
			}
		}
	}
}
