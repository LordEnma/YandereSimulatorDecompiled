using UnityEngine;

public class YanvaniaBigFireballScript : MonoBehaviour
{
	public GameObject Explosion;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			Object.Instantiate(Explosion, base.transform.position, Quaternion.identity);
			Object.Destroy(base.gameObject);
		}
	}
}
