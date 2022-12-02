using UnityEngine;

public class MoveTowardsYandereScript : MonoBehaviour
{
	public ParticleSystem Smoke;

	public Transform Yandere;

	public float Distance;

	public float Speed;

	public bool Fall;

	private void Start()
	{
		Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		Distance = Vector3.Distance(base.transform.position, Yandere.position);
	}

	private void Update()
	{
		if (Vector3.Distance(base.transform.position, Yandere.position) > Distance * 0.5f && base.transform.position.y < Yandere.position.y + 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
		}
		Speed += Time.deltaTime;
		base.transform.position = Vector3.MoveTowards(base.transform.position, Yandere.position, Speed * Time.deltaTime);
		if (Vector3.Distance(base.transform.position, Yandere.position) == 0f)
		{
			ParticleSystem.EmissionModule emission = Smoke.emission;
			emission.enabled = false;
		}
	}
}
