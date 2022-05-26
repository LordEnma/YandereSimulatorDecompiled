// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.FlipBookPage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  public class FlipBookPage : MonoBehaviour
  {
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    public GameObject objectToActivate;

    private void Awake()
    {
      this.animator = this.GetComponent<Animator>();
      this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Transition(bool toOpen)
    {
      this.animator.SetTrigger(toOpen ? "OpenPage" : "ClosePage");
      if (!((Object) this.objectToActivate != (Object) null))
        return;
      this.objectToActivate.SetActive(false);
    }

    public void SwitchSort() => this.spriteRenderer.sortingOrder = 10 - this.spriteRenderer.sortingOrder;

    public void ObjectActive(bool toActive = true)
    {
      if (!((Object) this.objectToActivate != (Object) null))
        return;
      this.objectToActivate.SetActive(toActive);
    }
  }
}
