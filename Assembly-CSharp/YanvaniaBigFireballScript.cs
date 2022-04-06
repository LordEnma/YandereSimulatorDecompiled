using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x060020AE RID: 8366 RVA: 0x001E1C54 File Offset: 0x001DFE54
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047C5 RID: 18373
	public GameObject Explosion;
}
