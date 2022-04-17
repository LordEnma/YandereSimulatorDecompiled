using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x060020B5 RID: 8373 RVA: 0x001E26B0 File Offset: 0x001E08B0
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047D7 RID: 18391
	public GameObject Explosion;
}
