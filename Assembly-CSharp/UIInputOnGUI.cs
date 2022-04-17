using System;
using UnityEngine;

// Token: 0x020000A3 RID: 163
[RequireComponent(typeof(UIInput))]
public class UIInputOnGUI : MonoBehaviour
{
	// Token: 0x06000768 RID: 1896 RVA: 0x00040081 File Offset: 0x0003E281
	private void Awake()
	{
		this.mInput = base.GetComponent<UIInput>();
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x0004008F File Offset: 0x0003E28F
	private void OnGUI()
	{
		if (Event.current.rawType == EventType.KeyDown)
		{
			this.mInput.ProcessEvent(Event.current);
		}
	}

	// Token: 0x040006ED RID: 1773
	[NonSerialized]
	private UIInput mInput;
}
