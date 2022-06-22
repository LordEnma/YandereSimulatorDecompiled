// Decompiled with JetBrains decompiler
// Type: NyanDroidScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using Pathfinding;
using UnityEngine;

public class NyanDroidScript : MonoBehaviour
{
  public Animation Character;
  public PromptScript Prompt;
  public AIPath Pathfinding;
  public Vector3 OriginalPosition;
  public string Prefix;
  public float Timer;

  private void Start() => this.OriginalPosition = this.transform.position;

  private void Update()
  {
    if (!this.Pathfinding.canSearch)
    {
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
      this.Prompt.Label[0].text = "     Stop";
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Pathfinding.canSearch = true;
      this.Pathfinding.canMove = true;
    }
    else
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0)
      {
        this.Timer = 0.0f;
        this.transform.position += new Vector3(0.0f, 0.0001f, 0.0f);
        if ((double) this.transform.position.y < 0.0)
          this.transform.position = new Vector3(this.transform.position.x, 1f / 1000f, this.transform.position.z);
        Physics.SyncTransforms();
      }
      if (Input.GetButtonDown("RB"))
        this.transform.position = this.OriginalPosition;
      if ((double) Vector3.Distance(this.transform.position, this.Pathfinding.target.position) <= 1.0)
      {
        this.Character.CrossFade(this.Prefix + "_Idle");
        this.Pathfinding.speed = 0.0f;
      }
      else if ((double) Vector3.Distance(this.transform.position, this.Pathfinding.target.position) <= 2.0)
      {
        this.Character.CrossFade(this.Prefix + "_Walk");
        this.Pathfinding.speed = 0.5f;
      }
      else
      {
        this.Character.CrossFade(this.Prefix + "_Run");
        this.Pathfinding.speed = 5f;
      }
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
      this.Prompt.Label[0].text = "     Follow";
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Character.CrossFade(this.Prefix + "_Idle");
      this.Pathfinding.canSearch = false;
      this.Pathfinding.canMove = false;
    }
  }
}
