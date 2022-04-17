using System;
using UnityEngine;

// Token: 0x02000040 RID: 64
[RequireComponent(typeof(UIWidget))]
[AddComponentMenu("NGUI/Interaction/Envelop Content")]
public class EnvelopContent : MonoBehaviour
{
	// Token: 0x060000FE RID: 254 RVA: 0x0001326F File Offset: 0x0001146F
	private void Start()
	{
		this.mStarted = true;
		this.Execute();
	}

	// Token: 0x060000FF RID: 255 RVA: 0x0001327E File Offset: 0x0001147E
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.Execute();
		}
	}

	// Token: 0x06000100 RID: 256 RVA: 0x00013290 File Offset: 0x00011490
	[ContextMenu("Execute")]
	public void Execute()
	{
		if (this.targetRoot == base.transform)
		{
			Debug.LogError("Target Root object cannot be the same object that has Envelop Content. Make it a sibling instead.", this);
			return;
		}
		if (NGUITools.IsChild(this.targetRoot, base.transform))
		{
			Debug.LogError("Target Root object should not be a parent of Envelop Content. Make it a sibling instead.", this);
			return;
		}
		Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(base.transform.parent, this.targetRoot, !this.ignoreDisabled, true);
		float num = bounds.min.x + (float)this.padLeft;
		float num2 = bounds.min.y + (float)this.padBottom;
		float num3 = bounds.max.x + (float)this.padRight;
		float num4 = bounds.max.y + (float)this.padTop;
		base.GetComponent<UIWidget>().SetRect(num, num2, num3 - num, num4 - num2);
		base.BroadcastMessage("UpdateAnchors", SendMessageOptions.DontRequireReceiver);
		NGUITools.UpdateWidgetCollider(base.gameObject);
	}

	// Token: 0x040002CE RID: 718
	public Transform targetRoot;

	// Token: 0x040002CF RID: 719
	public int padLeft;

	// Token: 0x040002D0 RID: 720
	public int padRight;

	// Token: 0x040002D1 RID: 721
	public int padBottom;

	// Token: 0x040002D2 RID: 722
	public int padTop;

	// Token: 0x040002D3 RID: 723
	public bool ignoreDisabled = true;

	// Token: 0x040002D4 RID: 724
	private bool mStarted;
}
