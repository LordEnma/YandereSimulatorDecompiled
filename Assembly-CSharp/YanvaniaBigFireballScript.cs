using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x060020CA RID: 8394 RVA: 0x001E57F0 File Offset: 0x001E39F0
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400481D RID: 18461
	public GameObject Explosion;
}
