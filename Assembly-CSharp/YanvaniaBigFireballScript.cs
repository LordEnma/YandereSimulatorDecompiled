using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x060020BF RID: 8383 RVA: 0x001E3C38 File Offset: 0x001E1E38
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047ED RID: 18413
	public GameObject Explosion;
}
