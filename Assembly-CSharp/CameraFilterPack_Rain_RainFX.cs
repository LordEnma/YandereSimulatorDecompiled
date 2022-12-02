using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/New Rain FX")]
public class CameraFilterPack_Rain_RainFX : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	private Material SCMaterial;

	[Range(-8f, 8f)]
	public float Speed = 1f;

	[Range(0f, 1f)]
	public float Fade = 1f;

	[HideInInspector]
	public int Count;

	private Vector4[] Coord = new Vector4[4];

	public static Color ChangeColorRGB;

	private Texture2D Texture2;

	private Texture2D Texture3;

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
		Texture2 = Resources.Load("CameraFilterPack_RainFX_Anm2") as Texture2D;
		Texture3 = Resources.Load("CameraFilterPack_RainFX_Anm") as Texture2D;
		SCShader = Shader.Find("CameraFilterPack/RainFX");
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
			material.SetFloat("_Value", Fade);
			material.SetFloat("_Speed", Speed);
			material.SetVector("_ScreenResolution", new Vector4(sourceTexture.width, sourceTexture.height, 0f, 0f));
			GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			AnimationCurve animationCurve = new AnimationCurve();
			animationCurve = new AnimationCurve();
			animationCurve.AddKey(0f, 0.01f);
			animationCurve.AddKey(64f, 5f);
			animationCurve.AddKey(128f, 80f);
			animationCurve.AddKey(255f, 255f);
			animationCurve.AddKey(300f, 255f);
			for (int i = 0; i < 4; i++)
			{
				Coord[i].z += 0.5f;
				if (Coord[i].w == -1f)
				{
					Coord[i].x = -5f;
				}
				if (Coord[i].z > 254f)
				{
					Coord[i] = new Vector4(Random.Range(0f, 0.9f), Random.Range(0.2f, 1.1f), 0f, Random.Range(0, 3));
				}
				material.SetVector("Coord" + (i + 1), new Vector4(Coord[i].x, Coord[i].y, (int)animationCurve.Evaluate(Coord[i].z), Coord[i].w));
			}
			material.SetTexture("Texture2", Texture2);
			material.SetTexture("Texture3", Texture3);
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
