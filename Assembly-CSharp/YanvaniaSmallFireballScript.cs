using System;
using UnityEngine;

// Token: 0x020004E8 RID: 1256
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x060020D9 RID: 8409 RVA: 0x001E3D88 File Offset: 0x001E1F88
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

	// Token: 0x04004825 RID: 18469
	public GameObject Explosion;
}
