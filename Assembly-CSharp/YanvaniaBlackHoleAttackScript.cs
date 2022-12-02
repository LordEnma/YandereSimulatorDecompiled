using UnityEngine;

public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	public YanvaniaYanmontScript Yanmont;

	public GameObject BlackExplosion;

	private void Start()
	{
		Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, Yanmont.transform.position) > 10f || Yanmont.EnterCutscene)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			Object.Instantiate(BlackExplosion, base.transform.position, Quaternion.identity);
			Yanmont.TakeDamage(20);
		}
		if (other.gameObject.name == "Heart")
		{
			Object.Instantiate(BlackExplosion, base.transform.position, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
	}
}
