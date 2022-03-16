using System;
using UnityEngine;

// Token: 0x020004D5 RID: 1237
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x06002098 RID: 8344 RVA: 0x001DFEE8 File Offset: 0x001DE0E8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004790 RID: 18320
	public GameObject Explosion;
}
