using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
[RequireComponent(typeof(UISlider))]
[AddComponentMenu("NGUI/Interaction/Sound Volume")]
public class UISoundVolume : MonoBehaviour
{
	// Token: 0x060002C1 RID: 705 RVA: 0x0001DFBE File Offset: 0x0001C1BE
	private void Awake()
	{
		UISlider component = base.GetComponent<UISlider>();
		component.value = NGUITools.soundVolume;
		EventDelegate.Add(component.onChange, new EventDelegate.Callback(this.OnChange));
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x0001DFE8 File Offset: 0x0001C1E8
	private void OnChange()
	{
		NGUITools.soundVolume = UIProgressBar.current.value;
	}
}
