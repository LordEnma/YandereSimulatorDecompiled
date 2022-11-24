// Decompiled with JetBrains decompiler
// Type: RetroAesthetics.SceneField
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
