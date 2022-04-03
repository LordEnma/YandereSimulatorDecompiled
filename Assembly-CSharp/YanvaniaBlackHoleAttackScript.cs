using System;
using UnityEngine;

// Token: 0x020004DA RID: 1242
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x060020A8 RID: 8360 RVA: 0x001E1789 File Offset: 0x001DF989
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x060020A9 RID: 8361 RVA: 0x001E17A0 File Offset: 0x001DF9A0
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060020AA RID: 8362 RVA: 0x001E1828 File Offset: 0x001DFA28
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

	// Token: 0x040047C2 RID: 18370
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047C3 RID: 18371
	public GameObject BlackExplosion;
}
