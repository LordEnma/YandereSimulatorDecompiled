// Decompiled with JetBrains decompiler
// Type: GazerHairScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GazerHairScript : MonoBehaviour
{
  public SkinnedMeshRenderer MyMesh;
  public float[] TargetWeight;
  public float[] Weight;
  public float Strength = 100f;
  public int ID;

  private void Update()
  {
    for (this.ID = 0; this.ID < this.Weight.Length; ++this.ID)
    {
      this.Weight[this.ID] = Mathf.MoveTowards(this.Weight[this.ID], this.TargetWeight[this.ID], Time.deltaTime * this.Strength);
      if ((double) this.Weight[this.ID] == (double) this.TargetWeight[this.ID])
        this.TargetWeight[this.ID] = Random.Range(0.0f, 100f);
      this.MyMesh.SetBlendShapeWeight(this.ID, this.Weight[this.ID]);
    }
  }
}
