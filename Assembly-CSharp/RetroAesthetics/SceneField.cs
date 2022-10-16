// Decompiled with JetBrains decompiler
// Type: RetroAesthetics.SceneField
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace RetroAesthetics
{
  [Serializable]
  public class SceneField
  {
    [SerializeField]
    private UnityEngine.Object m_SceneAsset;
    [SerializeField]
    private string m_SceneName = "";

    public string SceneName => this.m_SceneName;

    public static implicit operator string(SceneField sceneField) => sceneField.SceneName;
  }
}
