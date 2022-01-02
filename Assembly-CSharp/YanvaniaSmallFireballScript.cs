using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x0600207F RID: 8319 RVA: 0x001DC21C File Offset: 0x001DA41C
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(10);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400472C RID: 18220
	public GameObject Explosion;
}
