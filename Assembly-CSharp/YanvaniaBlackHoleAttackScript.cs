using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x060020CB RID: 8395 RVA: 0x001E52ED File Offset: 0x001E34ED
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x060020CC RID: 8396 RVA: 0x001E5304 File Offset: 0x001E3504
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060020CD RID: 8397 RVA: 0x001E538C File Offset: 0x001E358C
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

	// Token: 0x04004815 RID: 18453
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004816 RID: 18454
	public GameObject BlackExplosion;
}
