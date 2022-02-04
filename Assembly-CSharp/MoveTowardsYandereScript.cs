using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019B2 RID: 6578 RVA: 0x00106CB2 File Offset: 0x00104EB2
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019B3 RID: 6579 RVA: 0x00106CF4 File Offset: 0x00104EF4
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

	// Token: 0x04002929 RID: 10537
	public ParticleSystem Smoke;

	// Token: 0x0400292A RID: 10538
	public Transform Yandere;

	// Token: 0x0400292B RID: 10539
	public float Distance;

	// Token: 0x0400292C RID: 10540
	public float Speed;

	// Token: 0x0400292D RID: 10541
	public bool Fall;
}
