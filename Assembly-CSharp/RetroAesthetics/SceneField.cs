// Decompiled with JetBrains decompiler
// Type: RetroAesthetics.SceneField
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
