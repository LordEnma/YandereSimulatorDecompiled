using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x0600209C RID: 8348 RVA: 0x001DEAFC File Offset: 0x001DCCFC
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

	// Token: 0x04004764 RID: 18276
	public GameObject Explosion;
}
