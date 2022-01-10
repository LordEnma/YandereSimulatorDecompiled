using System;
using UnityEngine;

// Token: 0x0200045B RID: 1115
public class SwordCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E53 RID: 7763 RVA: 0x001A0C48 File Offset: 0x0019EE48
	private void Start()
	{
		this.Segments = this.HeartSegment.gameObject.GetComponentsInChildren<Transform>();
		base.transform.position = new Vector3(0.5f, 1.25f, -1.9f);
		base.transform.eulerAngles = new Vector3(0f, -45f, 0f);
	}

	// Token: 0x06001E54 RID: 7764 RVA: 0x001A0CAC File Offset: 0x0019EEAC
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

	// Token: 0x06001E55 RID: 7765 RVA: 0x001A0E64 File Offset: 0x0019F064
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

	// Token: 0x04003E18 RID: 15896
	public Animation YandereAnimation;

	// Token: 0x04003E19 RID: 15897
	public Animation SwordAnimation;

	// Token: 0x04003E1A RID: 15898
	public Transform SecondAngle;

	// Token: 0x04003E1B RID: 15899
	public Transform HeartSegment;

	// Token: 0x04003E1C RID: 15900
	public Transform[] Segments;

	// Token: 0x04003E1D RID: 15901
	public float Intensity;
}
