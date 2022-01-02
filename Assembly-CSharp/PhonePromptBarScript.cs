using System;
using UnityEngine;

// Token: 0x0200039E RID: 926
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A6C RID: 6764 RVA: 0x0011BAA4 File Offset: 0x00119CA4
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A6D RID: 6765 RVA: 0x0011BAF4 File Offset: 0x00119CF4
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

	// Token: 0x04002BBC RID: 11196
	public UIPanel Panel;

	// Token: 0x04002BBD RID: 11197
	public bool Show;

	// Token: 0x04002BBE RID: 11198
	public UILabel Label;
}
