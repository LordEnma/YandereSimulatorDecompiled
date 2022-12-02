using UnityEngine;

namespace MaidDereMinigame
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class MenuButton : MonoBehaviour
	{
		public enum ButtonType
		{
			Start = 0,
			Controls = 1,
			Credits = 2,
			Exit = 3,
			Easy = 4,
			Medium = 5,
			Hard = 6
		}

		public ButtonType buttonType;

		public SceneObject targetScene;

		[HideInInspector]
		public int index;

		[HideInInspector]
		public Menu menu;

		[HideInInspector]
		public SpriteRenderer spriteRenderer;

		public void Init()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void OnMouseEnter()
		{
			menu.SetActiveMenuButton(index);
		}

		public void DoClick()
		{
			switch (buttonType)
			{
			case ButtonType.Start:
				menu.flipBook.FlipToPage(2);
				break;
			case ButtonType.Controls:
				menu.flipBook.FlipToPage(3);
				break;
			case ButtonType.Credits:
				menu.flipBook.FlipToPage(4);
				break;
			case ButtonType.Exit:
				menu.StopInputs();
				GameController.GoToExitScene();
				break;
			case ButtonType.Easy:
				menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.easyVariables;
				GameController.Instance.LoadScene(targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				break;
			case ButtonType.Medium:
				menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.mediumVariables;
				GameController.Instance.LoadScene(targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				break;
			case ButtonType.Hard:
				menu.StopInputs();
				GameController.Instance.activeDifficultyVariables = GameController.Instance.hardVariables;
				GameController.Instance.LoadScene(targetScene);
				SFXController.PlaySound(SFXController.Sounds.MenuConfirm);
				break;
			}
		}
	}
}
