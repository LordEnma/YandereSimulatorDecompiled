using System;
using UnityEngine;

// Token: 0x020001FD RID: 509
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Weather/New Rain FX")]
public class CameraFilterPack_Rain_RainFX : MonoBehaviour
{
	// Token: 0x17000301 RID: 769
	// (get) Token: 0x060010D0 RID: 4304 RVA: 0x000854AF File Offset: 0x000836AF
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x060010D1 RID: 4305 RVA: 0x000854E4 File Offset: 0x000836E4
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_RainFX_Anm2") as Texture2D);
		this.Texture3 = (Resources.Load("CameraFilterPack_RainFX_Anm") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/RainFX");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010D2 RID: 4306 RVA: 0x0008553C File Offset: 0x0008373C
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.Fade);
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			AnimationCurve animationCurve = new AnimationCurve();
			animationCurve = new AnimationCurve();
			animationCurve.AddKey(0f, 0.01f);
			animationCurve.AddKey(64f, 5f);
			animationCurve.AddKey(128f, 80f);
			animationCurve.AddKey(255f, 255f);
			animationCurve.AddKey(300f, 255f);
			for (int i = 0; i < 4; i++)
			{
				Vector4[] coord = this.Coord;
				int num = i;
				coord[num].z = coord[num].z + 0.5f;
				if (this.Coord[i].w == -1f)
				{
					this.Coord[i].x = -5f;
				}
				if (this.Coord[i].z > 254f)
				{
					this.Coord[i] = new Vector4(UnityEngine.Random.Range(0f, 0.9f), UnityEngine.Random.Range(0.2f, 1.1f), 0f, (float)UnityEngine.Random.Range(0, 3));
				}
				this.material.SetVector("Coord" + (i + 1).ToString(), new Vector4(this.Coord[i].x, this.Coord[i].y, (float)((int)animationCurve.Evaluate(this.Coord[i].z)), this.Coord[i].w));
			}
			this.material.SetTexture("Texture2", this.Texture2);
			this.material.SetTexture("Texture3", this.Texture3);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010D3 RID: 4307 RVA: 0x000857C0 File Offset: 0x000839C0
	private void Update()
	{
	}

	// Token: 0x060010D4 RID: 4308 RVA: 0x000857C2 File Offset: 0x000839C2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001564 RID: 5476
	public Shader SCShader;

	// Token: 0x04001565 RID: 5477
	private float TimeX = 1f;

	// Token: 0x04001566 RID: 5478
	private Material SCMaterial;

	// Token: 0x04001567 RID: 5479
	[Range(-8f, 8f)]
	public float Speed = 1f;

	// Token: 0x04001568 RID: 5480
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001569 RID: 5481
	[HideInInspector]
	public int Count;

	// Token: 0x0400156A RID: 5482
	private Vector4[] Coord = new Vector4[4];

	// Token: 0x0400156B RID: 5483
	public static Color ChangeColorRGB;

	// Token: 0x0400156C RID: 5484
	private Texture2D Texture2;

	// Token: 0x0400156D RID: 5485
	private Texture2D Texture3;
}
