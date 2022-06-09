// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.FoodInstance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  [RequireComponent(typeof (SpriteRenderer))]
  public class FoodInstance : MonoBehaviour
  {
    public Food food;
    public Meter warmthMeter;
    public float timeToCool = 30f;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    private float heat;

    private void Start()
    {
      this.spriteRenderer = this.GetComponent<SpriteRenderer>();
      this.spriteRenderer.sprite = this.food.smallSprite;
      this.heat = this.timeToCool;
    }

    private void Update()
    {
      this.heat -= Time.deltaTime;
      this.warmthMeter.SetFill(this.heat / this.timeToCool);
    }

    public void SetHeat(float newHeat) => this.heat = newHeat;
  }
}
