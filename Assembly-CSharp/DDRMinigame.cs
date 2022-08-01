// Decompiled with JetBrains decompiler
// Type: DDRMinigame
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DDRMinigame : MonoBehaviour
{
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
  private RectTransform[] uiTracks;
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
    this.gameplayUiParent.anchoredPosition = Vector2.zero;
    this.gameplayUiParent.rotation = Quaternion.identity;
    this.trackCache = new Dictionary<float, RectTransform>[4];
    for (int index = 0; index < this.trackCache.Length; ++index)
    {
      this.trackCache[index] = new Dictionary<float, RectTransform>();
      foreach (float node in level.Tracks[index].Nodes)
      {
        RectTransform component = UnityEngine.Object.Instantiate<GameObject>(this.arrowPrefab, (Transform) this.uiTracks[index]).GetComponent<RectTransform>();
        switch (index)
        {
          case 0:
            component.rotation = Quaternion.Euler(0.0f, 0.0f, 90f);
            break;
          case 1:
            component.rotation = Quaternion.Euler(0.0f, 0.0f, 180f);
            break;
          case 2:
            component.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            break;
          case 3:
            component.rotation = Quaternion.Euler(0.0f, 0.0f, -90f);
            break;
        }
        this.trackCache[index].Add(node, component);
      }
    }
  }

  public void LoadLevelSelect(DDRLevel[] levels)
  {
    this.levelSelectCache = new Dictionary<RectTransform, DDRLevel>();
    this.levels = levels;
    for (int index = 0; index < levels.Length; ++index)
    {
      RectTransform component = UnityEngine.Object.Instantiate<GameObject>(this.levelIconPrefab, (Transform) this.levelSelectParent).GetComponent<RectTransform>();
      component.GetComponent<Image>().sprite = levels[index].LevelIcon;
      this.levelSelectCache.Add(component, levels[index]);
    }
    this.positionLevels(true);
  }

  public void UnloadLevelSelect()
  {
    foreach (KeyValuePair<RectTransform, DDRLevel> keyValuePair in this.levelSelectCache)
      UnityEngine.Object.Destroy((UnityEngine.Object) keyValuePair.Key.gameObject);
    this.levelSelectCache = new Dictionary<RectTransform, DDRLevel>();
  }

  public void UpdateLevelSelect()
  {
    if (this.inputManager.TappedLeft)
      --this.levelSelectScroll;
    else if (this.inputManager.TappedRight)
      ++this.levelSelectScroll;
    this.levelSelectScroll = Mathf.Clamp(this.levelSelectScroll, 0.0f, (float) (this.levels.Length - 1));
    this.selectedLevel = (int) Mathf.Round(this.levelSelectScroll);
    this.positionLevels();
    if (Input.GetButtonDown("A"))
      this.manager.LoadedLevel = this.levels[this.selectedLevel];
    if (!Input.GetButtonDown("B"))
      return;
    this.manager.BootOut();
  }

  private void positionLevels(bool instant = false)
  {
    for (int index = 0; index < this.levelSelectCache.Keys.Count; ++index)
    {
      RectTransform key = this.levelSelectCache.ElementAt<KeyValuePair<RectTransform, DDRLevel>>(index).Key;
      Vector2 b = new Vector2((float) (-this.selectedLevel * 400 + index * 400), 0.0f);
      key.anchoredPosition = instant ? b : Vector2.Lerp(key.anchoredPosition, b, 10f * Time.deltaTime);
      this.levelNameLabel.text = this.levels[this.selectedLevel].LevelName;
    }
  }

  public void UpdateGame(float time)
  {
    if (this.trackCache == null)
      return;
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
    for (int track = 0; track < this.trackCache.Length; ++track)
    {
      Dictionary<float, RectTransform> dictionary = this.trackCache[track];
      foreach (float key in dictionary.Keys)
      {
        float num = key - time;
        if ((double) num < -0.0500000007450581)
        {
          if (!flag)
            this.displayHitRating(track, DDRRating.Miss);
          this.assignPoints(DDRRating.Miss);
          this.updateCombo(DDRRating.Miss);
          this.removeNodeAt(((IEnumerable<Dictionary<float, RectTransform>>) this.trackCache).ToList<Dictionary<float, RectTransform>>().IndexOf(dictionary));
          return;
        }
        dictionary[key].anchoredPosition = new Vector2(0.0f, -num * this.speed) + this.offset;
      }
    }
  }

  public void UpdateEndcard(GameState state)
  {
    this.scoreText.text = string.Format("Score: {0}", (object) state.Score);
    Color resultColor;
    this.rankText.text = this.getRank(state, out resultColor);
    this.rankText.color = resultColor;
    this.longestComboText.text = string.Format("Biggest combo: {0}", (object) state.LongestCombo.ToString());
  }

  private DDRRating getRating(int track, float time)
  {
    RectTransform rect;
    this.getFirstNodeOn(track, out float _, out rect);
    DDRRating rating = DDRRating.Miss;
    float num = this.offset.y - rect.localPosition.y;
    if ((double) num < 130.0)
    {
      rating = DDRRating.Early;
      if ((double) num < 75.0)
        rating = DDRRating.Ok;
      if ((double) num < 65.0)
        rating = DDRRating.Good;
      if ((double) num < 50.0)
        rating = DDRRating.Great;
      if ((double) num < 30.0)
        rating = DDRRating.Perfect;
      if ((double) num < -30.0)
        rating = DDRRating.Ok;
      if ((double) num < -130.0)
        rating = DDRRating.Miss;
    }
    return rating;
  }

  private string getRank(GameState state, out Color resultColor)
  {
    string rank = "F";
    int num1 = 0;
    int perfectScorePoints = this.manager.LoadedLevel.PerfectScorePoints;
    foreach (DDRTrack track in this.manager.LoadedLevel.Tracks)
      num1 += track.Nodes.Count * perfectScorePoints;
    float num2 = (float) ((double) state.Score / (double) num1 * 100.0);
    if ((double) num2 >= 30.0)
      rank = "D";
    if ((double) num2 >= 50.0)
      rank = "C";
    if ((double) num2 >= 75.0)
      rank = "B";
    if ((double) num2 >= 80.0)
      rank = "A";
    if ((double) num2 >= 95.0)
      rank = "S";
    if ((double) num2 >= 100.0)
      rank = "S+";
    resultColor = Color.Lerp(Color.red, Color.green, num2 / 100f);
    return rank;
  }

  private void pollInput(float time)
  {
    if (this.inputManager.TappedLeft)
      this.registerKeypress(0, time);
    if (this.inputManager.TappedDown)
      this.registerKeypress(1, time);
    if (this.inputManager.TappedUp)
      this.registerKeypress(2, time);
    if (!this.inputManager.TappedRight)
      return;
    this.registerKeypress(3, time);
  }

  private void registerKeypress(int track, float time)
  {
    DDRRating rating = this.getRating(track, time);
    this.displayHitRating(track, rating);
    this.assignPoints(rating);
    this.registerRating(rating);
    this.updateCombo(rating);
    if (rating == DDRRating.Miss)
      return;
    this.removeNodeAt(track);
  }

  private void registerRating(DDRRating rating)
  {
    ++this.manager.GameState.Ratings[rating];
    this.manager.GameState.Ratings.OrderBy<KeyValuePair<DDRRating, int>, int>((Func<KeyValuePair<DDRRating, int>, int>) (x => x.Value));
  }

  private void updateCombo(DDRRating rating)
  {
    this.comboText.text = "";
    this.comboText.color = Color.white;
    this.comboText.GetComponent<Animation>().Play();
    if (rating != DDRRating.Miss && rating != DDRRating.Early)
    {
      ++this.manager.GameState.Combo;
      if (this.manager.GameState.Combo > this.manager.GameState.LongestCombo)
      {
        this.manager.GameState.LongestCombo = this.manager.GameState.Combo;
        this.comboText.color = Color.yellow;
      }
      if (this.manager.GameState.Combo < 2)
        return;
      this.comboText.text = string.Format("x{0} combo", (object) this.manager.GameState.Combo);
      this.comboText.color = Color.white;
    }
    else
      this.manager.GameState.Combo = 0;
  }

  private void removeNodeAt(int trackId, float delay = 0.0f)
  {
    Dictionary<float, RectTransform> dictionary = this.trackCache[trackId];
    float[] array = dictionary.Keys.ToArray<float>();
    Array.Sort<float>(array, (Comparison<float>) ((a, b) => a.CompareTo(b)));
    UnityEngine.Object.Destroy((UnityEngine.Object) dictionary[array[0]].gameObject, delay);
    dictionary.Remove(array[0]);
  }

  private void getFirstNodeOn(int track, out float time, out RectTransform rect)
  {
    Dictionary<float, RectTransform> dictionary = this.trackCache[track];
    float[] array = dictionary.Keys.ToArray<float>();
    Array.Sort<float>(array, (Comparison<float>) ((a, b) => a.CompareTo(b)));
    time = array[0];
    rect = dictionary[time];
  }

  private void displayHitRating(int track, DDRRating rating)
  {
    Text component = UnityEngine.Object.Instantiate<GameObject>(this.ratingTextPrefab, (Transform) this.uiTracks[track]).GetComponent<Text>();
    component.rectTransform.anchoredPosition = new Vector2(0.0f, 280f);
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
    UnityEngine.Object.Destroy((UnityEngine.Object) component, 1f);
  }

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
      this.manager.GameState.Score += num;
    this.manager.GameState.Health += (float) num;
  }

  private void shakeUi(float factor) => this.gameplayUiParent.anchoredPosition += new Vector2(UnityEngine.Random.Range(-factor, factor), UnityEngine.Random.Range(-factor, factor));

  public void Unload() => this.UnloadLevelSelect();
}
