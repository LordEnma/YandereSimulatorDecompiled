using System;
using UnityEngine;

namespace MaidDereMinigame
{
	public class Bubble : MonoBehaviour
	{
		[HideInInspector]
		public Food food;

		public SpriteRenderer foodRenderer;

		private void Awake()
		{
			foodRenderer.sprite = null;
		}

		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(Pause));
		}

		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(Pause));
		}

		public void Pause(bool toPause)
		{
			if (toPause)
			{
				GetComponent<SpriteRenderer>().enabled = false;
				foodRenderer.gameObject.SetActive(value: false);
			}
			else
			{
				GetComponent<SpriteRenderer>().enabled = true;
				foodRenderer.gameObject.SetActive(value: true);
			}
		}

		public void BubbleReachedMax()
		{
			foodRenderer.gameObject.SetActive(value: true);
			foodRenderer.sprite = food.largeSprite;
		}

		public void BubbleClosing()
		{
			foodRenderer.gameObject.SetActive(value: false);
		}

		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
