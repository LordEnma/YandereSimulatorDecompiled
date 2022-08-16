// Decompiled with JetBrains decompiler
// Type: MusicNoteScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MusicNoteScript : MonoBehaviour
{
  public MusicMinigameScript MusicMinigame;
  public InputManagerScript InputManager;
  public GameObject Ripple;
  public GameObject Perfect;
  public GameObject Wrong;
  public GameObject Early;
  public GameObject Late;
  public GameObject Miss;
  public GameObject Rating;
  public string XboxDirection;
  public string Direction;
  public string Tapped;
  public bool GaveInput;
  public bool Proceed;
  public float Speed;
  public int ID;

  private void Update()
  {
    this.transform.localPosition += new Vector3((float) ((double) this.Speed * (double) Time.deltaTime * -1.0), 0.0f, 0.0f);
    if (!this.MusicMinigame.KeyDown)
    {
      this.GaveInput = false;
      if (this.InputManager.TappedUp)
      {
        this.GaveInput = true;
        this.Tapped = "up";
      }
      else if (this.InputManager.TappedDown)
      {
        this.GaveInput = true;
        this.Tapped = "down";
      }
      else if (this.InputManager.TappedRight)
      {
        this.GaveInput = true;
        this.Tapped = "right";
      }
      else if (this.InputManager.TappedLeft)
      {
        this.GaveInput = true;
        this.Tapped = "left";
      }
      if (Input.GetKeyDown(this.Direction) || this.GaveInput && this.Tapped == this.Direction)
      {
        if (this.MusicMinigame.CurrentNote == this.ID)
        {
          if ((double) this.transform.localPosition.x > -0.60000002384185791 && (double) this.transform.localPosition.x < -0.40000000596046448)
          {
            this.Rating = Object.Instantiate<GameObject>(this.Perfect, this.transform.position, Quaternion.identity);
            this.Proceed = true;
            ++this.MusicMinigame.Health;
            this.MusicMinigame.CringeTimer = 0.0f;
            this.MusicMinigame.UpdateHealthBar();
          }
          else if ((double) this.transform.localPosition.x > -0.40000000596046448 && (double) this.transform.localPosition.x < -0.20000000298023224)
          {
            this.Rating = Object.Instantiate<GameObject>(this.Early, this.transform.position, Quaternion.identity);
            this.MusicMinigame.CringeTimer = 0.0f;
            this.Proceed = true;
          }
          else if ((double) this.transform.localPosition.x > -0.800000011920929 && (double) this.transform.localPosition.x < -0.40000000596046448)
          {
            this.Rating = Object.Instantiate<GameObject>(this.Late, this.transform.position, Quaternion.identity);
            this.MusicMinigame.CringeTimer = 0.0f;
            this.Proceed = true;
          }
        }
      }
      else if (Input.anyKeyDown && (double) this.transform.localPosition.x > -0.800000011920929 && (double) this.transform.localPosition.x < -0.20000000298023224 && !this.MusicMinigame.GameOver)
      {
        this.Rating = Object.Instantiate<GameObject>(this.Wrong, this.transform.position, Quaternion.identity);
        this.Proceed = true;
        this.MusicMinigame.Cringe();
        if (!this.MusicMinigame.LockHealth)
          this.MusicMinigame.Health -= 10f;
        this.MusicMinigame.UpdateHealthBar();
      }
    }
    if (this.Proceed)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.Ripple, this.transform.position, Quaternion.identity);
      gameObject.transform.parent = this.transform.parent;
      gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
      this.Rating.transform.parent = this.transform.parent;
      this.Rating.transform.localPosition = new Vector3(-0.5f, 0.25f, 0.0f);
      this.Rating.transform.localScale = new Vector3(0.3f, 0.15f, 0.15f);
      ++this.MusicMinigame.CurrentNote;
      this.MusicMinigame.KeyDown = true;
      Object.Destroy((Object) this.gameObject);
    }
    else if ((double) this.transform.localPosition.x < -0.64999997615814209 && this.MusicMinigame.CurrentNote == this.ID)
      ++this.MusicMinigame.CurrentNote;
    if ((double) this.transform.localPosition.x >= -0.93999999761581421 || this.MusicMinigame.GameOver)
      return;
    this.Rating = Object.Instantiate<GameObject>(this.Miss, this.transform.position, Quaternion.identity);
    this.Rating.transform.parent = this.transform.parent;
    this.Rating.transform.localPosition = new Vector3(-0.94f, 0.25f, 0.0f);
    this.Rating.transform.localScale = new Vector3(0.3f, 0.15f, 0.15f);
    Object.Destroy((Object) this.gameObject);
    this.MusicMinigame.Cringe();
    if (!this.MusicMinigame.LockHealth)
      this.MusicMinigame.Health -= 10f;
    this.MusicMinigame.UpdateHealthBar();
  }
}
