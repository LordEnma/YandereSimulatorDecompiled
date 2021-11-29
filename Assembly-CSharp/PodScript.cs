using System;
using UnityEngine;

// Token: 0x020003A5 RID: 933
public class PodScript : MonoBehaviour
{
	// Token: 0x06001A9B RID: 6811 RVA: 0x00120254 File Offset: 0x0011E454
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001A9C RID: 6812 RVA: 0x00120264 File Offset: 0x0011E464
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

	// Token: 0x04002C3A RID: 11322
	public GameObject Projectile;

	// Token: 0x04002C3B RID: 11323
	public Transform SpawnPoint;

	// Token: 0x04002C3C RID: 11324
	public Transform PodTarget;

	// Token: 0x04002C3D RID: 11325
	public Transform AimTarget;

	// Token: 0x04002C3E RID: 11326
	public float FireRate;

	// Token: 0x04002C3F RID: 11327
	public float Timer;
}
