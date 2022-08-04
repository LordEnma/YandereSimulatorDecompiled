// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Chair
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
  public class Chair : MonoBehaviour
  {
    private static Chairs chairs;
    public bool available = true;

    public static Chairs AllChairs
    {
      get
      {
        if (Chair.chairs == null || Chair.chairs.Count == 0)
        {
          Chair.chairs = new Chairs();
          foreach (Chair chair in Object.FindObjectsOfType<Chair>())
            Chair.chairs.Add(chair);
        }
        return Chair.chairs;
      }
    }

    public static Chair RandomChair
    {
      get
      {
        Chairs chairs = new Chairs();
        foreach (Chair allChair in (ReorderableArray<Chair>) Chair.AllChairs)
        {
          if (allChair.available)
            chairs.Add(allChair);
        }
        if (chairs.Count <= 0)
          return (Chair) null;
        int index = Random.Range(0, chairs.Count);
        chairs[index].available = false;
        return chairs[index];
      }
    }

    private void OnDestroy() => Chair.chairs = (Chairs) null;
  }
}
