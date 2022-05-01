using System;
using UnityEngine;

// Token: 0x020000A3 RID: 163
[RequireComponent(typeof(UIInput))]
public class UIInputOnGUI : MonoBehaviour
{
	// Token: 0x06000768 RID: 1896 RVA: 0x000401C1 File Offset: 0x0003E3C1
	private void Awake()
	{
		this.mInput = base.GetComponent<UIInput>();
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x000401CF File Offset: 0x0003E3CF
	private void OnGUI()
	{
		if (Event.current.rawType == EventType.KeyDown)
		{
			this.mInput.ProcessEvent(Event.current);
		}
	}

	// Token: 0x040006EF RID: 1775
	[NonSerialized]
	private UIInput mInput;
}
