using UnityEngine;

public class FalconPunchScript : MonoBehaviour
{
	public GameObject FalconExplosion;

	public Rigidbody MyRigidbody;

	public Collider MyCollider;

	public float Strength = 100f;

	public float Speed = 100f;

	public bool Destructive;

	public bool IgnoreTime;

	public bool Shipgirl;

	public bool Bancho;

	public bool Falcon;

	public bool Mecha;

	public float TimeLimit = 0.5f;

	public float Timer;

	private void Start()
	{
		if (Mecha)
		{
			MyRigidbody.AddForce(base.transform.forward * Speed * 10f);
		}
	}

	private void Update()
	{
		if (!IgnoreTime)
		{
			Timer += Time.deltaTime;
			if (Timer > TimeLimit)
			{
				MyCollider.enabled = false;
			}
		}
		if (Shipgirl)
		{
			MyRigidbody.AddForce(base.transform.forward * Speed);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("A punch collided with something.");
		if (other.gameObject.layer == 9)
		{
			Debug.Log("A punch collided with something on the Characters layer.");
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log("A punch collided with a student.");
				if (component.StudentID > 1)
				{
					Debug.Log("A punch collided with a student and killed them.");
					Object.Instantiate(FalconExplosion, component.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
					component.DeathType = DeathType.EasterEgg;
					component.BecomeRagdoll();
					Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
					rigidbody.isKinematic = false;
					Vector3 vector = rigidbody.transform.position - component.Yandere.transform.position;
					if (Falcon)
					{
						rigidbody.AddForce(vector * Strength);
					}
					else if (Bancho)
					{
						rigidbody.AddForce(vector.x * Strength, 5000f, vector.z * Strength);
					}
					else
					{
						rigidbody.AddForce(vector.x * Strength, 10000f, vector.z * Strength);
					}
				}
			}
		}
		if (!Destructive || other.gameObject.layer == 2 || other.gameObject.layer == 8 || other.gameObject.layer == 9 || other.gameObject.layer == 13 || other.gameObject.layer == 17)
		{
			return;
		}
		GameObject gameObject = null;
		StudentScript component2 = other.gameObject.transform.root.GetComponent<StudentScript>();
		if (component2 != null)
		{
			if (component2.StudentID <= 1)
			{
				gameObject = component2.gameObject;
			}
		}
		else
		{
			gameObject = other.gameObject;
		}
		if (gameObject != null)
		{
			Object.Instantiate(FalconExplosion, base.transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
			Object.Destroy(gameObject);
			Object.Destroy(base.gameObject);
		}
	}
}
