// Decompiled with JetBrains decompiler
// Type: DontLetSenpaiNoticeYouScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DontLetSenpaiNoticeYouScript : MonoBehaviour
{
  public UILabel[] Letters;
  public Vector3[] Origins;
  public AudioClip Slam;
  public bool Proceed;
  public int ShakeID;
  public int ID;

  private void Start()
  {
    for (; this.ID < this.Letters.Length; ++this.ID)
    {
      UILabel letter = this.Letters[this.ID];
      letter.transform.localScale = new Vector3(10f, 10f, 1f);
      letter.color = new Color(letter.color.r, letter.color.g, letter.color.b, 0.0f);
      this.Origins[this.ID] = letter.transform.localPosition;
    }
    this.ID = 0;
  }

  private void Update()
  {
    if (Input.GetButtonDown("A"))
      this.Proceed = true;
    if (!this.Proceed)
      return;
    if (this.ID < this.Letters.Length)
    {
      UILabel letter = this.Letters[this.ID];
      letter.transform.localScale = Vector3.MoveTowards(letter.transform.localScale, Vector3.one, Time.deltaTime * 100f);
      letter.color = new Color(letter.color.r, letter.color.g, letter.color.b, letter.color.a + Time.deltaTime * 10f);
      if (letter.transform.localScale == Vector3.one)
      {
        this.GetComponent<AudioSource>().PlayOneShot(this.Slam);
        ++this.ID;
      }
    }
    for (this.ShakeID = 0; this.ShakeID < this.Letters.Length; ++this.ShakeID)
    {
      UILabel letter = this.Letters[this.ShakeID];
      Vector3 origin = this.Origins[this.ShakeID];
      letter.transform.localPosition = new Vector3(origin.x + Random.Range(-5f, 5f), origin.y + Random.Range(-5f, 5f), letter.transform.localPosition.z);
    }
  }
}
