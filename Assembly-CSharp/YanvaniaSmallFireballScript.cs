using System;
using UnityEngine;

// Token: 0x020004EA RID: 1258
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x060020F4 RID: 8436 RVA: 0x001E73BC File Offset: 0x001E55BC
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

	// Token: 0x04004874 RID: 18548
	public GameObject Explosion;
}
