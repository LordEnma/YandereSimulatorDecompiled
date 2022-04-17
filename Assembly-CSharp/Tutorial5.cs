using System;
using UnityEngine;

// Token: 0x0200003C RID: 60
public class Tutorial5 : MonoBehaviour
{
	// Token: 0x060000F2 RID: 242 RVA: 0x00012F50 File Offset: 0x00011150
	public void SetDurationToCurrentProgress()
	{
		UITweener[] componentsInChildren = base.GetComponentsInChildren<UITweener>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].duration = Mathf.Lerp(2f, 0.5f, UIProgressBar.current.value);
		}
	}
}
