using System;
using UnityEngine;

// Token: 0x02000060 RID: 96
[AddComponentMenu("NGUI/Interaction/Saved Option")]
public class UISavedOption : MonoBehaviour
{
	// Token: 0x17000033 RID: 51
	// (get) Token: 0x0600027C RID: 636 RVA: 0x0001BBA6 File Offset: 0x00019DA6
	private string key
	{
		get
		{
			if (!string.IsNullOrEmpty(this.keyName))
			{
				return this.keyName;
			}
			return "NGUI State: " + base.name;
		}
	}

	// Token: 0x0600027D RID: 637 RVA: 0x0001BBCC File Offset: 0x00019DCC
	private void Awake()
	{
		this.mList = base.GetComponent<UIPopupList>();
		this.mCheck = base.GetComponent<UIToggle>();
		this.mSlider = base.GetComponent<UIProgressBar>();
	}

	// Token: 0x0600027E RID: 638 RVA: 0x0001BBF4 File Offset: 0x00019DF4
	private void OnEnable()
	{
		if (this.mList != null)
		{
			EventDelegate.Add(this.mList.onChange, new EventDelegate.Callback(this.SaveSelection));
			string @string = PlayerPrefs.GetString(this.key);
			if (!string.IsNullOrEmpty(@string))
			{
				this.mList.value = @string;
				return;
			}
		}
		else
		{
			if (this.mCheck != null)
			{
				EventDelegate.Add(this.mCheck.onChange, new EventDelegate.Callback(this.SaveState));
				this.mCheck.value = (PlayerPrefs.GetInt(this.key, this.mCheck.startsActive ? 1 : 0) != 0);
				return;
			}
			if (this.mSlider != null)
			{
				EventDelegate.Add(this.mSlider.onChange, new EventDelegate.Callback(this.SaveProgress));
				this.mSlider.value = PlayerPrefs.GetFloat(this.key, this.mSlider.value);
				return;
			}
			string string2 = PlayerPrefs.GetString(this.key);
			UIToggle[] componentsInChildren = base.GetComponentsInChildren<UIToggle>(true);
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				UIToggle uitoggle = componentsInChildren[i];
				uitoggle.value = (uitoggle.name == string2);
				i++;
			}
		}
	}

	// Token: 0x0600027F RID: 639 RVA: 0x0001BD30 File Offset: 0x00019F30
	private void OnDisable()
	{
		if (this.mCheck != null)
		{
			EventDelegate.Remove(this.mCheck.onChange, new EventDelegate.Callback(this.SaveState));
			return;
		}
		if (this.mList != null)
		{
			EventDelegate.Remove(this.mList.onChange, new EventDelegate.Callback(this.SaveSelection));
			return;
		}
		if (this.mSlider != null)
		{
			EventDelegate.Remove(this.mSlider.onChange, new EventDelegate.Callback(this.SaveProgress));
			return;
		}
		UIToggle[] componentsInChildren = base.GetComponentsInChildren<UIToggle>(true);
		int i = 0;
		int num = componentsInChildren.Length;
		while (i < num)
		{
			UIToggle uitoggle = componentsInChildren[i];
			if (uitoggle.value)
			{
				PlayerPrefs.SetString(this.key, uitoggle.name);
				return;
			}
			i++;
		}
	}

	// Token: 0x06000280 RID: 640 RVA: 0x0001BDF7 File Offset: 0x00019FF7
	public void SaveSelection()
	{
		PlayerPrefs.SetString(this.key, UIPopupList.current.value);
	}

	// Token: 0x06000281 RID: 641 RVA: 0x0001BE0E File Offset: 0x0001A00E
	public void SaveState()
	{
		PlayerPrefs.SetInt(this.key, UIToggle.current.value ? 1 : 0);
	}

	// Token: 0x06000282 RID: 642 RVA: 0x0001BE2B File Offset: 0x0001A02B
	public void SaveProgress()
	{
		PlayerPrefs.SetFloat(this.key, UIProgressBar.current.value);
	}

	// Token: 0x04000409 RID: 1033
	public string keyName;

	// Token: 0x0400040A RID: 1034
	private UIPopupList mList;

	// Token: 0x0400040B RID: 1035
	private UIToggle mCheck;

	// Token: 0x0400040C RID: 1036
	private UIProgressBar mSlider;
}
