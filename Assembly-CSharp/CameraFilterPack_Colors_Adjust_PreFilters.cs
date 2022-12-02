using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/Photo Filters")]
public class CameraFilterPack_Colors_Adjust_PreFilters : MonoBehaviour
{
	public enum filters
	{
		Normal = 0,
		BlueLagoon = 1,
		BlueMoon = 2,
		RedWhite = 3,
		NashVille = 4,
		VintageYellow = 5,
		GoldenPink = 6,
		DarkPink = 7,
		PopRocket = 8,
		RedSoftLight = 9,
		YellowSunSet = 10,
		Walden = 11,
		WhiteShine = 12,
		Fluo = 13,
		MarsSunRise = 14,
		Amelie = 15,
		BlueJeans = 16,
		NightVision = 17,
		BlueParadise = 18,
		Blindness_Deuteranomaly = 19,
		Blindness_Protanopia = 20,
		Blindness_Protanomaly = 21,
		Blindness_Deuteranopia = 22,
		Blindness_Tritanomaly = 23,
		Blindness_Achromatopsia = 24,
		Blindness_Achromatomaly = 25,
		Blindness_Tritanopia = 26,
		BlackAndWhite_Blue = 27,
		BlackAndWhite_Green = 28,
		BlackAndWhite_Orange = 29,
		BlackAndWhite_Red = 30,
		BlackAndWhite_Yellow = 31
	}

	private string ShaderName = "CameraFilterPack/Colors_Adjust_PreFilters";

	public Shader SCShader;

	public filters filterchoice;

	[Range(0f, 1f)]
	public float FadeFX = 1f;

	private float TimeX = 1f;

	private Material SCMaterial;

