using UnityEngine;

public class RoseSpawnerScript : MonoBehaviour
{
	public Transform DramaGirl;

	public Transform Target;

	public GameObject Rose;

	public float RoseFrequency = 0.1f;

	public float Timer;

	public float ForwardForce;

	public float UpwardForce;

	public float forceAmount;

	private void Start()
	{
		SpawnRose();
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > RoseFrequency)
		{
			SpawnRose();
		}
	}

	private void SpawnRose()
	{
		GameObject obj = Object.Instantiate(Rose, base.transform.position, Quaternion.identity);
		obj.GetComponent<Rigidbody>().AddForce(base.transform.forward * ForwardForce);
		obj.GetComponent<Rigidbody>().AddForce(base.transform.up * UpwardForce);
		obj.transform.localEulerAngles = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
		base.transform.localPosition = new Vector3(Random.Range(-5f, 5f), base.transform.localPosition.y, base.transform.localPosition.z);
		base.transform.LookAt(DramaGirl);
		Timer = 0f;
	}

	public void Shoot()
	{
		base.transform.localPosition = new Vector3(Random.Range(-5f, 5f), base.transform.localPosition.y, base.transform.localPosition.z);
		base.transform.LookAt(Target);
		GameObject gameObject = Object.Instantiate(Rose, base.transform.position, Quaternion.identity);
		Rigidbody component = gameObject.GetComponent<Rigidbody>();
		if (component != null && Target != null)
		{
			Vector3 normalized = (Target.position - gameObject.transform.position).normalized;
			gameObject.transform.rotation = Quaternion.LookRotation(normalized);
			component.AddForce(normalized * forceAmount);
		}
	}
}
