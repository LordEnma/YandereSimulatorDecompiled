using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x0600207C RID: 8316 RVA: 0x001DD60D File Offset: 0x001DB80D
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x0600207D RID: 8317 RVA: 0x001DD624 File Offset: 0x001DB824
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600207E RID: 8318 RVA: 0x001DD6AC File Offset: 0x001DB8AC
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

	// Token: 0x04004715 RID: 18197
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004716 RID: 18198
	public GameObject BlackExplosion;
}
