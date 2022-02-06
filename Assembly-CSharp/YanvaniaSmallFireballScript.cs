using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x06002095 RID: 8341 RVA: 0x001DE648 File Offset: 0x001DC848
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

	// Token: 0x0400475B RID: 18267
	public GameObject Explosion;
}
