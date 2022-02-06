using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		// Token: 0x06002480 RID: 9344 RVA: 0x001FABA7 File Offset: 0x001F8DA7
		public void Init()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x001FABB5 File Offset: 0x001F8DB5
		private void OnMouseEnter()
		{
			this.menu.SetActiveMenuButton(this.index);
		}

		// Token: 0x06002482 RID: 9346 RVA: 0x001FABC8 File Offset: 0x001F8DC8
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

		// Token: 0x04004C51 RID: 19537
		public MenuButton.ButtonType buttonType;

		// Token: 0x04004C52 RID: 19538
		public SceneObject targetScene;

		// Token: 0x04004C53 RID: 19539
		[HideInInspector]
		public int index;

		// Token: 0x04004C54 RID: 19540
		[HideInInspector]
		public Menu menu;

		// Token: 0x04004C55 RID: 19541
		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		// Token: 0x020006DD RID: 1757
		public enum ButtonType
		{
			// Token: 0x040051C0 RID: 20928
			Start,
			// Token: 0x040051C1 RID: 20929
			Controls,
			// Token: 0x040051C2 RID: 20930
			Credits,
			// Token: 0x040051C3 RID: 20931
			Exit,
			// Token: 0x040051C4 RID: 20932
			Easy,
			// Token: 0x040051C5 RID: 20933
			Medium,
			// Token: 0x040051C6 RID: 20934
			Hard
		}
	}
}
