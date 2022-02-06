using System;
using UnityEngine;

// Token: 0x02000053 RID: 83
[AddComponentMenu("NGUI/Interaction/Drag Scroll View")]
public class UIDragScrollView : MonoBehaviour
{
	// Token: 0x06000197 RID: 407 RVA: 0x000169BC File Offset: 0x00014BBC
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

	// Token: 0x06000198 RID: 408 RVA: 0x00016A28 File Offset: 0x00014C28
	private void Start()
	{
		this.mStarted = true;
		this.FindScrollView();
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00016A38 File Offset: 0x00014C38
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

	// Token: 0x0600019A RID: 410 RVA: 0x00016AA6 File Offset: 0x00014CA6
	private void OnDisable()
	{
		if (this.mPressed && this.mScroll != null && this.mScroll.GetComponentInChildren<UIWrapContent>() == null)
		{
			this.mScroll.Press(false);
			this.mScroll = null;
		}
	}

	// Token: 0x0600019B RID: 411 RVA: 0x00016AE4 File Offset: 0x00014CE4
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

	// Token: 0x0600019C RID: 412 RVA: 0x00016B7C File Offset: 0x00014D7C
	private void OnDrag(Vector2 delta)
	{
		if (this.scrollView && NGUITools.GetActive(this))
		{
			this.scrollView.Drag();
		}
	}

	// Token: 0x0600019D RID: 413 RVA: 0x00016B9E File Offset: 0x00014D9E
	private void OnScroll(float delta)
	{
		if (this.scrollView && NGUITools.GetActive(this))
		{
			this.scrollView.Scroll(delta);
		}
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00016BC1 File Offset: 0x00014DC1
	public void OnPan(Vector2 delta)
	{
		if (this.scrollView && NGUITools.GetActive(this))
		{
			this.scrollView.OnPan(delta);
		}
	}

	// Token: 0x04000351 RID: 849
	public UIScrollView scrollView;

	// Token: 0x04000352 RID: 850
	[HideInInspector]
	[SerializeField]
	private UIScrollView draggablePanel;

	// Token: 0x04000353 RID: 851
	private Transform mTrans;

	// Token: 0x04000354 RID: 852
	private UIScrollView mScroll;

	// Token: 0x04000355 RID: 853
	private bool mAutoFind;

	// Token: 0x04000356 RID: 854
	private bool mStarted;

	// Token: 0x04000357 RID: 855
	[NonSerialized]
	private bool mPressed;
}
