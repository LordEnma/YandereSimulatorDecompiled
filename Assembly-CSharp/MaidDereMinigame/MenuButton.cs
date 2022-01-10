using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A4 RID: 1444
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x06002475 RID: 9333 RVA: 0x001F911B File Offset: 0x001F731B
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002476 RID: 9334 RVA: 0x001F9129 File Offset: 0x001F7329
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x06002477 RID: 9335 RVA: 0x001F913C File Offset: 0x001F733C
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

		// Token: 0x04004C36 RID: 19510
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004C37 RID: 19511
		public SceneObject targetScene;

		// Token: 0x04004C38 RID: 19512
		[HideInInspector]
		public int index;

		// Token: 0x04004C39 RID: 19513
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004C3A RID: 19514
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006E2 RID: 1762
		public enum ButtonType
		{
			// Token: 0x040051D3 RID: 20947
			Start,
			// Token: 0x040051D4 RID: 20948
			Controls,
			// Token: 0x040051D5 RID: 20949
			Credits,
			// Token: 0x040051D6 RID: 20950
			Exit,
			// Token: 0x040051D7 RID: 20951
			Easy,
			// Token: 0x040051D8 RID: 20952
			Medium,
			// Token: 0x040051D9 RID: 20953
			Hard
		}
	}
}
