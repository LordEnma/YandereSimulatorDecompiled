using System;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
[ExecuteInEditMode]
public class BlacklightEffect : MonoBehaviour
{
	// Token: 0x0600210A RID: 8458 RVA: 0x001E92C0 File Offset: 0x001E74C0
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

	// Token: 0x0600210B RID: 8459 RVA: 0x001E9570 File Offset: 0x001E7770
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

	// Token: 0x0600210C RID: 8460 RVA: 0x001E95C8 File Offset: 0x001E77C8
	[ContextMenu("Refresh")]
	public void Refresh()
	{
		UnityEngine.Object.DestroyImmediate(this.post);
		this.post = null;
	}

	// Token: 0x04004922 RID: 18722
	[SerializeField]
	private Color fogColorDark = new Color32(14, 11, 31, byte.MaxValue);

	// Token: 0x04004923 RID: 18723
	[SerializeField]
	private Color fogColorLight = new Color32(87, 89, 111, byte.MaxValue);

	// Token: 0x04004924 RID: 18724
	[SerializeField]
	[Range(0f, 1f)]
	private float fogOpacity = 1f;

	// Token: 0x04004925 RID: 18725
	[SerializeField]
	private float fogDepth = 8f;

	// Token: 0x04004926 RID: 18726
	[Space(5f)]
	[Header("Glow")]
	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColor = new Color(0f, 0.48235294f, 0.7490196f) * 9f;

	// Token: 0x04004927 RID: 18727
	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColorSecondary = new Color(0.7490196f, 0f, 0.6784314f) * 9f;

	// Token: 0x04004928 RID: 18728
	[SerializeField]
	private float glowBias = 13f;

	// Token: 0x04004929 RID: 18729
	[SerializeField]
	[Range(0f, 1f)]
	private float glowFlip;

	// Token: 0x0400492A RID: 18730
	[SerializeField]
	private bool glow = true;

	// Token: 0x0400492B RID: 18731
	[Space(5f)]
	[Header("Targetted highlighting")]
	[SerializeField]
	private HighlightTarget[] highlightTargets;

	// Token: 0x0400492C RID: 18732
	[SerializeField]
	[Range(0f, 1f)]
	private float smoothDropoff;

	// Token: 0x0400492D RID: 18733
	[Space(5f)]
	[Header("Edge")]
	[SerializeField]
	private Color edgeColor = new Color32(7, byte.MaxValue, 83, byte.MaxValue);

	// Token: 0x0400492E RID: 18734
	[SerializeField]
	[Range(0.01f, 1f)]
	private float threshold = 0.45f;

	// Token: 0x0400492F RID: 18735
	[SerializeField]
	[Range(0f, 1f)]
	private float edgeOpacity = 1f;

	// Token: 0x04004930 RID: 18736
	[Space(5f)]
	[Header("Overlay")]
	[SerializeField]
	private Color overlayTop = new Color32(233, 0, byte.MaxValue, byte.MaxValue);

	// Token: 0x04004931 RID: 18737
	[SerializeField]
	private Color overlayBottom = new Color32(0, 38, byte.MaxValue, byte.MaxValue);

	// Token: 0x04004932 RID: 18738
	[SerializeField]
	[Range(0f, 1f)]
	private float overlayOpacity = 0.06f;

	// Token: 0x04004933 RID: 18739
	private Color[] hTargets = new Color[100];

	// Token: 0x04004934 RID: 18740
	private float[] hThresholds = new float[100];

	// Token: 0x04004935 RID: 18741
	private Color[] hColors = new Color[100];

	// Token: 0x04004936 RID: 18742
	private float[] hColorInterpolations = new float[100];

	// Token: 0x04004937 RID: 18743
	private Camera camera;

	// Token: 0x04004938 RID: 18744
	private Material post;
}
