using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x06002073 RID: 8307 RVA: 0x001DCA2D File Offset: 0x001DAC2D
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x06002074 RID: 8308 RVA: 0x001DCA44 File Offset: 0x001DAC44
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06002075 RID: 8309 RVA: 0x001DCACC File Offset: 0x001DACCC
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

	// Token: 0x04004705 RID: 18181
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004706 RID: 18182
	public GameObject BlackExplosion;
}
