// Decompiled with JetBrains decompiler
// Type: BlacklightEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
public class BlacklightEffect : MonoBehaviour
{
  [SerializeField]
  private Color fogColorDark = (Color) new Color32((byte) 14, (byte) 11, (byte) 31, byte.MaxValue);
  [SerializeField]
  private Color fogColorLight = (Color) new Color32((byte) 87, (byte) 89, (byte) 111, byte.MaxValue);
  [SerializeField]
  [Range(0.0f, 1f)]
  private float fogOpacity = 1f;
  [SerializeField]
  private float fogDepth = 8f;
  [Space(5f)]
  [Header("Glow")]
  [SerializeField]
  [ColorUsage(true, true, 0.0f, 3f, 0.0f, 3f)]
  private Color glowColor = new Color(0.0f, 0.4823529f, 0.7490196f) * 9f;
  [SerializeField]
  [ColorUsage(true, true, 0.0f, 3f, 0.0f, 3f)]
  private Color glowColorSecondary = new Color(0.7490196f, 0.0f, 0.6784314f) * 9f;
  [SerializeField]
  private float glowBias = 13f;
  [SerializeField]
  [Range(0.0f, 1f)]
  private float glowFlip;
  [SerializeField]
  private bool glow = true;
  [Space(5f)]
  [Header("Targetted highlighting")]
  [SerializeField]
  private HighlightTarget[] highlightTargets;
  [SerializeField]
  [Range(0.0f, 1f)]
  private float smoothDropoff;
  [Space(5f)]
  [Header("Edge")]
  [SerializeField]
  private Color edgeColor = (Color) new Color32((byte) 7, byte.MaxValue, (byte) 83, byte.MaxValue);
  [SerializeField]
  [Range(0.01f, 1f)]
  private float threshold = 0.45f;
  [SerializeField]
  [Range(0.0f, 1f)]
  private float edgeOpacity = 1f;
  [Space(5f)]
  [Header("Overlay")]
  [SerializeField]
  private Color overlayTop = (Color) new Color32((byte) 233, (byte) 0, byte.MaxValue, byte.MaxValue);
  [SerializeField]
  private Color overlayBottom = (Color) new Color32((byte) 0, (byte) 38, byte.MaxValue, byte.MaxValue);
  [SerializeField]
  [Range(0.0f, 1f)]
  private float overlayOpacity = 0.06f;
  private Color[] hTargets = new Color[100];
  private float[] hThresholds = new float[100];
  private Color[] hColors = new Color[100];
  private float[] hColorInterpolations = new float[100];
  private Camera camera;
  private Material post;

  private void Update()
  {
    if ((Object) this.camera != (Object) null)
      this.camera.depthTextureMode = DepthTextureMode.Depth | DepthTextureMode.DepthNormals;
    if (!((Object) this.post != (Object) null))
      return;
    this.post.SetFloat("_DepthDistance", this.fogDepth);
    this.post.SetColor("_FogColorDark", this.fogColorDark);
    this.post.SetColor("_FogColorLight", this.fogColorLight);
    this.post.SetFloat("_FogOpacity", this.fogOpacity);
    this.post.SetFloat("_GlowBias", this.glowBias);
    this.post.SetColor("_GlowColor", this.glowColor);
    this.post.SetColor("_GlowColor2", this.glowColorSecondary);
    this.post.SetFloat("_GlowAmount", this.glow ? 1f : 0.0f);
    this.post.SetColor("_EdgeColor", this.edgeColor);
    this.post.SetFloat("_EdgeThreshold", this.threshold);
    this.post.SetFloat("_EdgeStrength", this.edgeOpacity);
    this.post.SetColor("_OverlayTop", this.overlayTop);
    this.post.SetColor("_OverlayBottom", this.overlayBottom);
    this.post.SetFloat("_OverlayOpacity", this.overlayOpacity);
    this.post.SetFloat("_HighlightFlip", this.glowFlip);
    this.post.SetFloat("_HighlightTargetSmooth", this.smoothDropoff);
    if (this.highlightTargets != null)
    {
      for (int index = 0; index < this.highlightTargets.Length; ++index)
      {
        this.hTargets[index] = this.highlightTargets[index].TargetColor;
        this.hThresholds[index] = this.highlightTargets[index].Threshold;
        this.hColors[index] = this.highlightTargets[index].ReplacementColor;
        this.hColorInterpolations[index] = this.highlightTargets[index].SmoothColorInterpolation;
      }
    }
    if (this.highlightTargets != null && this.highlightTargets.Length != 0)
      this.post.SetInt("_HighlightTargetsLength", Mathf.Clamp(this.highlightTargets.Length, 0, 100));
    this.post.SetColorArray("_HighlightTargets", this.hTargets);
    this.post.SetFloatArray("_HighlightTargetThresholds", this.hThresholds);
    this.post.SetColorArray("_HighlightColors", this.hColors);
    this.post.SetFloatArray("_SmoothColorInterpolations", this.hColorInterpolations);
  }

  private void OnRenderImage(RenderTexture source, RenderTexture destination)
  {
    if ((Object) this.camera == (Object) null)
    {
      this.camera = this.GetComponent<Camera>();
    }
    else
    {
      if ((Object) this.post == (Object) null)
        this.post = new Material(Shader.Find("Abcight/BlacklightPost"));
      Graphics.Blit((Texture) source, destination, this.post);
    }
  }

  [ContextMenu("Refresh")]
  public void Refresh()
  {
    Object.DestroyImmediate((Object) this.post);
    this.post = (Material) null;
  }
}
