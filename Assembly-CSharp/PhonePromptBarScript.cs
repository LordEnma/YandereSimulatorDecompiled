using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A73 RID: 6771 RVA: 0x0011BDEC File Offset: 0x00119FEC
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A74 RID: 6772 RVA: 0x0011BE3C File Offset: 0x0011A03C
	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (!this.Show)
		{
			if (this.Panel.enabled)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 631f, t), base.transform.localPosition.z);
				if (base.transform.localPosition.y < 630f)
				{
					base.transform.localPosition = new Vector3(base.transform.localPosition.x, 631f, base.transform.localPosition.z);
					this.Panel.enabled = false;
					return;
				}
			}
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 530f, t), base.transform.localPosition.z);
		}
	}

	// Token: 0x04002BC2 RID: 11202
	public UIPanel Panel;

	// Token: 0x04002BC3 RID: 11203
	public bool Show;

	// Token: 0x04002BC4 RID: 11204
	public UILabel Label;
}
