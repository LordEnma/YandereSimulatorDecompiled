using System;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x060020E0 RID: 8416 RVA: 0x001E47E4 File Offset: 0x001E29E4
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

	// Token: 0x04004837 RID: 18487
	public GameObject Explosion;
}
