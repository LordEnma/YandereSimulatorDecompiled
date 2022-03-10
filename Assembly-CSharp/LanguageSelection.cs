using System;
using UnityEngine;

// Token: 0x02000041 RID: 65
[RequireComponent(typeof(UIPopupList))]
[AddComponentMenu("NGUI/Interaction/Language Selection")]
public class LanguageSelection : MonoBehaviour
{
	// Token: 0x06000102 RID: 258 RVA: 0x000132D3 File Offset: 0x000114D3
	private void Awake()
	{
		this.mList = base.GetComponent<UIPopupList>();
	}

	// Token: 0x06000103 RID: 259 RVA: 0x000132E1 File Offset: 0x000114E1
	private void Start()
	{
		this.mStarted = true;
		this.Refresh();
		EventDelegate.Add(this.mList.onChange, delegate()
		{
			Localization.language = UIPopupList.current.value;
		});
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00013320 File Offset: 0x00011520
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.Refresh();
		}
	}

	// Token: 0x06000105 RID: 261 RVA: 0x00013330 File Offset: 0x00011530
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

	// Token: 0x06000106 RID: 262 RVA: 0x00013398 File Offset: 0x00011598
	private void OnLocalize()
	{
		this.Refresh();
	}

	// Token: 0x040002D5 RID: 725
	private UIPopupList mList;

	// Token: 0x040002D6 RID: 726
	private bool mStarted;
}
