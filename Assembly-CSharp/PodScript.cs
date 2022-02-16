using System;
using UnityEngine;

// Token: 0x020003A9 RID: 937
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AB6 RID: 6838 RVA: 0x00121BFC File Offset: 0x0011FDFC
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AB7 RID: 6839 RVA: 0x00121C0C File Offset: 0x0011FE0C
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

	// Token: 0x04002C81 RID: 11393
	public GameObject Projectile;

	// Token: 0x04002C82 RID: 11394
	public Transform SpawnPoint;

	// Token: 0x04002C83 RID: 11395
	public Transform PodTarget;

	// Token: 0x04002C84 RID: 11396
	public Transform AimTarget;

	// Token: 0x04002C85 RID: 11397
	public float FireRate;

	// Token: 0x04002C86 RID: 11398
	public float Timer;
}
