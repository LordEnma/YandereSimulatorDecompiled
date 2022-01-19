using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x0600208C RID: 8332 RVA: 0x001DD88C File Offset: 0x001DBA8C
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

	// Token: 0x04004747 RID: 18247
	public GameObject Explosion;
}
