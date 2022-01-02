using System;
using UnityEngine;

// Token: 0x020003A6 RID: 934
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AA5 RID: 6821 RVA: 0x00120DAC File Offset: 0x0011EFAC
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AA6 RID: 6822 RVA: 0x00120DBC File Offset: 0x0011EFBC
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

	// Token: 0x04002C68 RID: 11368
	public GameObject Projectile;

	// Token: 0x04002C69 RID: 11369
	public Transform SpawnPoint;

	// Token: 0x04002C6A RID: 11370
	public Transform PodTarget;

	// Token: 0x04002C6B RID: 11371
	public Transform AimTarget;

	// Token: 0x04002C6C RID: 11372
	public float FireRate;

	// Token: 0x04002C6D RID: 11373
	public float Timer;
}
