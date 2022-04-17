using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x060020B7 RID: 8375 RVA: 0x001E2715 File Offset: 0x001E0915
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x060020B8 RID: 8376 RVA: 0x001E272C File Offset: 0x001E092C
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060020B9 RID: 8377 RVA: 0x001E27B4 File Offset: 0x001E09B4
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

	// Token: 0x040047D8 RID: 18392
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047D9 RID: 18393
	public GameObject BlackExplosion;
}
