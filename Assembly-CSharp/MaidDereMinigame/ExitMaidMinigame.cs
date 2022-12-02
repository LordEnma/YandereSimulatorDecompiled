using UnityEngine;

namespace MaidDereMinigame
{
	public class ExitMaidMinigame : MonoBehaviour
	{
		private void OnMouseOver()
		{
			if (Input.GetMouseButtonDown(0))
			{
				GameController.GoToExitScene();
			}
		}
	}
}
