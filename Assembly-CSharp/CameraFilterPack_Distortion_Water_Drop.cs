using System;
using UnityEngine;

// Token: 0x02000183 RID: 387
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Water_Drop")]
public class CameraFilterPack_Distortion_Water_Drop : MonoBehaviour
{
	// Token: 0x17000288 RID: 648
	// (get) Token: 0x06000DD3 RID: 3539 RVA: 0x00077864 File Offset: 0x00075A64
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

	// Token: 0x06000DD4 RID: 3540 RVA: 0x00077898 File Offset: 0x00075A98
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Water_Drop");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DD5 RID: 3541 RVA: 0x000778BC File Offset: 0x00075ABC
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
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			this.material.SetFloat("_CenterX", this.CenterX);
			this.material.SetFloat("_CenterY", this.CenterY);
			this.material.SetFloat("_WaveIntensity", this.WaveIntensity);
			this.material.SetInt("_NumberOfWaves", this.NumberOfWaves);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DD6 RID: 3542 RVA: 0x000779AD File Offset: 0x00075BAD
	private void Update()
	{
	}

	// Token: 0x06000DD7 RID: 3543 RVA: 0x000779AF File Offset: 0x00075BAF
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001213 RID: 4627
	public Shader SCShader;

	// Token: 0x04001214 RID: 4628
	private float TimeX = 1f;

	// Token: 0x04001215 RID: 4629
	private Material SCMaterial;

	// Token: 0x04001216 RID: 4630
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x04001217 RID: 4631
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x04001218 RID: 4632
	[Range(0f, 10f)]
	public float WaveIntensity = 1f;

	// Token: 0x04001219 RID: 4633
	[Range(0f, 20f)]
	public int NumberOfWaves = 5;
}
