using System;
using UnityEngine;

// Token: 0x020003AF RID: 943
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AE8 RID: 6888 RVA: 0x001254EC File Offset: 0x001236EC
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AE9 RID: 6889 RVA: 0x001254FC File Offset: 0x001236FC
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

	// Token: 0x04002D1B RID: 11547
	public GameObject Projectile;

	// Token: 0x04002D1C RID: 11548
	public Transform SpawnPoint;

	// Token: 0x04002D1D RID: 11549
	public Transform PodTarget;

	// Token: 0x04002D1E RID: 11550
	public Transform AimTarget;

	// Token: 0x04002D1F RID: 11551
	public float FireRate;

	// Token: 0x04002D20 RID: 11552
	public float Timer;
}
