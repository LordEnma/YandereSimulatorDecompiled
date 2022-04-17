using System;
using UnityEngine;

// Token: 0x02000053 RID: 83
[AddComponentMenu("NGUI/Interaction/Drag Scroll View")]
public class UIDragScrollView : MonoBehaviour
{
	// Token: 0x06000197 RID: 407 RVA: 0x00016B6C File Offset: 0x00014D6C
	private void OnEnable()
	{
		this.mTrans = base.transform;
		if (this.scrollView == null && this.draggablePanel != null)
		{
			this.scrollView = this.draggablePanel;
			this.draggablePanel = null;
		}
		if (this.mStarted && (this.mAutoFind || this.mScroll == null))
		{
			this.FindScrollView();
		}
	}

	// Token: 0x06000198 RID: 408 RVA: 0x00016BD8 File Offset: 0x00014DD8
	private void Start()
	{
		this.mStarted = true;
		this.FindScrollView();
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00016BE8 File Offset: 0x00014DE8
	private void FindScrollView()
	{
		UIScrollView uiscrollView = NGUITools.FindInParents<UIScrollView>(this.mTrans);
		if (this.scrollView == null || (this.mAutoFind && uiscrollView != this.scrollView))
		{
			this.scrollView = uiscrollView;
			this.mAutoFind = true;
		}
		else if (this.scrollView == uiscrollView)
		{
			this.mAutoFind = true;
		}
		this.mScroll = this.scrollView;
	}

	// Token: 0x0600019A RID: 410 RVA: 0x00016C56 File Offset: 0x00014E56
	private void OnDisable()
	{
		if (this.mPressed && this.mScroll != null && this.mScroll.GetComponentInChildren<UIWrapContent>() == null)
		{
			this.mScroll.Press(false);
			this.mScroll = null;
		}
	}

	// Token: 0x0600019B RID: 411 RVA: 0x00016C94 File Offset: 0x00014E94
	private void OnPress(bool pressed)
	{
		this.mPressed = pressed;
		if (this.mAutoFind && this.mScroll != this.scrollView)
		{
			this.mScroll = this.scrollView;
			this.mAutoFind = false;
		}
		if (this.scrollView && base.enabled && NGUITools.GetActive(base.gameObject))
		{
			this.scrollView.Press(pressed);
			if (!pressed && this.mAutoFind)
			{
				this.scrollView = NGUITools.FindInParents<UIScrollView>(this.mTrans);
				this.mScroll = this.scrollView;
			}
		}
	}

	// Token: 0x0600019C RID: 412 RVA: 0x00016D2C File Offset: 0x00014F2C
	private void OnDrag(Vector2 delta)
	{
		if (this.scrollView && NGUITools.GetActive(this))
		{
			this.scrollView.Drag();
		}
	}

	// Token: 0x0600019D RID: 413 RVA: 0x00016D4E File Offset: 0x00014F4E
	private void OnScroll(float delta)
	{
		if (this.scrollView && NGUITools.GetActive(this))
		{
			this.scrollView.Scroll(delta);
		}
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00016D71 File Offset: 0x00014F71
	public void OnPan(Vector2 delta)
	{
		if (this.scrollView && NGUITools.GetActive(this))
		{
			this.scrollView.OnPan(delta);
		}
	}

	// Token: 0x0400035A RID: 858
	public UIScrollView scrollView;

	// Token: 0x0400035B RID: 859
	[HideInInspector]
	[SerializeField]
	private UIScrollView draggablePanel;

	// Token: 0x0400035C RID: 860
	private Transform mTrans;

	// Token: 0x0400035D RID: 861
	private UIScrollView mScroll;

	// Token: 0x0400035E RID: 862
	private bool mAutoFind;

	// Token: 0x0400035F RID: 863
	private bool mStarted;

	// Token: 0x04000360 RID: 864
	[NonSerialized]
	private bool mPressed;
}
