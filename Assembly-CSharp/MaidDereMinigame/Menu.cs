using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A4 RID: 1444
	public class Menu : MonoBehaviour
	{
		// Token: 0x0600247B RID: 9339 RVA: 0x001FA978 File Offset: 0x001F8B78
		private void Start()
		{
			for (int i = 0; i < this.mainMenuButtons.Count; i++)
			{
				int index = i;
				this.mainMenuButtons[i].Init();
				this.mainMenuButtons[i].index = index;
				this.mainMenuButtons[i].spriteRenderer.enabled = false;
				this.mainMenuButtons[i].menu = this;
			}
			this.flipBook = FlipBook.Instance;
			this.SetActiveMenuButton(0);
		}

		// Token: 0x0600247C RID: 9340 RVA: 0x001FA9FC File Offset: 0x001F8BFC
		private void Update()
		{
			if (this.cancelInputs)
			{
				return;
			}
			if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("A")) && this.activeMenuButton != null)
			{
				this.activeMenuButton.DoClick();
			}
			float num = Input.GetAxisRaw("Vertical") * -1f;
			if (Input.GetKeyDown("up") || Input.GetAxis("DpadY") > 0.5f)
			{
				num = -1f;
			}
			else if (Input.GetKeyDown("down") || Input.GetAxis("DpadY") < -0.5f)
			{
				num = 1f;
			}
			if (num != 0f && this.PreviousFrameVertical == 0f)
			{
				SFXController.PlaySound(SFXController.Sounds.MenuSelect);
			}
			this.PreviousFrameVertical = num;
			if (num != 0f)
			{
				if (!this.prevVertical)
				{
					this.prevVertical = true;
					if (num >= 0f)
					{
						int num2 = this.mainMenuButtons.IndexOf(this.activeMenuButton);
						this.SetActiveMenuButton((num2 + 1) % this.mainMenuButtons.Count);
						return;
					}
					int num3 = this.mainMenuButtons.IndexOf(this.activeMenuButton);
					if (num3 == 0)
					{
						this.SetActiveMenuButton(this.mainMenuButtons.Count - 1);
						return;
					}
					this.SetActiveMenuButton(num3 - 1);
					return;
				}
			}
			else
			{
				this.prevVertical = false;
			}
		}

		// Token: 0x0600247D RID: 9341 RVA: 0x001FAB3C File Offset: 0x001F8D3C
		public void SetActiveMenuButton(int index)
		{
			if (this.activeMenuButton != null)
			{
				this.activeMenuButton.spriteRenderer.enabled = false;
			}
			this.activeMenuButton = this.mainMenuButtons[index];
			this.activeMenuButton.spriteRenderer.enabled = true;
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x001FAB8B File Offset: 0x001F8D8B
		public void StopInputs()
		{
			this.cancelInputs = true;
			this.flipBook.StopInputs();
		}

		// Token: 0x04004C4B RID: 19531
		public List<MenuButton> mainMenuButtons;

		// Token: 0x04004C4C RID: 19532
		[HideInInspector]
		public FlipBook flipBook;

		// Token: 0x04004C4D RID: 19533
		private MenuButton activeMenuButton;

		// Token: 0x04004C4E RID: 19534
		private bool prevVertical;

		// Token: 0x04004C4F RID: 19535
		private bool cancelInputs;

		// Token: 0x04004C50 RID: 19536
		private float PreviousFrameVertical;
	}
}
