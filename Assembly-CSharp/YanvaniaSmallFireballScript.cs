﻿using System;
using UnityEngine;

// Token: 0x020004E9 RID: 1257
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x060020E9 RID: 8425 RVA: 0x001E5C70 File Offset: 0x001E3E70
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

	// Token: 0x0400484D RID: 18509
	public GameObject Explosion;
}
