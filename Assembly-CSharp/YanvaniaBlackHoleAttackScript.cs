using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x0600206C RID: 8300 RVA: 0x001DC579 File Offset: 0x001DA779
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x0600206D RID: 8301 RVA: 0x001DC590 File Offset: 0x001DA790
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600206E RID: 8302 RVA: 0x001DC618 File Offset: 0x001DA818
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

	// Token: 0x040046FC RID: 18172
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046FD RID: 18173
	public GameObject BlackExplosion;
}
