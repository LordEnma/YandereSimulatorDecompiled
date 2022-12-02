using UnityEngine;

public class YanvaniaSmallFireballScript : MonoBehaviour
{
	public GameObject Explosion;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Heart")
		{
			Object.Instantiate(Explosion, base.transform.position, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(10);
			Object.Instantiate(Explosion, base.transform.position, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
	}
}
