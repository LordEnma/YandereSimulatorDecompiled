using UnityEngine;

public class MatchScript : MonoBehaviour
{
	public GameObject Distraction;

	public GameObject GiggleDisc;

	public GameObject GasCloud;

	public GameObject Flash;

	public Rigidbody MyRigidbody;

	public float GravityFactor;

	public AudioClip Bang;

	public bool StinkBomb;

	public bool Pebble;

	private void Update()
	{
		base.transform.Rotate(360f * Time.deltaTime, 360f * Time.deltaTime, 360f * Time.deltaTime);
	}

	private void FixedUpdate()
	{
		if (MyRigidbody != null && GravityFactor > 0f)
		{
			MyRigidbody.AddForce(Physics.gravity * GravityFactor);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.layer == 0 || collision.gameObject.layer == 8)
		{
			Debug.Log("Exploding because struck: " + collision.gameObject.name);
			if (StinkBomb)
			{
				Object.Instantiate(GasCloud, base.transform.position, Quaternion.identity);
			}
			else if (Pebble)
			{
				Object.Instantiate(Distraction, base.transform.position, Quaternion.identity);
				AudioSource.PlayClipAtPoint(Bang, base.transform.position);
			}
			else
			{
				GameObject obj = Object.Instantiate(GiggleDisc, base.transform.position, Quaternion.identity);
				obj.GetComponent<BoxCollider>().size = new Vector3(0.02f, 1f, 0.02f);
				obj.GetComponent<GiggleScript>().BangSnap = true;
				AudioSource.PlayClipAtPoint(Bang, base.transform.position);
			}
			Object.Instantiate(Flash, base.transform.position, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
	}
}
