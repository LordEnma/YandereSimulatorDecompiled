// Decompiled with JetBrains decompiler
// Type: BloodCleanerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using Pathfinding;
using UnityEngine;

public class BloodCleanerScript : MonoBehaviour
{
  public Transform BloodParent;
  public PromptScript Prompt;
  public AIPath Pathfinding;
  public GameObject Lens;
  public UILabel Label;
  public float Distance;
  public float Blood;
  public bool Super;

  private void Start()
  {
    if (!this.Super)
      return;
    Physics.IgnoreLayerCollision(11, 15, true);
    this.Prompt.Hide();
    this.Prompt.enabled = false;
  }

  private void Update()
  {
    if ((double) this.Blood >= 100.0)
      return;
    if (this.BloodParent.childCount > 0)
    {
      this.Pathfinding.target = this.BloodParent.GetChild(0);
      this.Pathfinding.speed = 4f;
      this.Label.text = (double) this.Pathfinding.target.position.y >= 4.0 ? ((double) this.Pathfinding.target.position.y >= 8.0 ? ((double) this.Pathfinding.target.position.y >= 12.0 ? "R" : "3") : "2") : "1";
      if (!((Object) this.Pathfinding.target != (Object) null))
        return;
      this.Distance = Vector3.Distance(this.transform.position, this.Pathfinding.target.position);
      if ((double) this.Distance < 1.0)
      {
        this.Pathfinding.speed = 0.0f;
        Transform child = this.BloodParent.GetChild(0);
        if ((Object) child.GetComponent("BloodPoolScript") != (Object) null)
        {
          child.localScale = new Vector3(child.localScale.x - Time.deltaTime, child.localScale.y - Time.deltaTime, child.localScale.z);
          this.Blood += Time.deltaTime;
          if ((double) this.Blood >= 100.0)
            this.Lens.SetActive(true);
          if ((double) child.transform.localScale.x >= 0.10000000149011612)
            return;
          Object.Destroy((Object) child.gameObject);
        }
        else
          Object.Destroy((Object) child.gameObject);
      }
      else
        this.Pathfinding.speed = 4f;
    }
    else
    {
      if (!this.Super)
        return;
      this.Pathfinding.target = this.Prompt.Yandere.transform;
      this.Pathfinding.speed = 4f;
    }
  }
}
