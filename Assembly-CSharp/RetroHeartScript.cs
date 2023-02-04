using UnityEngine;

public class RetroHeartScript : MonoBehaviour
{
	public RetroMinigameScript RetroMinigame;

	private void OnTriggerEnter(Collider other)
	{
		RetroMinigame.GameOverGraphic.SetActive(value: true);
		RetroMinigame.GameOver = true;
	}
}
