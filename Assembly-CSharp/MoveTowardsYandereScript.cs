using System;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019CC RID: 6604 RVA: 0x0010871E File Offset: 0x0010691E
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019CD RID: 6605 RVA: 0x00108760 File Offset: 0x00106960
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

	// Token: 0x04002979 RID: 10617
	public ParticleSystem Smoke;

	// Token: 0x0400297A RID: 10618
	public Transform Yandere;

	// Token: 0x0400297B RID: 10619
	public float Distance;

	// Token: 0x0400297C RID: 10620
	public float Speed;

	// Token: 0x0400297D RID: 10621
	public bool Fall;
}
