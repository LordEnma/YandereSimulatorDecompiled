using System;
using UnityEngine;

// Token: 0x020004E7 RID: 1255
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x060020D1 RID: 8401 RVA: 0x001E3858 File Offset: 0x001E1A58
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

	// Token: 0x04004821 RID: 18465
	public GameObject Explosion;
}
