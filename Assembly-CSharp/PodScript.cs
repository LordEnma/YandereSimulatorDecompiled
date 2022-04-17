using System;
using UnityEngine;

// Token: 0x020003AE RID: 942
public class PodScript : MonoBehaviour
{
	// Token: 0x06001ADD RID: 6877 RVA: 0x0012431C File Offset: 0x0012251C
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001ADE RID: 6878 RVA: 0x0012432C File Offset: 0x0012252C
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

	// Token: 0x04002CF8 RID: 11512
	public GameObject Projectile;

	// Token: 0x04002CF9 RID: 11513
	public Transform SpawnPoint;

	// Token: 0x04002CFA RID: 11514
	public Transform PodTarget;

	// Token: 0x04002CFB RID: 11515
	public Transform AimTarget;

	// Token: 0x04002CFC RID: 11516
	public float FireRate;

	// Token: 0x04002CFD RID: 11517
	public float Timer;
}
