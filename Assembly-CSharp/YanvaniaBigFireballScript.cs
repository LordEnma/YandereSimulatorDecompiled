using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x060020C9 RID: 8393 RVA: 0x001E5288 File Offset: 0x001E3488
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004814 RID: 18452
	public GameObject Explosion;
}
