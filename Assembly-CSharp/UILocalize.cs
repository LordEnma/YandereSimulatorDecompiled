using System;
using UnityEngine;

// Token: 0x020000A5 RID: 165
[ExecuteInEditMode]
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/UI/Localize")]
public class UILocalize : MonoBehaviour
{
	// Token: 0x1700018D RID: 397
	// (set) Token: 0x060007EA RID: 2026 RVA: 0x00042190 File Offset: 0x00040390
	public string value
	{
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				UIWidget component = base.GetComponent<UIWidget>();
				UILabel uilabel = component as UILabel;
				UISprite uisprite = component as UISprite;
				if (uilabel != null)
				{
					UIInput uiinput = NGUITools.FindInParents<UIInput>(uilabel.gameObject);
					if (uiinput != null && uiinput.label == uilabel)
					{
						uiinput.defaultText = value;
						return;
					}
					uilabel.text = value;
					return;
				}
				else if (uisprite != null)
				{
					UIButton uibutton = NGUITools.FindInParents<UIButton>(uisprite.gameObject);
					if (uibutton != null && uibutton.tweenTarget == uisprite.gameObject)
					{
						uibutton.normalSprite = value;
					}
					uisprite.spriteName = value;
					uisprite.MakePixelPerfect();
				}
			}
		}
	}

	// Token: 0x060007EB RID: 2027 RVA: 0x0004223C File Offset: 0x0004043C
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnLocalize();
		}
	}

	// Token: 0x060007EC RID: 2028 RVA: 0x0004224C File Offset: 0x0004044C
	private void Start()
	{
		this.mStarted = true;
		this.OnLocalize();
	}

	// Token: 0x060007ED RID: 2029 RVA: 0x0004225C File Offset: 0x0004045C
	private void OnLocalize()
	{
		if (string.IsNullOrEmpty(this.key))
		{
			UILabel component = base.GetComponent<UILabel>();
			if (component != null)
			{
				this.key = component.text;
			}
		}
		if (!string.IsNullOrEmpty(this.key))
		{
			this.value = Localization.Get(this.key, true);
		}
	}

	// Token: 0x04000713 RID: 1811
	public string key;

	// Token: 0x04000714 RID: 1812
	private bool mStarted;
}
