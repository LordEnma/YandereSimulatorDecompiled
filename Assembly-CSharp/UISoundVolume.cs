using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
[RequireComponent(typeof(UISlider))]
[AddComponentMenu("NGUI/Interaction/Sound Volume")]
public class UISoundVolume : MonoBehaviour
{
	// Token: 0x060002C1 RID: 705 RVA: 0x0001E2A6 File Offset: 0x0001C4A6
	private void Awake()
	{
		UISlider component = base.GetComponent<UISlider>();
		component.value = NGUITools.soundVolume;
		EventDelegate.Add(component.onChange, new EventDelegate.Callback(this.OnChange));
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x0001E2D0 File Offset: 0x0001C4D0
	private void OnChange()
	{
		NGUITools.soundVolume = UIProgressBar.current.value;
	}
}
