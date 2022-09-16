// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Aeroplane.AeroplanePropellerAnimator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
  public class AeroplanePropellerAnimator : MonoBehaviour
  {
    [SerializeField]
    private Transform m_PropellorModel;
    [SerializeField]
    private Transform m_PropellorBlur;
    [SerializeField]
    private Texture2D[] m_PropellorBlurTextures;
    [SerializeField]
    [Range(0.0f, 1f)]
    private float m_ThrottleBlurStart = 0.25f;
    [SerializeField]
    [Range(0.0f, 1f)]
    private float m_ThrottleBlurEnd = 0.5f;
    [SerializeField]
    private float m_MaxRpm = 2000f;
    private AeroplaneController m_Plane;
    private int m_PropellorBlurState = -1;
    private const float k_RpmToDps = 60f;
    private Renderer m_PropellorModelRenderer;
    private Renderer m_PropellorBlurRenderer;

    private void Awake()
    {
      this.m_Plane = this.GetComponent<AeroplaneController>();
      this.m_PropellorModelRenderer = this.m_PropellorModel.GetComponent<Renderer>();
      this.m_PropellorBlurRenderer = this.m_PropellorBlur.GetComponent<Renderer>();
      this.m_PropellorBlur.parent = this.m_PropellorModel;
    }

    private void Update()
    {
      this.m_PropellorModel.Rotate(0.0f, (float) ((double) this.m_MaxRpm * (double) this.m_Plane.Throttle * (double) Time.deltaTime * 60.0), 0.0f);
      int num = 0;
      if ((double) this.m_Plane.Throttle > (double) this.m_ThrottleBlurStart)
        num = Mathf.FloorToInt(Mathf.InverseLerp(this.m_ThrottleBlurStart, this.m_ThrottleBlurEnd, this.m_Plane.Throttle) * (float) (this.m_PropellorBlurTextures.Length - 1));
      if (num == this.m_PropellorBlurState)
        return;
      this.m_PropellorBlurState = num;
      if (this.m_PropellorBlurState == 0)
      {
        this.m_PropellorModelRenderer.enabled = true;
        this.m_PropellorBlurRenderer.enabled = false;
      }
      else
      {
        this.m_PropellorModelRenderer.enabled = false;
        this.m_PropellorBlurRenderer.enabled = true;
        this.m_PropellorBlurRenderer.material.mainTexture = (Texture) this.m_PropellorBlurTextures[this.m_PropellorBlurState];
      }
    }
  }
}
