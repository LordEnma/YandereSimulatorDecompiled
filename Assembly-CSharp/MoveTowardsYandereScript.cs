using System;
using UnityEngine;

// Token: 0x02000370 RID: 880
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019D2 RID: 6610 RVA: 0x00108DDA File Offset: 0x00106FDA
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019D3 RID: 6611 RVA: 0x00108E1C File Offset: 0x0010701C
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Yandere.position) > this.Distance * 0.5f && base.transform.position.y < this.Yandere.position.y + 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
		}
		this.Speed += Time.deltaTime;
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yandere.position, this.Speed * Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yandere.position) == 0f)
		{
			this.Smoke.emission.enabled = false;
		}
	}

	// Token: 0x0400298C RID: 10636
	public ParticleSystem Smoke;

	// Token: 0x0400298D RID: 10637
	public Transform Yandere;

	// Token: 0x0400298E RID: 10638
	public float Distance;

	// Token: 0x0400298F RID: 10639
	public float Speed;

	// Token: 0x04002990 RID: 10640
	public bool Fall;
}
