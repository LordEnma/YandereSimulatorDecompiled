using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019B4 RID: 6580 RVA: 0x00106DBE File Offset: 0x00104FBE
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019B5 RID: 6581 RVA: 0x00106E00 File Offset: 0x00105000
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

	// Token: 0x0400292C RID: 10540
	public ParticleSystem Smoke;

	// Token: 0x0400292D RID: 10541
	public Transform Yandere;

	// Token: 0x0400292E RID: 10542
	public float Distance;

	// Token: 0x0400292F RID: 10543
	public float Speed;

	// Token: 0x04002930 RID: 10544
	public bool Fall;
}
