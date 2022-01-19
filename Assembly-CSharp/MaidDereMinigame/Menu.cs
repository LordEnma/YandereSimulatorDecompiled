using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A4 RID: 1444
	public class Menu : MonoBehaviour
	{
		// Token: 0x06002472 RID: 9330 RVA: 0x001F9BBC File Offset: 0x001F7DBC
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

		// Token: 0x06002473 RID: 9331 RVA: 0x001F9C40 File Offset: 0x001F7E40
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

		// Token: 0x06002474 RID: 9332 RVA: 0x001F9D80 File Offset: 0x001F7F80
		public void SetActiveMenuButton(int index)
		{
			if (this.activeMenuButton != null)
			{
				this.activeMenuButton.spriteRenderer.enabled = false;
			}
			this.activeMenuButton = this.mainMenuButtons[index];
			this.activeMenuButton.spriteRenderer.enabled = true;
		}

		// Token: 0x06002475 RID: 9333 RVA: 0x001F9DCF File Offset: 0x001F7FCF
		public void StopInputs()
		{
			this.cancelInputs = true;
			this.flipBook.StopInputs();
		}

		// Token: 0x04004C37 RID: 19511
		public List<MenuButton> mainMenuButtons;

		// Token: 0x04004C38 RID: 19512
		[HideInInspector]
		public FlipBook flipBook;

		// Token: 0x04004C39 RID: 19513
		private MenuButton activeMenuButton;

		// Token: 0x04004C3A RID: 19514
		private bool prevVertical;

		// Token: 0x04004C3B RID: 19515
		private bool cancelInputs;

		// Token: 0x04004C3C RID: 19516
		private float PreviousFrameVertical;
	}
}
