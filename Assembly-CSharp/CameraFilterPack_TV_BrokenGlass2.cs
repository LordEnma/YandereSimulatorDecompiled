using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Broken Glass2")]
public class CameraFilterPack_TV_BrokenGlass2 : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	[Range(0f, 1f)]
	public float Bullet_1;

	[Range(0f, 1f)]
	public float Bullet_2;

	[Range(0f, 1f)]
	public float Bullet_3;

	[Range(0f, 1f)]
	public float Bullet_4 = 1f;

	[Range(0f, 1f)]
	public float Bullet_5;

	[Range(0f, 1f)]
	public float Bullet_6;

	[Range(0f, 1f)]
	public float Bullet_7;

	[Range(0f, 1f)]
	public float Bullet_8;

	[Range(0f, 1f)]
	public float Bullet_9;

	[Range(0f, 1f)]
	public float Bullet_10;

	[Range(0f, 1f)]
	public float Bullet_11;

	[Range(0f, 1f)]
	public float Bullet_12;

	private Material SCMaterial;

	private Texture2D Texture2;

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
		Texture2 = Resources.Load("CameraFilterPack_TV_BrokenGlass_2") as Texture2D;
		SCShader = Shader.Find("CameraFilterPack/TV_BrokenGlass2");
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
			if (Bullet_1 < 0f)
			{
				Bullet_1 = 0f;
			}
			if (Bullet_2 < 0f)
			{
				Bullet_2 = 0f;
			}
			if (Bullet_3 < 0f)
			{
				Bullet_3 = 0f;
			}
			if (Bullet_4 < 0f)
			{
				Bullet_4 = 0f;
			}
			if (Bullet_5 < 0f)
			{
				Bullet_5 = 0f;
			}
			if (Bullet_6 < 0f)
			{
				Bullet_6 = 0f;
			}
			if (Bullet_7 < 0f)
			{
				Bullet_7 = 0f;
			}
			if (Bullet_8 < 0f)
			{
				Bullet_8 = 0f;
			}
			if (Bullet_9 < 0f)
			{
				Bullet_9 = 0f;
			}
			if (Bullet_10 < 0f)
			{
				Bullet_10 = 0f;
			}
			if (Bullet_11 < 0f)
			{
				Bullet_11 = 0f;
			}
			if (Bullet_12 < 0f)
			{
				Bullet_12 = 0f;
			}
			if (Bullet_1 > 1f)
			{
				Bullet_1 = 1f;
			}
			if (Bullet_2 > 1f)
			{
				Bullet_2 = 1f;
			}
			if (Bullet_3 > 1f)
			{
				Bullet_3 = 1f;
			}
			if (Bullet_4 > 1f)
			{
				Bullet_4 = 1f;
			}
			if (Bullet_5 > 1f)
			{
				Bullet_5 = 1f;
			}
			if (Bullet_6 > 1f)
			{
				Bullet_6 = 1f;
			}
			if (Bullet_7 > 1f)
			{
				Bullet_7 = 1f;
			}
			if (Bullet_8 > 1f)
			{
				Bullet_8 = 1f;
			}
			if (Bullet_9 > 1f)
			{
				Bullet_9 = 1f;
			}
			if (Bullet_10 > 1f)
			{
				Bullet_10 = 1f;
			}
			if (Bullet_11 > 1f)
			{
				Bullet_11 = 1f;
			}
			if (Bullet_12 > 1f)
			{
				Bullet_12 = 1f;
			}
			material.SetFloat("_Bullet_1", Bullet_1);
			material.SetFloat("_Bullet_2", Bullet_2);
			material.SetFloat("_Bullet_3", Bullet_3);
			material.SetFloat("_Bullet_4", Bullet_4);
			material.SetFloat("_Bullet_5", Bullet_5);
			material.SetFloat("_Bullet_6", Bullet_6);
			material.SetFloat("_Bullet_7", Bullet_7);
			material.SetFloat("_Bullet_8", Bullet_8);
			material.SetFloat("_Bullet_9", Bullet_9);
			material.SetFloat("_Bullet_10", Bullet_10);
			material.SetFloat("_Bullet_11", Bullet_11);
			material.SetFloat("_Bullet_12", Bullet_12);
			material.SetTexture("_MainTex2", Texture2);
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
