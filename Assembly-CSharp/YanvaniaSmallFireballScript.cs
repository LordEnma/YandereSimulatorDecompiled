using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x0600207C RID: 8316 RVA: 0x001DBC2C File Offset: 0x001D9E2C
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

	// Token: 0x04004723 RID: 18211
	public GameObject Explosion;
}
