using System;
using UnityEngine;

// Token: 0x02000132 RID: 306
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/HardMix")]
public class CameraFilterPack_Blend2Camera_HardMix : MonoBehaviour
{
	// Token: 0x17000237 RID: 567
	// (get) Token: 0x06000BC4 RID: 3012 RVA: 0x0006E467 File Offset: 0x0006C667
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

	// Token: 0x06000BC5 RID: 3013 RVA: 0x0006E49C File Offset: 0x0006C69C
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000BC6 RID: 3014 RVA: 0x0006E500 File Offset: 0x0006C700
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x0006E5F0 File Offset: 0x0006C7F0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x0006E628 File Offset: 0x0006C828
	private void Update()
	{
	}

	// Token: 0x06000BC9 RID: 3017 RVA: 0x0006E62A File Offset: 0x0006C82A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BCA RID: 3018 RVA: 0x0006E662 File Offset: 0x0006C862
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000FF7 RID: 4087
	private string ShaderName = "CameraFilterPack/Blend2Camera_HardMix";

	// Token: 0x04000FF8 RID: 4088
	public Shader SCShader;

	// Token: 0x04000FF9 RID: 4089
	public Camera Camera2;

	// Token: 0x04000FFA RID: 4090
	private float TimeX = 1f;

	// Token: 0x04000FFB RID: 4091
	private Material SCMaterial;

	// Token: 0x04000FFC RID: 4092
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FFD RID: 4093
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FFE RID: 4094
	private RenderTexture Camera2tex;
}
