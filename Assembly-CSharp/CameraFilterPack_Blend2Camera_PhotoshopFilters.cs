using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/PhotoshopFilters")]
public class CameraFilterPack_Blend2Camera_PhotoshopFilters : MonoBehaviour
{
	public enum filters
	{
		Darken = 0,
		Multiply = 1,
		ColorBurn = 2,
		LinearBurn = 3,
		DarkerColor = 4,
		Lighten = 5,
		Screen = 6,
		ColorDodge = 7,
		LinearDodge = 8,
		LighterColor = 9,
		Overlay = 10,
		SoftLight = 11,
		HardLight = 12,
		VividLight = 13,
		LinearLight = 14,
		PinLight = 15,
		HardMix = 16,
		Difference = 17,
		Exclusion = 18,
		Subtract = 19,
		Divide = 20,
		Hue = 21,
		Saturation = 22,
		Color = 23,
		Luminosity = 24
	}

	private string ShaderName = "CameraFilterPack/Blend2Camera_Darken";

	public Shader SCShader;

	public Camera Camera2;

	public filters filterchoice;

	private filters filterchoicememo;

	private float TimeX = 1f;

	private Material SCMaterial;

	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	private RenderTexture Camera2tex;

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

	private void ChangeFilters()
	{
		if (filterchoice == filters.Darken)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Darken";
		}
		if (filterchoice == filters.Multiply)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Multiply";
		}
		if (filterchoice == filters.ColorBurn)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_ColorBurn";
		}
		if (filterchoice == filters.LinearBurn)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_LinearBurn";
		}
		if (filterchoice == filters.DarkerColor)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_DarkerColor";
		}
		if (filterchoice == filters.Lighten)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Lighten";
		}
		if (filterchoice == filters.Screen)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Screen";
		}
		if (filterchoice == filters.ColorDodge)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_ColorDodge";
		}
		if (filterchoice == filters.LinearDodge)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_LinearDodge";
		}
		if (filterchoice == filters.LighterColor)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_LighterColor";
		}
		if (filterchoice == filters.Overlay)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Overlay";
		}
		if (filterchoice == filters.SoftLight)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_SoftLight";
		}
		if (filterchoice == filters.HardLight)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_HardLight";
		}
		if (filterchoice == filters.VividLight)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_VividLight";
		}
		if (filterchoice == filters.LinearLight)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_LinearLight";
		}
		if (filterchoice == filters.PinLight)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_PinLight";
		}
		if (filterchoice == filters.HardMix)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_HardMix";
		}
		if (filterchoice == filters.Difference)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Difference";
		}
		if (filterchoice == filters.Exclusion)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Exclusion";
		}
		if (filterchoice == filters.Subtract)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Subtract";
		}
		if (filterchoice == filters.Divide)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Divide";
		}
		if (filterchoice == filters.Hue)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Hue";
		}
		if (filterchoice == filters.Saturation)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Saturation";
		}
		if (filterchoice == filters.Color)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Color";
		}
		if (filterchoice == filters.Luminosity)
		{
			ShaderName = "CameraFilterPack/Blend2Camera_Luminosity";
		}
	}

	private void Start()
	{
		filterchoicememo = filterchoice;
		if (Camera2 != null)
		{
			Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			Camera2.targetTexture = Camera2tex;
		}
		ChangeFilters();
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
			material.SetVector("_ScreenResolution", new Vector4(sourceTexture.width, sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}

	private void OnValidate()
	{
		if (filterchoice != filterchoicememo)
		{
			ChangeFilters();
			SCShader = Shader.Find(ShaderName);
			Object.DestroyImmediate(SCMaterial);
			if (SCMaterial == null)
			{
				SCMaterial = new Material(SCShader);
				SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
		}
		filterchoicememo = filterchoice;
		if (Camera2 != null)
		{
			Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			Camera2.targetTexture = Camera2tex;
		}
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
		if (Camera2 != null)
		{
			Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			Camera2.targetTexture = Camera2tex;
		}
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
