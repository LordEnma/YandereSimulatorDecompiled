using System;
using UnityEngine;

// Token: 0x020004D7 RID: 1239
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x0600206B RID: 8299 RVA: 0x001DA4F8 File Offset: 0x001D86F8
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

	// Token: 0x040046E4 RID: 18148
	public GameObject Explosion;
}
