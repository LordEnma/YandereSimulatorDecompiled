// Decompiled with JetBrains decompiler
// Type: BlasterScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BlasterScript : MonoBehaviour
{
  public Transform Skull;
  public Renderer Eyes;
  public Transform Beam;
  public float Size;

  private void Start()
  {
    this.Skull.localScale = Vector3.zero;
    this.Beam.localScale = Vector3.zero;
  }

  private void Update()
  {
    AnimationState animationState = this.GetComponent<Animation>()["Blast"];
    if ((double) animationState.time > 1.0)
    {
      this.Beam.localScale = Vector3.Lerp(this.Beam.localScale, new Vector3(15f, 1f, 1f), Time.deltaTime * 10f);
      this.Eyes.material.color = new Color(1f, 0.0f, 0.0f, 1f);
    }
    if ((double) animationState.time < (double) animationState.length)
      return;
    Object.Destroy((Object) this.gameObject);
  }

  private void LateUpdate()
  {
    this.Size = (double) this.GetComponent<Animation>()["Blast"].time < 1.5 ? Mathf.Lerp(this.Size, 2f, Time.deltaTime * 5f) : Mathf.Lerp(this.Size, 0.0f, Time.deltaTime * 10f);
    this.Skull.localScale = new Vector3(this.Size, this.Size, this.Size);
  }
}
