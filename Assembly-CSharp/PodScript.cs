using System;
using UnityEngine;

// Token: 0x020003AD RID: 941
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AD3 RID: 6867 RVA: 0x00123D64 File Offset: 0x00121F64
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AD4 RID: 6868 RVA: 0x00123D74 File Offset: 0x00121F74
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

	// Token: 0x04002CEB RID: 11499
	public GameObject Projectile;

	// Token: 0x04002CEC RID: 11500
	public Transform SpawnPoint;

	// Token: 0x04002CED RID: 11501
	public Transform PodTarget;

	// Token: 0x04002CEE RID: 11502
	public Transform AimTarget;

	// Token: 0x04002CEF RID: 11503
	public float FireRate;

	// Token: 0x04002CF0 RID: 11504
	public float Timer;
}
