using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019B1 RID: 6577 RVA: 0x001067BE File Offset: 0x001049BE
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019B2 RID: 6578 RVA: 0x00106800 File Offset: 0x00104A00
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

	// Token: 0x04002922 RID: 10530
	public ParticleSystem Smoke;

	// Token: 0x04002923 RID: 10531
	public Transform Yandere;

	// Token: 0x04002924 RID: 10532
	public float Distance;

	// Token: 0x04002925 RID: 10533
	public float Speed;

	// Token: 0x04002926 RID: 10534
	public bool Fall;
}
