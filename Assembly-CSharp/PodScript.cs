using System;
using UnityEngine;

// Token: 0x020003AF RID: 943
public class PodScript : MonoBehaviour
{
	// Token: 0x06001AE7 RID: 6887 RVA: 0x001252BC File Offset: 0x001234BC
	private void Start()
	{
		this.Timer = 1f;
	}

	// Token: 0x06001AE8 RID: 6888 RVA: 0x001252CC File Offset: 0x001234CC
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

	// Token: 0x04002D14 RID: 11540
	public GameObject Projectile;

	// Token: 0x04002D15 RID: 11541
	public Transform SpawnPoint;

	// Token: 0x04002D16 RID: 11542
	public Transform PodTarget;

	// Token: 0x04002D17 RID: 11543
	public Transform AimTarget;

	// Token: 0x04002D18 RID: 11544
	public float FireRate;

	// Token: 0x04002D19 RID: 11545
	public float Timer;
}
