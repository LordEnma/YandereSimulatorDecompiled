using UnityEngine;

public class ArcProjectileScript : MonoBehaviour
{
	private bool initialized;

	[Header("References")]
	public Rigidbody rigidbody;

	[Header("Settings")]
	public float ForwardMomentum;

	public float GravityFactor;

	public void Init()
	{
		initialized = true;
		if (rigidbody != null)
		{
			rigidbody.useGravity = false;
			rigidbody.AddForce(base.transform.forward * ForwardMomentum, ForceMode.VelocityChange);
		}
		else
		{
			Debug.LogError("The Arc Projectile does not have a component of type 'Rigidbody'");
			Object.Destroy(base.gameObject);
		}
	}

	private void FixedUpdate()
	{
		if (initialized && rigidbody != null)
		{
			rigidbody.AddForce(Physics.gravity * GravityFactor);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (initialized)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
