using System;
using UnityEngine;

// Token: 0x020004EA RID: 1258
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x060020F5 RID: 8437 RVA: 0x001E7924 File Offset: 0x001E5B24
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

	// Token: 0x0400487D RID: 18557
	public GameObject Explosion;
}
