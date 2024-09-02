using UnityEngine;

public class GasterBeamScript : MonoBehaviour
{
	public float Strength = 1000f;

	public float Target = 2f;

	public bool LoveLoveBeam;

	private void Start()
	{
		if (LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	private void Update()
	{
		if (!LoveLoveBeam)
		{
			return;
		}
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(100f, Target, Target), Time.deltaTime * 10f);
		if (base.transform.localScale.x > 99.99f)
		{
			Target = 0f;
			if (base.transform.localScale.y < 0.1f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				component.DeathType = DeathType.Burning;
				component.BecomeRagdoll();
				Rigidbody obj = component.Ragdoll.AllRigidbodies[0];
				obj.isKinematic = false;
				obj.AddForce((obj.transform.root.position - base.transform.root.position) * Strength);
				obj.AddForce(Vector3.up * 1000f);
			}
		}
	}
}
