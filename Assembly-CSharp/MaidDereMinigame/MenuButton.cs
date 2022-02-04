using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x0600247D RID: 9341 RVA: 0x001FA9A3 File Offset: 0x001F8BA3
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x001FA9B1 File Offset: 0x001F8BB1
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x0600247F RID: 9343 RVA: 0x001FA9C4 File Offset: 0x001F8BC4
		public void DoClick()
		{
			switch (this.buttonType)
			{
			case MenuButton.ButtonType.Start:
				this.menu.flipBook.FlipToPage(2);
				return;
			case MenuButton.ButtonType.Controls:
				this.menu.flipBook.FlipToPage(3);
				return;
			case MenuButton.ButtonType.Credits:
				this.menu.flipBook.FlipToPage(4);
				return;
			case MenuButton.ButtonType.Exit:
				this.menu.StopInputs();
				GameController.GoToExitScene(true);
				return;
			case MenuButton.ButtonType.Easy:
				this.menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.easyVariables;
				GameController.Instance.LoadScene(this.targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				return;
			case MenuButton.ButtonType.Medium:
				this.menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.mediumVariables;
				GameController.Instance.LoadScene(this.targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				return;
			case MenuButton.ButtonType.Hard:
				this.menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.hardVariables;
				GameController.Instance.LoadScene(this.targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				return;
			default:
				return;
			}
		}

		// Token: 0x04004C4E RID: 19534
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004C4F RID: 19535
		public SceneObject targetScene;

		// Token: 0x04004C50 RID: 19536
		[HideInInspector]
		public int index;

		// Token: 0x04004C51 RID: 19537
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004C52 RID: 19538
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006DD RID: 1757
		public enum ButtonType
		{
			// Token: 0x040051BD RID: 20925
			Start,
			// Token: 0x040051BE RID: 20926
			Controls,
			// Token: 0x040051BF RID: 20927
			Credits,
			// Token: 0x040051C0 RID: 20928
			Exit,
			// Token: 0x040051C1 RID: 20929
			Easy,
			// Token: 0x040051C2 RID: 20930
			Medium,
			// Token: 0x040051C3 RID: 20931
			Hard
		}
	}
}
