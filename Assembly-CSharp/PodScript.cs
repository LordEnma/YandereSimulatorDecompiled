using System;
using UnityEngine;

// Token: 0x020003AA RID: 938
public class PodScript : MonoBehaviour
{
	// Token: 0x06001ACA RID: 6858 RVA: 0x00123684 File Offset: 0x00121884
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001ACB RID: 6859 RVA: 0x00123694 File Offset: 0x00121894
	private void LateUpdate()
	{
		this.PodTarget.transform.parent.eulerAngles = new Vector3(0f, this.AimTarget.parent.eulerAngles.y, 0f);
		base.transform.position = Vector3.Lerp(base.transform.position, this.PodTarget.position, Time.deltaTime * 100f);
		base.transform.rotation = this.AimTarget.parent.rotation;
		base.transform.eulerAngles += new Vector3(-15f, 7.5f, 0f);
		if (Input.GetButton("RB"))
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > this.FireRate)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.Projectile, this.SpawnPoint.position, base.transform.rotation);
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x04002CD3 RID: 11475
	public GameObject Projectile;

	// Token: 0x04002CD4 RID: 11476
	public Transform SpawnPoint;

	// Token: 0x04002CD5 RID: 11477
	public Transform PodTarget;

	// Token: 0x04002CD6 RID: 11478
	public Transform AimTarget;

	// Token: 0x04002CD7 RID: 11479
	public float FireRate;

	// Token: 0x04002CD8 RID: 11480
	public float Timer;
}
