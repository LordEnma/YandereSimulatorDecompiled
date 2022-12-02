using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Split Screen/SideBySide")]
public class CameraFilterPack_Blend2Camera_SplitScreen : MonoBehaviour
{
	private string ShaderName = "CameraFilterPack/Blend2Camera_SplitScreen";

	public Shader SCShader;

	public Camera Camera2;

	private float TimeX = 1f;

	private Material SCMaterial;

	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	[Range(0f, 1f)]
	public float BlendFX = 1f;

	[Range(-3f, 3f)]
	public float SplitX = 0.5f;

	[Range(-3f, 3f)]
	public float SplitY = 0.5f;

	[Range(0f, 2f)]
	public float Smooth = 0.1f;

	[Range(-3.14f, 3.14f)]
	public float Rotation = 3.14f;

	private bool ForceYSwap;

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
			material.SetFloat("_Value2", SwitchCameraToCamera2);
			material.SetFloat("_Value3", SplitX);
			material.SetFloat("_Value6", SplitY);
			material.SetFloat("_Value4", Smooth);
			material.SetFloat("_Value5", Rotation);
			material.SetInt("_ForceYSwap", (!ForceYSwap) ? 1 : 0);
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
