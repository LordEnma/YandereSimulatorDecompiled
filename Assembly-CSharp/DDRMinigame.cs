using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000004 RID: 4
public class DDRMinigame : MonoBehaviour
{
	// Token: 0x0600000D RID: 13 RVA: 0x000026F4 File Offset: 0x000008F4
	public void LoadLevel(DDRLevel level)
	{
		this.gameplayUiParent.anchoredPosition = Vector2.zero;
		this.gameplayUiParent.rotation = Quaternion.identity;
		this.trackCache = new Dictionary<float, RectTransform>[4];
		for (int i = 0; i < this.trackCache.Length; i++)
		{
			this.trackCache[i] = new Dictionary<float, RectTransform>();
			foreach (float key in level.Tracks[i].Nodes)
			{
				RectTransform component = UnityEngine.Object.Instantiate<GameObject>(this.arrowPrefab, this.uiTracks[i]).GetComponent<RectTransform>();
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
				this.trackCache[i].Add(key, component);
			}
		}
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002850 File Offset: 0x00000A50
	public void LoadLevelSelect(DDRLevel[] levels)
	{
		this.levelSelectCache = new Dictionary<RectTransform, DDRLevel>();
		this.levels = levels;
		for (int i = 0; i < levels.Length; i++)
		{
			RectTransform component = UnityEngine.Object.Instantiate<GameObject>(this.levelIconPrefab, this.levelSelectParent).GetComponent<RectTransform>();
			component.GetComponent<Image>().sprite = levels[i].LevelIcon;
			this.levelSelectCache.Add(component, levels[i]);
		}
		this.positionLevels(true);
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000028C0 File Offset: 0x00000AC0
	public void UnloadLevelSelect()
	{
		foreach (KeyValuePair<RectTransform, DDRLevel> keyValuePair in this.levelSelectCache)
		{
			UnityEngine.Object.Destroy(keyValuePair.Key.gameObject);
		}
		this.levelSelectCache = new Dictionary<RectTransform, DDRLevel>();
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00002928 File Offset: 0x00000B28
	public void UpdateLevelSelect()
	{
		if (this.inputManager.TappedLeft)
		{
			this.levelSelectScroll -= 1f;
		}
		else if (this.inputManager.TappedRight)
		{
			this.levelSelectScroll += 1f;
		}
		this.levelSelectScroll = Mathf.Clamp(this.levelSelectScroll, 0f, (float)(this.levels.Length - 1));
		this.selectedLevel = (int)Mathf.Round(this.levelSelectScroll);
		this.positionLevels(false);
		if (Input.GetButtonDown("A"))
		{
			this.manager.LoadedLevel = this.levels[this.selectedLevel];
		}
		if (Input.GetButtonDown("B"))
		{
			this.manager.BootOut();
		}
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000029EC File Offset: 0x00000BEC
	private void positionLevels(bool instant = false)
	{
		for (int i = 0; i < this.levelSelectCache.Keys.Count; i++)
		{
			RectTransform key = this.levelSelectCache.ElementAt(i).Key;
			Vector2 vector = new Vector2((float)(-(float)this.selectedLevel * 400 + i * 400), 0f);
			key.anchoredPosition = (instant ? vector : Vector2.Lerp(key.anchoredPosition, vector, 10f * Time.deltaTime));
			this.levelNameLabel.text = this.levels[this.selectedLevel].LevelName;
		}
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00002A90 File Offset: 0x00000C90
	public void UpdateGame(float time)
	{
		if (this.trackCache == null)
		{
			return;
		}
		bool flag = this.manager.GameState.FinishStatus == DDRFinishStatus.Failed;
		if (!flag)
		{
			this.pollInput(time);
			this.gameplayUiParent.anchoredPosition = Vector2.Lerp(this.gameplayUiParent.anchoredPosition, Vector2.zero, 10f * Time.deltaTime);
			this.gameplayUiParent.rotation = Quaternion.identity;
		}
		else
		{
			this.gameplayUiParent.anchoredPosition += Vector2.down * 50f * Time.deltaTime;
			this.gameplayUiParent.Rotate(Vector3.forward * -2f * Time.deltaTime);
			this.shakeUi(0.5f);
		}
		this.healthImage.fillAmount = Mathf.Lerp(this.healthImage.fillAmount, this.manager.GameState.Health / 100f, 10f * Time.deltaTime);
		for (int i = 0; i < this.trackCache.Length; i++)
		{
			Dictionary<float, RectTransform> dictionary = this.trackCache[i];
			foreach (float num in dictionary.Keys)
			{
				float num2 = num - time;
				if (num2 < -0.05f)
				{
					if (!flag)
					{
						this.displayHitRating(i, DDRRating.Miss);
					}
					this.assignPoints(DDRRating.Miss);
					this.updateCombo(DDRRating.Miss);
					this.removeNodeAt(this.trackCache.ToList<Dictionary<float, RectTransform>>().IndexOf(dictionary), 0f);
					return;
				}
				dictionary[num].anchoredPosition = new Vector2(0f, -num2 * this.speed) + this.offset;
			}
		}
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002C74 File Offset: 0x00000E74
	public void UpdateEndcard(GameState state)
	{
		this.scoreText.text = string.Format("Score: {0}", state.Score);
		Color color;
		this.rankText.text = this.getRank(state, out color);
		this.rankText.color = color;
		this.longestComboText.text = string.Format("Biggest combo: {0}", state.LongestCombo.ToString());
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002CE4 File Offset: 0x00000EE4
	private DDRRating getRating(int track, float time)
	{
		float num;
		RectTransform rectTransform;
		this.getFirstNodeOn(track, out num, out rectTransform);
		DDRRating result = DDRRating.Miss;
		float num2 = this.offset.y - rectTransform.localPosition.y;
		if (num2 < 130f)
		{
			result = DDRRating.Early;
			if (num2 < 75f)
			{
				result = DDRRating.Ok;
			}
			if (num2 < 65f)
			{
				result = DDRRating.Good;
			}
			if (num2 < 50f)
			{
				result = DDRRating.Great;
			}
			if (num2 < 30f)
			{
				result = DDRRating.Perfect;
			}
			if (num2 < -30f)
			{
				result = DDRRating.Ok;
			}
			if (num2 < -130f)
			{
				result = DDRRating.Miss;
			}
		}
		return result;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002D60 File Offset: 0x00000F60
	private string getRank(GameState state, out Color resultColor)
	{
		string result = "F";
		int num = 0;
		int perfectScorePoints = this.manager.LoadedLevel.PerfectScorePoints;
		foreach (DDRTrack ddrtrack in this.manager.LoadedLevel.Tracks)
		{
			num += ddrtrack.Nodes.Count * perfectScorePoints;
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

	// Token: 0x06000016 RID: 22 RVA: 0x00002E48 File Offset: 0x00001048
	private void pollInput(float time)
	{
		if (this.inputManager.TappedLeft)
		{
			this.registerKeypress(0, time);
		}
		if (this.inputManager.TappedDown)
		{
			this.registerKeypress(1, time);
		}
		if (this.inputManager.TappedUp)
		{
			this.registerKeypress(2, time);
		}
		if (this.inputManager.TappedRight)
		{
			this.registerKeypress(3, time);
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002EAC File Offset: 0x000010AC
	private void registerKeypress(int track, float time)
	{
		DDRRating rating = this.getRating(track, time);
		this.displayHitRating(track, rating);
		this.assignPoints(rating);
		this.registerRating(rating);
		this.updateCombo(rating);
		if (rating != DDRRating.Miss)
		{
			this.removeNodeAt(track, 0f);
		}
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002EF0 File Offset: 0x000010F0
	private void registerRating(DDRRating rating)
	{
		Dictionary<DDRRating, int> ratings = this.manager.GameState.Ratings;
		ratings[rating]++;
		from x in this.manager.GameState.Ratings
		orderby x.Value
		select x;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002F58 File Offset: 0x00001158
	private void updateCombo(DDRRating rating)
	{
		this.comboText.text = "";
		this.comboText.color = Color.white;
		this.comboText.GetComponent<Animation>().Play();
		if (rating != DDRRating.Miss && rating != DDRRating.Early)
		{
			this.manager.GameState.Combo++;
			if (this.manager.GameState.Combo > this.manager.GameState.LongestCombo)
			{
				this.manager.GameState.LongestCombo = this.manager.GameState.Combo;
				this.comboText.color = Color.yellow;
			}
			if (this.manager.GameState.Combo >= 2)
			{
				this.comboText.text = string.Format("x{0} combo", this.manager.GameState.Combo);
				this.comboText.color = Color.white;
				return;
			}
		}
		else
		{
			this.manager.GameState.Combo = 0;
		}
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00003070 File Offset: 0x00001270
	private void removeNodeAt(int trackId, float delay = 0f)
	{
		Dictionary<float, RectTransform> dictionary = this.trackCache[trackId];
		float[] array = dictionary.Keys.ToArray<float>();
		Array.Sort<float>(array, (float a, float b) => a.CompareTo(b));
		UnityEngine.Object.Destroy(dictionary[array[0]].gameObject, delay);
		dictionary.Remove(array[0]);
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000030D4 File Offset: 0x000012D4
	private void getFirstNodeOn(int track, out float time, out RectTransform rect)
	{
		Dictionary<float, RectTransform> dictionary = this.trackCache[track];
		float[] array = dictionary.Keys.ToArray<float>();
		Array.Sort<float>(array, (float a, float b) => a.CompareTo(b));
		time = array[0];
		rect = dictionary[time];
	}

	// Token: 0x0600001C RID: 28 RVA: 0x0000312C File Offset: 0x0000132C
	private void displayHitRating(int track, DDRRating rating)
	{
		Text component = UnityEngine.Object.Instantiate<GameObject>(this.ratingTextPrefab, this.uiTracks[track]).GetComponent<Text>();
		component.rectTransform.anchoredPosition = new Vector2(0f, 280f);
		switch (rating)
		{
		case DDRRating.Perfect:
			component.text = "Perfect";
			component.color = this.perfectColor;
			break;
		case DDRRating.Great:
			component.text = "Great";
			component.color = this.greatColor;
			break;
		case DDRRating.Good:
			component.text = "Good";
			component.color = this.goodColor;
			break;
		case DDRRating.Ok:
			component.text = "Ok";
			component.color = this.okColor;
			break;
		case DDRRating.Miss:
			component.text = "Miss";
			component.color = Color.red;
			this.shakeUi(5f);
			break;
		case DDRRating.Early:
			component.text = "Early";
			component.color = this.earlyColor;
			break;
		}
		UnityEngine.Object.Destroy(component, 1f);
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00003238 File Offset: 0x00001438
	private void assignPoints(DDRRating rating)
	{
		int num = 0;
		switch (rating)
		{
		case DDRRating.Perfect:
			num = this.manager.LoadedLevel.PerfectScorePoints;
			break;
		case DDRRating.Great:
			num = this.manager.LoadedLevel.GreatScorePoints;
			break;
		case DDRRating.Good:
			num = this.manager.LoadedLevel.GoodScorePoints;
			break;
		case DDRRating.Ok:
			num = this.manager.LoadedLevel.OkScorePoints;
			break;
		case DDRRating.Miss:
			num = this.manager.LoadedLevel.MissScorePoints;
			break;
		case DDRRating.Early:
			num = this.manager.LoadedLevel.EarlyScorePoints;
			break;
		}
		if (rating != DDRRating.Miss)
		{
			this.manager.GameState.Score += num;
		}
		this.manager.GameState.Health += (float)num;
	}

	// Token: 0x0600001E RID: 30 RVA: 0x0000330C File Offset: 0x0000150C
	private void shakeUi(float factor)
	{
		Vector2 b = new Vector2(UnityEngine.Random.Range(-factor, factor), UnityEngine.Random.Range(-factor, factor));
		this.gameplayUiParent.anchoredPosition += b;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00003347 File Offset: 0x00001547
	public void Unload()
	{
		this.UnloadLevelSelect();
	}

	// Token: 0x0400002A RID: 42
	[Header("General")]
	[SerializeField]
	private DDRManager manager;

	// Token: 0x0400002B RID: 43
	[SerializeField]
	private InputManagerScript inputManager;

	// Token: 0x0400002C RID: 44
	[Header("Level select")]
	[SerializeField]
	private GameObject levelIconPrefab;

	// Token: 0x0400002D RID: 45
	[SerializeField]
	private RectTransform levelSelectParent;

	// Token: 0x0400002E RID: 46
	[SerializeField]
	private Text levelNameLabel;

	// Token: 0x0400002F RID: 47
	private DDRLevel[] levels;

	// Token: 0x04000030 RID: 48
	[Header("Gameplay")]
	[SerializeField]
	private Text comboText;

	// Token: 0x04000031 RID: 49
	[SerializeField]
	private Text longestComboText;

	// Token: 0x04000032 RID: 50
	[SerializeField]
	private Text rankText;

	// Token: 0x04000033 RID: 51
	[SerializeField]
	private Text scoreText;

	// Token: 0x04000034 RID: 52
	[SerializeField]
	private Image healthImage;

	// Token: 0x04000035 RID: 53
	[SerializeField]
	private GameObject arrowPrefab;

	// Token: 0x04000036 RID: 54
	[SerializeField]
	private GameObject ratingTextPrefab;

	// Token: 0x04000037 RID: 55
	[SerializeField]
	private RectTransform gameplayUiParent;

	// Token: 0x04000038 RID: 56
	[SerializeField]
	private RectTransform[] uiTracks;

	// Token: 0x04000039 RID: 57
	[SerializeField]
	private Vector2 offset;

	// Token: 0x0400003A RID: 58
	[SerializeField]
	private float speed;

	// Token: 0x0400003B RID: 59
	[Header("Colors")]
	[SerializeField]
	private Color perfectColor;

	// Token: 0x0400003C RID: 60
	[SerializeField]
	private Color greatColor;

	// Token: 0x0400003D RID: 61
	[SerializeField]
	private Color goodColor;

	// Token: 0x0400003E RID: 62
	[SerializeField]
	private Color okColor;

	// Token: 0x0400003F RID: 63
	[SerializeField]
	private Color earlyColor;

	// Token: 0x04000040 RID: 64
	private float levelSelectScroll;

	// Token: 0x04000041 RID: 65
	private int selectedLevel;

	// Token: 0x04000042 RID: 66
	private Dictionary<RectTransform, DDRLevel> levelSelectCache;

	// Token: 0x04000043 RID: 67
	private Dictionary<float, RectTransform>[] trackCache;
}
