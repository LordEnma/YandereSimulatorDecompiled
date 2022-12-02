using System;
using UnityEngine;

namespace MaidDereMinigame
{
	public class Timer : Meter
	{
		private GameStarter starter;

		private float gameTime;

		private bool isPaused;

		private void Awake()
		{
			gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
			starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			isPaused = true;
		}

		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(SetPause));
		}

		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(SetPause));
		}

		public void SetPause(bool toPause)
		{
			isPaused = toPause;
		}

		private void Update()
		{
			if (!isPaused)
			{
				gameTime -= Time.deltaTime;
				SetFill(gameTime / GameController.Instance.activeDifficultyVariables.gameTime);
				starter.SetGameTime(gameTime);
			}
		}
	}
}
