// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Aeroplane.JetParticleEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
  [RequireComponent(typeof (ParticleSystem))]
  public class JetParticleEffect : MonoBehaviour
  {
    public Color minColour;
    private AeroplaneController m_Jet;
    private ParticleSystem m_System;
    private float m_OriginalStartSize;
    private float m_OriginalLifetime;
    private Color m_OriginalStartColor;

    private void Start()
    {
      this.m_Jet = this.FindAeroplaneParent();
      this.m_System = this.GetComponent<ParticleSystem>();
      this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
      this.m_OriginalStartSize = this.m_System.main.startSize.constant;
      this.m_OriginalStartColor = this.m_System.main.startColor.color;
    }

    private void Update()
    {
      ParticleSystem.MainModule main = this.m_System.main with
      {
        startLifetime = (ParticleSystem.MinMaxCurve) Mathf.Lerp(0.0f, this.m_OriginalLifetime, this.m_Jet.Throttle),
        startSize = (ParticleSystem.MinMaxCurve) Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle),
        startColor = (ParticleSystem.MinMaxGradient) Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle)
      };
    }

    private AeroplaneController FindAeroplaneParent()
    {
      for (Transform transform = this.transform; (UnityEngine.Object) transform != (UnityEngine.Object) null; transform = transform.parent)
      {
        AeroplaneController component = transform.GetComponent<AeroplaneController>();
        if (!((UnityEngine.Object) component == (UnityEngine.Object) null))
          return component;
      }
      throw new Exception(" AeroplaneContoller not found in object hierarchy");
    }
  }
}
