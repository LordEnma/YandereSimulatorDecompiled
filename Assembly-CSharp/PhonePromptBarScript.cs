using System;
using UnityEngine;

// Token: 0x020003A0 RID: 928
public class PhonePromptBarScript : MonoBehaviour
{
	// Token: 0x06001A76 RID: 6774 RVA: 0x0011C5B4 File Offset: 0x0011A7B4
	private void Start()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, 630f, base.transform.localPosition.z);
		this.Panel.enabled = false;
	}

	// Token: 0x06001A77 RID: 6775 RVA: 0x0011C604 File Offset: 0x0011A804
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

	// Token: 0x04002BCF RID: 11215
	public UIPanel Panel;

	// Token: 0x04002BD0 RID: 11216
	public bool Show;

	// Token: 0x04002BD1 RID: 11217
	public UILabel Label;
}
