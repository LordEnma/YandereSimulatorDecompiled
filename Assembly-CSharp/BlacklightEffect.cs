using System;
using UnityEngine;

// Token: 0x020004ED RID: 1261
[ExecuteInEditMode]
public class BlacklightEffect : MonoBehaviour
{
	// Token: 0x060020E4 RID: 8420 RVA: 0x001E5B1C File Offset: 0x001E3D1C
	private void Update()
	{
		if (this.camera != null)
		{
			this.camera.depthTextureMode = (DepthTextureMode.Depth | DepthTextureMode.DepthNormals);
		}
		if (this.post != null)
		{
			this.post.SetFloat("_DepthDistance", this.fogDepth);
			this.post.SetColor("_FogColorDark", this.fogColorDark);
			this.post.SetColor("_FogColorLight", this.fogColorLight);
			this.post.SetFloat("_FogOpacity", this.fogOpacity);
			this.post.SetFloat("_GlowBias", this.glowBias);
			this.post.SetColor("_GlowColor", this.glowColor);
			this.post.SetColor("_GlowColor2", this.glowColorSecondary);
			this.post.SetFloat("_GlowAmount", (float)(this.glow ? 1 : 0));
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
				for (int i = 0; i < this.highlightTargets.Length; i++)
				{
					this.hTargets[i] = this.highlightTargets[i].TargetColor;
					this.hThresholds[i] = this.highlightTargets[i].Threshold;
					this.hColors[i] = this.highlightTargets[i].ReplacementColor;
					this.hColorInterpolations[i] = this.highlightTargets[i].SmoothColorInterpolation;
				}
			}
			if (this.highlightTargets != null && this.highlightTargets.Length != 0)
			{
				this.post.SetInt("_HighlightTargetsLength", Mathf.Clamp(this.highlightTargets.Length, 0, 100));
			}
			this.post.SetColorArray("_HighlightTargets", this.hTargets);
			this.post.SetFloatArray("_HighlightTargetThresholds", this.hThresholds);
			this.post.SetColorArray("_HighlightColors", this.hColors);
			this.post.SetFloatArray("_SmoothColorInterpolations", this.hColorInterpolations);
		}
	}

	// Token: 0x060020E5 RID: 8421 RVA: 0x001E5DCC File Offset: 0x001E3FCC
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.camera == null)
		{
			this.camera = base.GetComponent<Camera>();
			return;
		}
		if (this.post == null)
		{
			this.post = new Material(Shader.Find("Abcight/BlacklightPost"));
		}
		Graphics.Blit(source, destination, this.post);
	}

	// Token: 0x060020E6 RID: 8422 RVA: 0x001E5E24 File Offset: 0x001E4024
	[ContextMenu("Refresh")]
	public void Refresh()
	{
		UnityEngine.Object.DestroyImmediate(this.post);
		this.post = null;
	}

	// Token: 0x04004892 RID: 18578
	[SerializeField]
	private Color fogColorDark = new Color32(14, 11, 31, byte.MaxValue);

	// Token: 0x04004893 RID: 18579
	[SerializeField]
	private Color fogColorLight = new Color32(87, 89, 111, byte.MaxValue);

	// Token: 0x04004894 RID: 18580
	[SerializeField]
	[Range(0f, 1f)]
	private float fogOpacity = 1f;

	// Token: 0x04004895 RID: 18581
	[SerializeField]
	private float fogDepth = 8f;

	// Token: 0x04004896 RID: 18582
	[Space(5f)]
	[Header("Glow")]
	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColor = new Color(0f, 0.48235294f, 0.7490196f) * 9f;

	// Token: 0x04004897 RID: 18583
	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColorSecondary = new Color(0.7490196f, 0f, 0.6784314f) * 9f;

	// Token: 0x04004898 RID: 18584
	[SerializeField]
	private float glowBias = 13f;

	// Token: 0x04004899 RID: 18585
	[SerializeField]
	[Range(0f, 1f)]
	private float glowFlip;

	// Token: 0x0400489A RID: 18586
	[SerializeField]
	private bool glow = true;

	// Token: 0x0400489B RID: 18587
	[Space(5f)]
	[Header("Targetted highlighting")]
	[SerializeField]
	private HighlightTarget[] highlightTargets;

	// Token: 0x0400489C RID: 18588
	[SerializeField]
	[Range(0f, 1f)]
	private float smoothDropoff;

	// Token: 0x0400489D RID: 18589
	[Space(5f)]
	[Header("Edge")]
	[SerializeField]
	private Color edgeColor = new Color32(7, byte.MaxValue, 83, byte.MaxValue);

	// Token: 0x0400489E RID: 18590
	[SerializeField]
	[Range(0.01f, 1f)]
	private float threshold = 0.45f;

	// Token: 0x0400489F RID: 18591
	[SerializeField]
	[Range(0f, 1f)]
	private float edgeOpacity = 1f;

	// Token: 0x040048A0 RID: 18592
	[Space(5f)]
	[Header("Overlay")]
	[SerializeField]
	private Color overlayTop = new Color32(233, 0, byte.MaxValue, byte.MaxValue);

	// Token: 0x040048A1 RID: 18593
	[SerializeField]
	private Color overlayBottom = new Color32(0, 38, byte.MaxValue, byte.MaxValue);

	// Token: 0x040048A2 RID: 18594
	[SerializeField]
	[Range(0f, 1f)]
	private float overlayOpacity = 0.06f;

	// Token: 0x040048A3 RID: 18595
	private Color[] hTargets = new Color[100];

	// Token: 0x040048A4 RID: 18596
	private float[] hThresholds = new float[100];

	// Token: 0x040048A5 RID: 18597
	private Color[] hColors = new Color[100];

	// Token: 0x040048A6 RID: 18598
	private float[] hColorInterpolations = new float[100];

	// Token: 0x040048A7 RID: 18599
	private Camera camera;

	// Token: 0x040048A8 RID: 18600
	private Material post;
}
