using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Chroma Key/BlueScreen")]
public class CameraFilterPack_Blend2Camera_BlueScreen : MonoBehaviour
{
	private string ShaderName = "CameraFilterPack/Blend2Camera_BlueScreen";

	public Shader SCShader;

	public Camera Camera2;

	private float TimeX = 1f;

	private Material SCMaterial;

	[Range(0f, 1f)]
	public float BlendFX = 1f;

	[Range(-0.2f, 0.2f)]
	public float Adjust;

	[Range(-0.2f, 0.2f)]
	public float Precision;

	[Range(-0.2f, 0.2f)]
	public float Luminosity;

	[Range(-0.3f, 0.3f)]
	public float Change_Red;

	[Range(-0.3f, 0.3f)]
	public float Change_Green;

	[Range(-0.3f, 0.3f)]
	public float Change_Blue;

	private RenderTexture Camera2tex;

	private Vector2 ScreenSize;

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

	private void OnValidate()
	{
		ScreenSize.x = Screen.width;
		ScreenSize.y = Screen.height;
	}

	private void Start()
	{
		if (Camera2 != null)
		{
			Camera2tex = new RenderTexture((int)ScreenSize.x, (int)ScreenSize.y, 24);
			Camera2.targetTexture = Camera2tex;
		}
		SCShader = Shader.Find(ShaderName);
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
			if (Camera2 != null)
			{
				material.SetTexture("_MainTex2", Camera2tex);
			}
			material.SetFloat("_TimeX", TimeX);
			material.SetFloat("_Value", BlendFX);
			material.SetFloat("_Value2", Adjust);
			material.SetFloat("_Value3", Precision);
			material.SetFloat("_Value4", Luminosity);
			material.SetFloat("_Value5", Change_Red);
			material.SetFloat("_Value6", Change_Green);
			material.SetFloat("_Value7", Change_Blue);
			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}

	private void Update()
	{
		ScreenSize.x = Screen.width;
		ScreenSize.y = Screen.height;
		_ = Application.isPlaying;
	}

	private void OnEnable()
	{
		Start();
	}

	private void OnDisable()
	{
		if (Camera2 != null)
		{
			Camera2.targetTexture = null;
		}
		if ((bool)SCMaterial)
		{
			Object.DestroyImmediate(SCMaterial);
		}
	}
}
