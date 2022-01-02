using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A1 RID: 1441
	public class Menu : MonoBehaviour
	{
		// Token: 0x06002465 RID: 9317 RVA: 0x001F854C File Offset: 0x001F674C
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

		// Token: 0x06002466 RID: 9318 RVA: 0x001F85D0 File Offset: 0x001F67D0
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

		// Token: 0x06002467 RID: 9319 RVA: 0x001F8710 File Offset: 0x001F6910
		public void SetActiveMenuButton(int index)
		{
			if (this.activeMenuButton != null)
			{
				this.activeMenuButton.spriteRenderer.enabled = false;
			}
			this.activeMenuButton = this.mainMenuButtons[index];
			this.activeMenuButton.spriteRenderer.enabled = true;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001F875F File Offset: 0x001F695F
		public void StopInputs()
		{
			this.cancelInputs = true;
			this.flipBook.StopInputs();
		}

		// Token: 0x04004C1C RID: 19484
		public List<MenuButton> mainMenuButtons;

		// Token: 0x04004C1D RID: 19485
		[HideInInspector]
		public FlipBook flipBook;

		// Token: 0x04004C1E RID: 19486
		private MenuButton activeMenuButton;

		// Token: 0x04004C1F RID: 19487
		private bool prevVertical;

		// Token: 0x04004C20 RID: 19488
		private bool cancelInputs;

		// Token: 0x04004C21 RID: 19489
		private float PreviousFrameVertical;
	}
}
