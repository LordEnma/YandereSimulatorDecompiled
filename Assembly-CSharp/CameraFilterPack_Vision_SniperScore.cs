using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/SniperScore")]
public class CameraFilterPack_Vision_SniperScore : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	private Material SCMaterial;

	[Range(0f, 1f)]
	public float Fade = 1f;

	[Range(0f, 1f)]
	public float Size = 0.45f;

	[Range(0.01f, 0.4f)]
	public float Smooth = 0.045f;

	[Range(0f, 1f)]
	public float _Cible = 0.5f;

	[Range(0f, 1f)]
	public float _Distortion = 0.5f;

	[Range(0f, 1f)]
	public float _ExtraColor = 0.5f;

	[Range(0f, 1f)]
	public float _ExtraLight = 0.35f;

	public Color _Tint = new Color(0f, 0.6f, 0f, 0.25f);

	[Range(0f, 10f)]
	private float StretchX = 1f;

	[Range(0f, 10f)]
	private float StretchY = 1f;

	[Range(-1f, 1f)]
	public float _PosX;

	[Range(-1f, 1f)]
	public float _PosY;

	private Material material
	{
		get
		{
			if (SCMaterial == null)
			{
				SCMaterial = new Material(SCShader);
				SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return SCMaterial;
		}
	}

	private void Start()
	{
		SCShader = Shader.Find("CameraFilterPack/Vision_SniperScore");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
		}
	}

	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (SCShader != null)
		{
			TimeX += Time.deltaTime;
			if (TimeX > 100f)
			{
				TimeX = 0f;
			}
			material.SetFloat("_Fade", Fade);
			material.SetFloat("_TimeX", TimeX);
			material.SetFloat("_Value", Size);
			material.SetFloat("_Value2", Smooth);
			material.SetFloat("_Value3", StretchX);
			material.SetFloat("_Value4", StretchY);
			material.SetFloat("_Cible", _Cible);
			material.SetFloat("_ExtraColor", _ExtraColor);
			material.SetFloat("_Distortion", _Distortion);
			material.SetFloat("_PosX", _PosX);
			material.SetFloat("_PosY", _PosY);
			material.SetColor("_Tint", _Tint);
			material.SetFloat("_ExtraLight", _ExtraLight);
			Vector2 vector = new Vector2(Screen.width, Screen.height);
			material.SetVector("_ScreenResolution", new Vector4(vector.x, vector.y, vector.y / vector.x, 0f));
			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
		if ((bool)SCMaterial)
		{
			Object.DestroyImmediate(SCMaterial);
		}
	}
}
