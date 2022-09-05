// Decompiled with JetBrains decompiler
// Type: RetroAesthetics.SceneField
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
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
