// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.AIMover
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  public abstract class AIMover : MonoBehaviour
  {
    protected float moveSpeed = 3f;

    public abstract ControlInput GetInput();

    private void FixedUpdate() => this.transform.Translate((Vector3) (new Vector2(this.GetInput().horizontal, 0.0f) * Time.fixedDeltaTime * this.moveSpeed));
  }
}
