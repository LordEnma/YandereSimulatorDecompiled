using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B2 RID: 1458
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x060024CD RID: 9421 RVA: 0x00200D77 File Offset: 0x001FEF77
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x060024CE RID: 9422 RVA: 0x00200D85 File Offset: 0x001FEF85
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x00200D98 File Offset: 0x001FEF98
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

		// Token: 0x04004D2E RID: 19758
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004D2F RID: 19759
		public SceneObject targetScene;

		// Token: 0x04004D30 RID: 19760
		[HideInInspector]
		public int index;

		// Token: 0x04004D31 RID: 19761
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004D32 RID: 19762
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006EC RID: 1772
		public enum ButtonType
		{
			// Token: 0x040052A2 RID: 21154
			Start,
			// Token: 0x040052A3 RID: 21155
			Controls,
			// Token: 0x040052A4 RID: 21156
			Credits,
			// Token: 0x040052A5 RID: 21157
			Exit,
			// Token: 0x040052A6 RID: 21158
			Easy,
			// Token: 0x040052A7 RID: 21159
			Medium,
			// Token: 0x040052A8 RID: 21160
			Hard
		}
	}
}
