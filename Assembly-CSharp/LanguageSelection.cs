using System;
using UnityEngine;

// Token: 0x02000041 RID: 65
[RequireComponent(typeof(UIPopupList))]
[AddComponentMenu("NGUI/Interaction/Language Selection")]
public class LanguageSelection : MonoBehaviour
{
	// Token: 0x06000102 RID: 258 RVA: 0x000131E3 File Offset: 0x000113E3
	private void Awake()
	{
		this.mList = base.GetComponent<UIPopupList>();
	}

	// Token: 0x06000103 RID: 259 RVA: 0x000131F1 File Offset: 0x000113F1
	private void Start()
	{
		this.mStarted = true;
		this.Refresh();
		EventDelegate.Add(this.mList.onChange, delegate()
		{
			Localization.language = UIPopupList.current.value;
		});
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00013230 File Offset: 0x00011430
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.Refresh();
		}
	}

	// Token: 0x06000105 RID: 261 RVA: 0x00013240 File Offset: 0x00011440
	public void Refresh()
	{
		if (this.mList != null && Localization.knownLanguages != null)
		{
			this.mList.Clear();
			int i = 0;
			int num = Localization.knownLanguages.Length;
			while (i < num)
			{
				this.mList.items.Add(Localization.knownLanguages[i]);
				i++;
			}
			this.mList.value = Localization.language;
		}
	}

	// Token: 0x06000106 RID: 262 RVA: 0x000132A8 File Offset: 0x000114A8
	private void OnLocalize()
	{
		this.Refresh();
	}

	// Token: 0x040002CA RID: 714
	private UIPopupList mList;

	// Token: 0x040002CB RID: 715
	private bool mStarted;
}
