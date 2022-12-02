using UnityEngine;

[ExecuteInEditMode]
public class BlacklightEffect : MonoBehaviour
{
	[SerializeField]
	private Color fogColorDark = new Color32(14, 11, 31, byte.MaxValue);

	[SerializeField]
	private Color fogColorLight = new Color32(87, 89, 111, byte.MaxValue);

	[SerializeField]
	[Range(0f, 1f)]
	private float fogOpacity = 1f;

	[SerializeField]
	private float fogDepth = 8f;

	[Space(5f)]
	[Header("Glow")]
	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColor = new Color(0f, 41f / 85f, 0.7490196f) * 9f;

	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColorSecondary = new Color(0.7490196f, 0f, 0.6784314f) * 9f;

	[SerializeField]
	private float glowBias = 13f;

	[SerializeField]
	[Range(0f, 1f)]
	private float glowFlip;

	[SerializeField]
	private bool glow = true;

	[Space(5f)]
	[Header("Targetted highlighting")]
	[SerializeField]
	private HighlightTarget[] highlightTargets;

	[SerializeField]
	[Range(0f, 1f)]
	private float smoothDropoff;

	[Space(5f)]
	[Header("Edge")]
	[SerializeField]
	private Color edgeColor = new Color32(7, byte.MaxValue, 83, byte.MaxValue);

	[SerializeField]
	[Range(0.01f, 1f)]
	private float threshold = 0.45f;

	[SerializeField]
	[Range(0f, 1f)]
	private float edgeOpacity = 1f;

	[Space(5f)]
	[Header("Overlay")]
	[SerializeField]
	private Color overlayTop = new Color32(233, 0, byte.MaxValue, byte.MaxValue);

	[SerializeField]
	private Color overlayBottom = new Color32(0, 38, byte.MaxValue, byte.MaxValue);

	[SerializeField]
	[Range(0f, 1f)]
	private float overlayOpacity = 0.06f;

	private Color[] hTargets = new Color[100];

	private float[] hThresholds = new float[100];

	private Color[] hColors = new Color[100];

	private float[] hColorInterpolations = new float[100];

	private Camera camera;

	private Material post;

	private void Update()
	{
		if (camera != null)
		{
			camera.depthTextureMode = DepthTextureMode.Depth | DepthTextureMode.DepthNormals;
		}
		if (!(post != null))
		{
			return;
		}
		post.SetFloat("_DepthDistance", fogDepth);
		post.SetColor("_FogColorDark", fogColorDark);
		post.SetColor("_FogColorLight", fogColorLight);
		post.SetFloat("_FogOpacity", fogOpacity);
		post.SetFloat("_GlowBias", glowBias);
		post.SetColor("_GlowColor", glowColor);
		post.SetColor("_GlowColor2", glowColorSecondary);
		post.SetFloat("_GlowAmount", glow ? 1 : 0);
		post.SetColor("_EdgeColor", edgeColor);
		post.SetFloat("_EdgeThreshold", threshold);
		post.SetFloat("_EdgeStrength", edgeOpacity);
		post.SetColor("_OverlayTop", overlayTop);
		post.SetColor("_OverlayBottom", overlayBottom);
		post.SetFloat("_OverlayOpacity", overlayOpacity);
		post.SetFloat("_HighlightFlip", glowFlip);
		post.SetFloat("_HighlightTargetSmooth", smoothDropoff);
		if (highlightTargets != null)
		{
			for (int i = 0; i < highlightTargets.Length; i++)
			{
				hTargets[i] = highlightTargets[i].TargetColor;
				hThresholds[i] = highlightTargets[i].Threshold;
				hColors[i] = highlightTargets[i].ReplacementColor;
				hColorInterpolations[i] = highlightTargets[i].SmoothColorInterpolation;
			}
		}
		if (highlightTargets != null && highlightTargets.Length != 0)
		{
			post.SetInt("_HighlightTargetsLength", Mathf.Clamp(highlightTargets.Length, 0, 100));
		}
		post.SetColorArray("_HighlightTargets", hTargets);
		post.SetFloatArray("_HighlightTargetThresholds", hThresholds);
		post.SetColorArray("_HighlightColors", hColors);
		post.SetFloatArray("_SmoothColorInterpolations", hColorInterpolations);
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (camera == null)
		{
			camera = GetComponent<Camera>();
			return;
		}
		if (post == null)
		{
			post = new Material(Shader.Find("Abcight/BlacklightPost"));
		}
		Graphics.Blit(source, destination, post);
	}

	[ContextMenu("Refresh")]
	public void Refresh()
	{
		Object.DestroyImmediate(post);
		post = null;
	}
}
