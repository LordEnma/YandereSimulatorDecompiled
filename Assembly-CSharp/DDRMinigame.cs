using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class DDRMinigame : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<KeyValuePair<DDRRating, int>, int> _003C_003E9__37_0;

		public static Comparison<float> _003C_003E9__39_0;

		public static Comparison<float> _003C_003E9__40_0;

		internal int _003CregisterRating_003Eb__37_0(KeyValuePair<DDRRating, int> x)
		{
			return x.Value;
		}

		internal int _003CremoveNodeAt_003Eb__39_0(float a, float b)
		{
			return a.CompareTo(b);
		}

		internal int _003CgetFirstNodeOn_003Eb__40_0(float a, float b)
		{
			return a.CompareTo(b);
		}
	}

	[Header("General")]
	[SerializeField]
	private DDRManager manager;

	[SerializeField]
	private InputManagerScript inputManager;

	[Header("Level select")]
	[SerializeField]
	private GameObject levelIconPrefab;

	[SerializeField]
	private RectTransform levelSelectParent;

	[SerializeField]
	private Text levelNameLabel;

	private DDRLevel[] levels;

	[Header("Gameplay")]
	[SerializeField]
	private Text comboText;

	[SerializeField]
	private Text longestComboText;

	[SerializeField]
	private Text rankText;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private Image healthImage;

	[SerializeField]
	private GameObject arrowPrefab;

	[SerializeField]
	private GameObject ratingTextPrefab;

	[SerializeField]
	private RectTransform gameplayUiParent;

	[SerializeField]
	public RectTransform[] uiTracks;

	[SerializeField]
	private Vector2 offset;

	[SerializeField]
	private float speed;

	[Header("Colors")]
	[SerializeField]
	private Color perfectColor;

	[SerializeField]
	private Color greatColor;

	[SerializeField]
	private Color goodColor;

	[SerializeField]
	private Color okColor;

	[SerializeField]
	private Color earlyColor;

	private float levelSelectScroll;

	private int selectedLevel;

	private Dictionary<RectTransform, DDRLevel> levelSelectCache;

	private Dictionary<float, RectTransform>[] trackCache;

	public void LoadLevel(DDRLevel level)
	{
		gameplayUiParent.anchoredPosition = Vector2.zero;
		gameplayUiParent.rotation = Quaternion.identity;
		trackCache = new Dictionary<float, RectTransform>[4];
		for (int i = 0; i < trackCache.Length; i++)
		{
			trackCache[i] = new Dictionary<float, RectTransform>();
			foreach (float node in level.Tracks[i].Nodes)
			{
				RectTransform component = UnityEngine.Object.Instantiate(arrowPrefab, uiTracks[i]).GetComponent<RectTransform>();
				switch (i)
				{
				case 0:
					component.rotation = Quaternion.Euler(0f, 0f, 90f);
					break;
				case 1:
					component.rotation = Quaternion.Euler(0f, 0f, 180f);
					break;
				case 2:
					component.rotation = Quaternion.Euler(0f, 0f, 0f);
					break;
				case 3:
					component.rotation = Quaternion.Euler(0f, 0f, -90f);
					break;
				}
				trackCache[i].Add(node, component);
			}
		}
	}

	public void LoadLevelSelect(DDRLevel[] levels)
	{
		levelSelectCache = new Dictionary<RectTransform, DDRLevel>();
		this.levels = levels;
		for (int i = 0; i < levels.Length; i++)
		{
			RectTransform component = UnityEngine.Object.Instantiate(levelIconPrefab, levelSelectParent).GetComponent<RectTransform>();
			component.GetComponent<Image>().sprite = levels[i].LevelIcon;
			levelSelectCache.Add(component, levels[i]);
		}
		positionLevels(true);
	}

	public void UnloadLevelSelect()
	{
		foreach (KeyValuePair<RectTransform, DDRLevel> item in levelSelectCache)
		{
			UnityEngine.Object.Destroy(item.Key.gameObject);
		}
		levelSelectCache = new Dictionary<RectTransform, DDRLevel>();
	}

	public void UpdateLevelSelect()
	{
		if (inputManager.TappedLeft)
		{
			levelSelectScroll -= 1f;
		}
		else if (inputManager.TappedRight)
		{
			levelSelectScroll += 1f;
		}
		levelSelectScroll = Mathf.Clamp(levelSelectScroll, 0f, levels.Length - 1);
		selectedLevel = (int)Mathf.Round(levelSelectScroll);
		positionLevels();
		if (Input.GetButtonDown("A"))
		{
			manager.LoadedLevel = levels[selectedLevel];
		}
		if (Input.GetButtonDown("B"))
		{
			manager.BootOut();
		}
	}

	private void positionLevels(bool instant = false)
	{
		for (int i = 0; i < levelSelectCache.Keys.Count; i++)
		{
			RectTransform key = levelSelectCache.ElementAt(i).Key;
			Vector2 vector = new Vector2(-selectedLevel * 400 + i * 400, 0f);
			key.anchoredPosition = (instant ? vector : Vector2.Lerp(key.anchoredPosition, vector, 10f * Time.deltaTime));
			levelNameLabel.text = levels[selectedLevel].LevelName;
		}
	}

	public void UpdateGame(float time)
	{
		if (trackCache == null)
		{
			return;
		}
		bool flag = manager.GameState.FinishStatus == DDRFinishStatus.Failed;
		if (!flag)
		{
			pollInput(time);
			gameplayUiParent.anchoredPosition = Vector2.Lerp(gameplayUiParent.anchoredPosition, Vector2.zero, 10f * Time.deltaTime);
			gameplayUiParent.rotation = Quaternion.identity;
		}
		else
		{
			gameplayUiParent.anchoredPosition += Vector2.down * 50f * Time.deltaTime;
			gameplayUiParent.Rotate(Vector3.forward * -2f * Time.deltaTime);
			shakeUi(0.5f);
		}
		healthImage.fillAmount = Mathf.Lerp(healthImage.fillAmount, manager.GameState.Health / 100f, 10f * Time.deltaTime);
		for (int i = 0; i < trackCache.Length; i++)
		{
			Dictionary<float, RectTransform> dictionary = trackCache[i];
			foreach (float key in dictionary.Keys)
			{
				float num = key - time;
				if (num < -0.05f)
				{
					if (!flag)
					{
						displayHitRating(i, DDRRating.Miss);
					}
					assignPoints(DDRRating.Miss);
					updateCombo(DDRRating.Miss);
					removeNodeAt(trackCache.ToList().IndexOf(dictionary));
					return;
				}
				if (dictionary[key] != null)
				{
					dictionary[key].anchoredPosition = new Vector2(0f, (0f - num) * speed) + offset;
				}
			}
		}
	}

	public void UpdateEndcard(GameState state)
	{
		scoreText.text = string.Format("Score: {0}", state.Score);
		Color resultColor;
		rankText.text = getRank(state, out resultColor);
		rankText.color = resultColor;
		longestComboText.text = string.Format("Biggest combo: {0}", state.LongestCombo.ToString());
	}

	private DDRRating getRating(int track, float time)
	{
		float time2;
		RectTransform rect;
		getFirstNodeOn(track, out time2, out rect);
		DDRRating result = DDRRating.Miss;
		float num = offset.y - rect.localPosition.y;
		if (num < 130f)
		{
			result = DDRRating.Early;
			if (num < 75f)
			{
				result = DDRRating.Ok;
			}
			if (num < 65f)
			{
				result = DDRRating.Good;
			}
			if (num < 50f)
			{
				result = DDRRating.Great;
			}
			if (num < 30f)
			{
				result = DDRRating.Perfect;
			}
			if (num < -30f)
			{
				result = DDRRating.Ok;
			}
			if (num < -130f)
			{
				result = DDRRating.Miss;
			}
		}
		return result;
	}

	private string getRank(GameState state, out Color resultColor)
	{
		string result = "F";
		int num = 0;
		int perfectScorePoints = manager.LoadedLevel.PerfectScorePoints;
		DDRTrack[] tracks = manager.LoadedLevel.Tracks;
		foreach (DDRTrack dDRTrack in tracks)
		{
			num += dDRTrack.Nodes.Count * perfectScorePoints;
		}
		float num2 = (float)state.Score / (float)num * 100f;
		if (num2 >= 30f)
		{
			result = "D";
		}
		if (num2 >= 50f)
		{
			result = "C";
		}
		if (num2 >= 75f)
		{
			result = "B";
		}
		if (num2 >= 80f)
		{
			result = "A";
		}
		if (num2 >= 95f)
		{
			result = "S";
		}
		if (num2 >= 100f)
		{
			result = "S+";
		}
		resultColor = Color.Lerp(Color.red, Color.green, num2 / 100f);
		return result;
	}

	private void pollInput(float time)
	{
		if (inputManager.TappedLeft)
		{
			registerKeypress(0, time);
		}
		if (inputManager.TappedDown)
		{
			registerKeypress(1, time);
		}
		if (inputManager.TappedUp)
		{
			registerKeypress(2, time);
		}
		if (inputManager.TappedRight)
		{
			registerKeypress(3, time);
		}
	}

	private void registerKeypress(int track, float time)
	{
		DDRRating rating = getRating(track, time);
		displayHitRating(track, rating);
		assignPoints(rating);
		registerRating(rating);
		updateCombo(rating);
		if (rating != DDRRating.Miss)
		{
			removeNodeAt(track);
		}
	}

	private void registerRating(DDRRating rating)
	{
		manager.GameState.Ratings[rating]++;
		manager.GameState.Ratings.OrderBy(_003C_003Ec._003C_003E9__37_0 ?? (_003C_003Ec._003C_003E9__37_0 = _003C_003Ec._003C_003E9._003CregisterRating_003Eb__37_0));
	}

	private void updateCombo(DDRRating rating)
	{
		comboText.text = "";
		comboText.color = Color.white;
		comboText.GetComponent<Animation>().Play();
		if (rating != DDRRating.Miss && rating != DDRRating.Early)
		{
			manager.GameState.Combo++;
			if (manager.GameState.Combo > manager.GameState.LongestCombo)
			{
				manager.GameState.LongestCombo = manager.GameState.Combo;
				comboText.color = Color.yellow;
			}
			if (manager.GameState.Combo >= 2)
			{
				comboText.text = string.Format("x{0} combo", manager.GameState.Combo);
				comboText.color = Color.white;
			}
		}
		else
		{
			manager.GameState.Combo = 0;
		}
	}

	private void removeNodeAt(int trackId, float delay = 0f)
	{
		Dictionary<float, RectTransform> obj = trackCache[trackId];
		float[] array = obj.Keys.ToArray();
		Array.Sort(array, _003C_003Ec._003C_003E9__39_0 ?? (_003C_003Ec._003C_003E9__39_0 = _003C_003Ec._003C_003E9._003CremoveNodeAt_003Eb__39_0));
		UnityEngine.Object.Destroy(obj[array[0]].gameObject, delay);
		obj.Remove(array[0]);
	}

	private void getFirstNodeOn(int track, out float time, out RectTransform rect)
	{
		Dictionary<float, RectTransform> dictionary = trackCache[track];
		float[] array = dictionary.Keys.ToArray();
		Array.Sort(array, _003C_003Ec._003C_003E9__40_0 ?? (_003C_003Ec._003C_003E9__40_0 = _003C_003Ec._003C_003E9._003CgetFirstNodeOn_003Eb__40_0));
		time = array[0];
		rect = dictionary[time];
	}

	private void displayHitRating(int track, DDRRating rating)
	{
		Text component = UnityEngine.Object.Instantiate(ratingTextPrefab, uiTracks[track]).GetComponent<Text>();
		component.rectTransform.anchoredPosition = new Vector2(0f, 280f);
		switch (rating)
		{
		case DDRRating.Miss:
			component.text = "Miss";
			component.color = Color.red;
			shakeUi(5f);
			break;
		case DDRRating.Early:
			component.text = "Early";
			component.color = earlyColor;
			break;
		case DDRRating.Ok:
			component.text = "Ok";
			component.color = okColor;
			break;
		case DDRRating.Good:
			component.text = "Good";
			component.color = goodColor;
			break;
		case DDRRating.Great:
			component.text = "Great";
			component.color = greatColor;
			break;
		case DDRRating.Perfect:
			component.text = "Perfect";
			component.color = perfectColor;
			break;
		}
		UnityEngine.Object.Destroy(component, 1f);
	}

	private void assignPoints(DDRRating rating)
	{
		int num = 0;
		switch (rating)
		{
		case DDRRating.Early:
			num = manager.LoadedLevel.EarlyScorePoints;
			break;
		case DDRRating.Good:
			num = manager.LoadedLevel.GoodScorePoints;
			break;
		case DDRRating.Great:
			num = manager.LoadedLevel.GreatScorePoints;
			break;
		case DDRRating.Miss:
			num = manager.LoadedLevel.MissScorePoints;
			break;
		case DDRRating.Ok:
			num = manager.LoadedLevel.OkScorePoints;
			break;
		case DDRRating.Perfect:
			num = manager.LoadedLevel.PerfectScorePoints;
			break;
		}
		if (rating != DDRRating.Miss)
		{
			manager.GameState.Score += num;
		}
		manager.GameState.Health += num;
	}

	private void shakeUi(float factor)
	{
		Vector2 vector = new Vector2(UnityEngine.Random.Range(0f - factor, factor), UnityEngine.Random.Range(0f - factor, factor));
		gameplayUiParent.anchoredPosition += vector;
	}

	public void Unload()
	{
		UnloadLevelSelect();
	}
}