	private float[] Matrix9;

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
		if (filterchoice == filters.Normal)
		{
			Matrix9 = new float[12]
			{
				100f, 0f, 0f, 0f, 100f, 0f, 0f, 0f, 100f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.Blindness_Deuteranomaly)
		{
			Matrix9 = new float[12]
			{
				80f, 20f, 0f, 25.833f, 74.167f, 0f, 0f, 14.167f, 85.833f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.Blindness_Protanopia)
		{
			Matrix9 = new float[12]
			{
				56.667f, 43.333f, 0f, 55.833f, 44.167f, 0f, 0f, 24.167f, 75.833f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.Blindness_Protanomaly)
		{
			Matrix9 = new float[12]
			{
				81.667f, 18.333f, 0f, 33.333f, 66.667f, 0f, 0f, 12.5f, 87.5f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.Blindness_Deuteranopia)
		{
			Matrix9 = new float[12]
			{
				62.5f, 37.5f, 0f, 70f, 30f, 0f, 0f, 30f, 70f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.Blindness_Tritanomaly)
		{
			Matrix9 = new float[12]
			{
				96.667f, 3.333f, 0f, 0f, 73.333f, 26.667f, 0f, 18.333f, 81.667f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.Blindness_Achromatopsia)
		{
			Matrix9 = new float[12]
			{
				29.9f, 58.7f, 11.4f, 29.9f, 58.7f, 11.4f, 29.9f, 58.7f, 11.4f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.Blindness_Achromatomaly)
		{
			Matrix9 = new float[12]
			{
				61.8f, 32f, 6.2f, 16.3f, 77.5f, 6.2f, 16.3f, 32f, 51.6f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.Blindness_Tritanopia)
		{
			Matrix9 = new float[12]
			{
				95f, 5f, 0f, 0f, 43.333f, 56.667f, 0f, 47.5f, 52.5f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.BlueLagoon)
		{
			Matrix9 = new float[12]
			{
				100f, 102f, 0f, 18f, 100f, 4f, 28f, -26f, 100f, -64f,
				0f, 12f
			};
		}
		if (filterchoice == filters.GoldenPink)
		{
			Matrix9 = new float[12]
			{
				70f, 200f, 0f, 0f, 100f, 8f, 6f, 12f, 110f, 0f,
				0f, -6f
			};
		}
		if (filterchoice == filters.BlueMoon)
		{
			Matrix9 = new float[12]
			{
				200f, 98f, -116f, 24f, 100f, 2f, 30f, 52f, 20f, -48f,
				-20f, 12f
			};
		}
		if (filterchoice == filters.DarkPink)
		{
			Matrix9 = new float[12]
			{
				60f, 112f, 36f, 24f, 100f, 2f, 0f, -26f, 100f, -56f,
				-20f, 12f
			};
		}
		if (filterchoice == filters.RedWhite)
		{
			Matrix9 = new float[12]
			{
				-42f, 68f, 108f, -96f, 100f, 116f, -92f, 104f, 96f, 0f,
				2f, 4f
			};
		}
		if (filterchoice == filters.VintageYellow)
		{
			Matrix9 = new float[12]
			{
				200f, 109f, -104f, 42f, 126f, -1f, -40f, 121f, -31f, -48f,
				-20f, 12f
			};
		}
		if (filterchoice == filters.NashVille)
		{
			Matrix9 = new float[12]
			{
				130f, 8f, 7f, 19f, 89f, 3f, -1f, 11f, 57f, 10f,
				19f, 47f
			};
		}
		if (filterchoice == filters.PopRocket)
		{
			Matrix9 = new float[12]
			{
				100f, 6f, -17f, 0f, 107f, 0f, 10f, 21f, 100f, 40f,
				0f, 8f
			};
		}
		if (filterchoice == filters.RedSoftLight)
		{
			Matrix9 = new float[12]
			{
				-4f, 200f, -30f, -58f, 200f, -30f, -58f, 200f, -30f, -11f,
				0f, 0f
			};
		}
		if (filterchoice == filters.BlackAndWhite_Blue)
		{
			Matrix9 = new float[12]
			{
				0f, 0f, 100f, 0f, 0f, 100f, 0f, 0f, 100f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.BlackAndWhite_Green)
		{
			Matrix9 = new float[12]
			{
				0f, 100f, 0f, 0f, 100f, 0f, 0f, 100f, 0f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.BlackAndWhite_Orange)
		{
			Matrix9 = new float[12]
			{
				50f, 50f, 0f, 50f, 50f, 0f, 50f, 50f, 0f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.BlackAndWhite_Red)
		{
			Matrix9 = new float[12]
			{
				100f, 0f, 0f, 100f, 0f, 0f, 100f, 0f, 0f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.BlackAndWhite_Yellow)
		{
			Matrix9 = new float[12]
			{
				34f, 66f, 0f, 34f, 66f, 0f, 34f, 66f, 0f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.YellowSunSet)
		{
			Matrix9 = new float[12]
			{
				117f, -6f, 53f, -68f, 135f, 19f, -146f, -61f, 200f, 0f,
				0f, 0f
			};
		}
		if (filterchoice == filters.Walden)
		{
			Matrix9 = new float[12]
			{
				99f, 2f, 13f, 100f, 1f, 40f, 50f, 8f, 71f, 0f,
				2f, 7f
			};
		}
		if (filterchoice == filters.WhiteShine)
		{
			Matrix9 = new float[12]
			{
				190f, 24f, -33f, 2f, 200f, -6f, -10f, 27f, 200f, -6f,
				-13f, 15f
			};
		}
		if (filterchoice == filters.Fluo)
		{
			Matrix9 = new float[12]
			{
				100f, 0f, 0f, 0f, 113f, 0f, 200f, -200f, -200f, 0f,
				0f, 36f
			};
		}
		if (filterchoice == filters.MarsSunRise)
		{
			Matrix9 = new float[12]
			{
				50f, 141f, -81f, -17f, 62f, 29f, -159f, -137f, -200f, 7f,
				-34f, -6f
			};
		}
		if (filterchoice == filters.Amelie)
		{
			Matrix9 = new float[12]
			{
				100f, 11f, 39f, 1f, 63f, 53f, -24f, 71f, 20f, -25f,
				-10f, -24f
			};
		}
		if (filterchoice == filters.BlueJeans)
		{
			Matrix9 = new float[12]
			{
				181f, 11f, 15f, 40f, 40f, 20f, 40f, 40f, 20f, -59f,
				0f, 0f
			};
		}
		if (filterchoice == filters.NightVision)
		{
			Matrix9 = new float[12]
			{
				200f, -200f, -200f, 195f, 4f, -160f, 200f, -200f, -200f, -200f,
				10f, -200f
			};
		}
		if (filterchoice == filters.BlueParadise)
		{
			Matrix9 = new float[12]
			{
				66f, 200f, -200f, 25f, 38f, 36f, 30f, 150f, 114f, 17f,
				0f, 65f
			};
		}
	}

	private void Start()
	{
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
			material.SetFloat("_TimeX", TimeX);
			material.SetFloat("_Red_R", Matrix9[0] / 100f);
			material.SetFloat("_Red_G", Matrix9[1] / 100f);
			material.SetFloat("_Red_B", Matrix9[2] / 100f);
			material.SetFloat("_Green_R", Matrix9[3] / 100f);
			material.SetFloat("_Green_G", Matrix9[4] / 100f);
			material.SetFloat("_Green_B", Matrix9[5] / 100f);
			material.SetFloat("_Blue_R", Matrix9[6] / 100f);
			material.SetFloat("_Blue_G", Matrix9[7] / 100f);
			material.SetFloat("_Blue_B", Matrix9[8] / 100f);
			material.SetFloat("_Red_C", Matrix9[9] / 100f);
			material.SetFloat("_Green_C", Matrix9[10] / 100f);
			material.SetFloat("_Blue_C", Matrix9[11] / 100f);
			material.SetFloat("_FadeFX", FadeFX);
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
		ChangeFilters();
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
