using System;
using UnityEngine;

// Token: 0x0200002D RID: 45
[RequireComponent(typeof(UIInput))]
[AddComponentMenu("NGUI/Examples/Chat Input")]
public class ChatInput : MonoBehaviour
{
	// Token: 0x060000C3 RID: 195 RVA: 0x00012278 File Offset: 0x00010478
	private void Start()
	{
		this.mInput = base.GetComponent<UIInput>();
		this.mInput.label.maxLineCount = 1;
		if (this.fillWithDummyData && this.textList != null)
		{
			for (int i = 0; i < 30; i++)
			{
				this.textList.Add(((i % 2 == 0) ? "[FFFFFF]" : "[AAAAAA]") + "This is an example paragraph for the text list, testing line " + i.ToString() + "[-]");
			}
		}
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x000122F8 File Offset: 0x000104F8
	public void OnSubmit()
	{
		if (this.textList != null)
		{
			string text = NGUIText.StripSymbols(this.mInput.value);
			if (!string.IsNullOrEmpty(text))
			{
				this.textList.Add(text);
				this.mInput.value = "";
				this.mInput.isSelected = false;
			}
		}
	}

	// Token: 0x0400028D RID: 653
	public UITextList textList;

	// Token: 0x0400028E RID: 654
	public bool fillWithDummyData;

	// Token: 0x0400028F RID: 655
	private UIInput mInput;
}
