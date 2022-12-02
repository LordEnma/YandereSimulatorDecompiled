using UnityEngine;

public class RoseSpawnerScript : MonoBehaviour
{
	public Transform DramaGirl;

	public Transform Target;

	public GameObject Rose;

	public float Timer;

	public float ForwardForce;

	public float UpwardForce;

	private void Start()
	{
		SpawnRose();
	}

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 0.1f)
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
}
