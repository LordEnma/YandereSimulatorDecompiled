using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x0600208A RID: 8330 RVA: 0x001DCBBC File Offset: 0x001DADBC
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

	// Token: 0x04004740 RID: 18240
	public GameObject Explosion;
}
