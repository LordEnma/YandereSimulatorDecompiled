using System;
using UnityEngine;

// Token: 0x020003C2 RID: 962
public class PromptBarScript : MonoBehaviour
{
	// Token: 0x06001B2B RID: 6955 RVA: 0x0012EB88 File Offset: 0x0012CD88
	private void Awake()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, -627f, base.transform.localPosition.z);
		this.ID = 0;
		while (this.ID < this.Label.Length)
		{
			this.Label[this.ID].text = string.Empty;
			this.ID++;
		}
	}

	// Token: 0x06001B2C RID: 6956 RVA: 0x0012EC08 File Offset: 0x0012CE08
	private void Start()
	{
		this.UpdateButtons();
	}

	// Token: 0x06001B2D RID: 6957 RVA: 0x0012EC10 File Offset: 0x0012CE10
	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (!this.Show)
		{
			if (this.Panel.enabled)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, -628f, t), base.transform.localPosition.z);
				if (base.transform.localPosition.y < -627f)
				{
					base.transform.localPosition = new Vector3(base.transform.localPosition.x, -628f, base.transform.localPosition.z);
					if (this.Panel != null)
					{
						this.Panel.enabled = false;
						return;
					}
				}
			}
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, -528.5f, t), base.transform.localPosition.z);
		}
	}

	// Token: 0x06001B2E RID: 6958 RVA: 0x0012ED44 File Offset: 0x0012CF44
	public void UpdateButtons()
	{
		if (this.Panel != null)
		{
			this.Panel.enabled = true;
		}
		this.ID = 0;
		while (this.ID < this.Label.Length)
		{
			this.Button[this.ID].enabled = (this.Label[this.ID].text.Length > 0);
			this.ButtonLabel[this.ID].enabled = (this.Label[this.ID].text.Length > 0);
			this.ID++;
		}
	}

	// Token: 0x06001B2F RID: 6959 RVA: 0x0012EDEC File Offset: 0x0012CFEC
	public void ClearButtons()
	{
		this.ID = 0;
		while (this.ID < this.Label.Length)
		{
			this.ButtonLabel[this.ID].enabled = false;
			this.Label[this.ID].text = string.Empty;
			this.Button[this.ID].enabled = false;
			this.ID++;
		}
	}

	// Token: 0x04002E32 RID: 11826
	public UISprite[] Button;

	// Token: 0x04002E33 RID: 11827
	public UILabel[] Label;

	// Token: 0x04002E34 RID: 11828
	public UILabel[] ButtonLabel;

	// Token: 0x04002E35 RID: 11829
	public UIPanel Panel;

	// Token: 0x04002E36 RID: 11830
	public bool Show;

	// Token: 0x04002E37 RID: 11831
	public int ID;
}
