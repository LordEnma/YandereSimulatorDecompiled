using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	public class GameStarter : MonoBehaviour
	{
		public List<Sprite> numbers;

		public SpriteRenderer whiteFadeOutPost;

		public Sprite timeUp;

		public TipPage tipPage;

		private AudioSource audioSource;

		private SpriteRenderer spriteRenderer;

		private int timeToStart = 3;

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			audioSource = GetComponent<AudioSource>();
			StartCoroutine(CountdownToStart());
			GameController.Instance.tipPage = tipPage;
			GameController.Instance.whiteFadeOutPost = whiteFadeOutPost;
		}

		public void SetGameTime(float gameTime)
		{
			int num = Mathf.CeilToInt(gameTime);
			if ((float)num == 10f)
			{
				SFXController.PlaySound(SFXController.Sounds.ClockTick);
			}
			if (!(gameTime > 3f))
			{
				if ((uint)(num - 1) <= 2u)
				{
					spriteRenderer.sprite = numbers[num];
				}
				else
				{
					EndGame();
				}
			}
		}

		public void EndGame()
		{
			StartCoroutine(EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		private IEnumerator CountdownToStart()
		{
			yield return new WaitForSeconds(GameController.Instance.activeDifficultyVariables.transitionTime);
			SFXController.PlaySound(SFXController.Sounds.Countdown);
			while (timeToStart > 0)
			{
				yield return new WaitForSeconds(1f);
				timeToStart--;
				spriteRenderer.sprite = numbers[timeToStart];
			}
			yield return new WaitForSeconds(1f);
			GameController.SetPause(false);
			spriteRenderer.sprite = null;
		}

		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			spriteRenderer.sprite = timeUp;
			yield return new WaitForSeconds(1f);
			Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
		}

		public void SetAudioPitch(float value)
		{
			audioSource.pitch = value;
		}
	}
}
