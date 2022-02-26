using System;
using UnityEngine;

// Token: 0x020004DE RID: 1246
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x060020A5 RID: 8357 RVA: 0x001DF6DC File Offset: 0x001DD8DC
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

	// Token: 0x04004774 RID: 18292
	public GameObject Explosion;
}
