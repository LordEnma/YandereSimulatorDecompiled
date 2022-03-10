using System;
using UnityEngine;

// Token: 0x02000060 RID: 96
[AddComponentMenu("NGUI/Interaction/Saved Option")]
public class UISavedOption : MonoBehaviour
{
	// Token: 0x17000033 RID: 51
	// (get) Token: 0x0600027C RID: 636 RVA: 0x0001BC96 File Offset: 0x00019E96
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

	// Token: 0x0600027D RID: 637 RVA: 0x0001BCBC File Offset: 0x00019EBC
	private void Awake()
	{
		this.mList = base.GetComponent<UIPopupList>();
		this.mCheck = base.GetComponent<UIToggle>();
		this.mSlider = base.GetComponent<UIProgressBar>();
	}

	// Token: 0x0600027E RID: 638 RVA: 0x0001BCE4 File Offset: 0x00019EE4
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

	// Token: 0x0600027F RID: 639 RVA: 0x0001BE20 File Offset: 0x0001A020
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

	// Token: 0x06000280 RID: 640 RVA: 0x0001BEE7 File Offset: 0x0001A0E7
	public void SaveSelection()
	{
		PlayerPrefs.SetString(this.key, UIPopupList.current.value);
	}

	// Token: 0x06000281 RID: 641 RVA: 0x0001BEFE File Offset: 0x0001A0FE
	public void SaveState()
	{
		PlayerPrefs.SetInt(this.key, UIToggle.current.value ? 1 : 0);
	}

	// Token: 0x06000282 RID: 642 RVA: 0x0001BF1B File Offset: 0x0001A11B
	public void SaveProgress()
	{
		PlayerPrefs.SetFloat(this.key, UIProgressBar.current.value);
	}

	// Token: 0x04000414 RID: 1044
	public string keyName;

	// Token: 0x04000415 RID: 1045
	private UIPopupList mList;

	// Token: 0x04000416 RID: 1046
	private UIToggle mCheck;

	// Token: 0x04000417 RID: 1047
	private UIProgressBar mSlider;
}
