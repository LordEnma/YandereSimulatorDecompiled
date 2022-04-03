using System;
using UnityEngine;

// Token: 0x02000463 RID: 1123
public class SwordCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E88 RID: 7816 RVA: 0x001A6320 File Offset: 0x001A4520
	private void Start()
	{
		this.Segments = this.HeartSegment.gameObject.GetComponentsInChildren<Transform>();
		base.transform.position = new Vector3(0.5f, 1.25f, -1.9f);
		base.transform.eulerAngles = new Vector3(0f, -45f, 0f);
	}

	// Token: 0x06001E89 RID: 7817 RVA: 0x001A6384 File Offset: 0x001A4584
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

	// Token: 0x06001E8A RID: 7818 RVA: 0x001A653C File Offset: 0x001A473C
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

	// Token: 0x04003ED4 RID: 16084
	public Animation YandereAnimation;

	// Token: 0x04003ED5 RID: 16085
	public Animation SwordAnimation;

	// Token: 0x04003ED6 RID: 16086
	public Transform SecondAngle;

	// Token: 0x04003ED7 RID: 16087
	public Transform HeartSegment;

	// Token: 0x04003ED8 RID: 16088
	public Transform[] Segments;

	// Token: 0x04003ED9 RID: 16089
	public float Intensity;
}
