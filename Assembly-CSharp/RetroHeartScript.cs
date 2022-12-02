using UnityEngine;

public class RetroHeartScript : MonoBehaviour
{
	public RetroMinigameScript RetroMinigame;

	private void OnTriggerEnter(Collider other)
	{
		RetroMinigame.GameOverGraphic.SetActive(true);
		RetroMinigame.GameOver = true;
	}
}
