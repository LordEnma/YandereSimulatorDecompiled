using System;
using UnityEngine;

// Token: 0x020004D9 RID: 1241
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x060020A6 RID: 8358 RVA: 0x001E1724 File Offset: 0x001DF924
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047C1 RID: 18369
	public GameObject Explosion;
}
