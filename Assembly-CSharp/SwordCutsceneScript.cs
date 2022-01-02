using System;
using UnityEngine;

// Token: 0x02000459 RID: 1113
public class SwordCutsceneScript : MonoBehaviour
{
	// Token: 0x06001E48 RID: 7752 RVA: 0x001A02C8 File Offset: 0x0019E4C8
	private void Start()
	{
		this.Segments = this.HeartSegment.gameObject.GetComponentsInChildren<Transform>();
		base.transform.position = new Vector3(0.5f, 1.25f, -1.9f);
		base.transform.eulerAngles = new Vector3(0f, -45f, 0f);
	}

	// Token: 0x06001E49 RID: 7753 RVA: 0x001A032C File Offset: 0x0019E52C
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

	// Token: 0x06001E4A RID: 7754 RVA: 0x001A04E4 File Offset: 0x0019E6E4
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

	// Token: 0x04003E04 RID: 15876
	public Animation YandereAnimation;

	// Token: 0x04003E05 RID: 15877
	public Animation SwordAnimation;

	// Token: 0x04003E06 RID: 15878
	public Transform SecondAngle;

	// Token: 0x04003E07 RID: 15879
	public Transform HeartSegment;

	// Token: 0x04003E08 RID: 15880
	public Transform[] Segments;

	// Token: 0x04003E09 RID: 15881
	public float Intensity;
}
