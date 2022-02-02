using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x06002090 RID: 8336 RVA: 0x001DE12C File Offset: 0x001DC32C
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

	// Token: 0x04004752 RID: 18258
	public GameObject Explosion;
}
