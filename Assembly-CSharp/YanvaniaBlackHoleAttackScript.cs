using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x060020B0 RID: 8368 RVA: 0x001E1CB9 File Offset: 0x001DFEB9
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x060020B1 RID: 8369 RVA: 0x001E1CD0 File Offset: 0x001DFED0
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060020B2 RID: 8370 RVA: 0x001E1D58 File Offset: 0x001DFF58
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.BlackExplosion, base.transform.position, Quaternion.identity);
			this.Yanmont.TakeDamage(20);
		}
		if (other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.BlackExplosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047C6 RID: 18374
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047C7 RID: 18375
	public GameObject BlackExplosion;
}
