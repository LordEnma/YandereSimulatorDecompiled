using System;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x060020C3 RID: 8387 RVA: 0x001E201C File Offset: 0x001E021C
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

	// Token: 0x040047F0 RID: 18416
	public GameObject Explosion;
}
