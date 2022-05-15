using System;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class SwordCutsceneScript : MonoBehaviour
{
	// Token: 0x06001EA8 RID: 7848 RVA: 0x001A9710 File Offset: 0x001A7910
	private void Start()
	{
		this.Segments = this.HeartSegment.gameObject.GetComponentsInChildren<Transform>();
		base.transform.position = new Vector3(0.5f, 1.25f, -1.9f);
		base.transform.eulerAngles = new Vector3(0f, -45f, 0f);
	}

	// Token: 0x06001EA9 RID: 7849 RVA: 0x001A9774 File Offset: 0x001A7974
	private void Update()
	{
		Debug.Log(this.YandereAnimation["f02_swordPull_00"].time);
		if (Input.GetKeyDown("space"))
		{
			this.YandereAnimation["f02_swordPull_00"].time = 15f;
			this.SwordAnimation["Sword_Pull"].time = 15f;
		}
		if (this.YandereAnimation["f02_swordPull_00"].time > 33f)
		{
			if (base.transform.position.x != 0f)
			{
				base.transform.position = new Vector3(0f, 1f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				return;
			}
			base.transform.position += new Vector3(0f, 0f, Time.deltaTime * 0.1f);
			return;
		}
		else
		{
			if (this.YandereAnimation["f02_swordPull_00"].time > 15.5f)
			{
				base.transform.position = new Vector3(0.66666f, 1.25f, -1.75f);
				base.transform.eulerAngles = new Vector3(0f, -45f, 0f);
				return;
			}
			if (this.YandereAnimation["f02_swordPull_00"].time > 10.5f)
			{
				base.transform.position = this.SecondAngle.position;
				base.transform.eulerAngles = this.SecondAngle.eulerAngles;
			}
			return;
		}
	}

	// Token: 0x06001EAA RID: 7850 RVA: 0x001A992C File Offset: 0x001A7B2C
	private void LateUpdate()
	{
		if (this.YandereAnimation["f02_swordPull_00"].time > 16.5f && this.YandereAnimation["f02_swordPull_00"].time < 22.5f)
		{
			this.Intensity += Time.deltaTime;
			Transform[] segments = this.Segments;
			for (int i = 0; i < segments.Length; i++)
			{
				segments[i].transform.position += new Vector3(UnityEngine.Random.Range(-0.001f * this.Intensity, 0.001f * this.Intensity), UnityEngine.Random.Range(-0.001f * this.Intensity, 0.001f * this.Intensity), UnityEngine.Random.Range(-0.001f * this.Intensity, 0.001f * this.Intensity));
			}
		}
	}

	// Token: 0x04003F1A RID: 16154
	public Animation YandereAnimation;

	// Token: 0x04003F1B RID: 16155
	public Animation SwordAnimation;

	// Token: 0x04003F1C RID: 16156
	public Transform SecondAngle;

	// Token: 0x04003F1D RID: 16157
	public Transform HeartSegment;

	// Token: 0x04003F1E RID: 16158
	public Transform[] Segments;

	// Token: 0x04003F1F RID: 16159
	public float Intensity;
}
