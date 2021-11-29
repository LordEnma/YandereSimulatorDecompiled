using System;
using UnityEngine;

// Token: 0x02000141 RID: 321
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Split Screen/SideBySide")]
public class CameraFilterPack_Blend2Camera_SplitScreen : MonoBehaviour
{
	// Token: 0x17000246 RID: 582
	// (get) Token: 0x06000C3D RID: 3133 RVA: 0x00070A27 File Offset: 0x0006EC27
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

	// Token: 0x06000C3E RID: 3134 RVA: 0x00070A5B File Offset: 0x0006EC5B
	private void OnValidate()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000C3F RID: 3135 RVA: 0x00070A80 File Offset: 0x0006EC80
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture((int)this.ScreenSize.x, (int)this.ScreenSize.y, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C40 RID: 3136 RVA: 0x00070AF4 File Offset: 0x0006ECF4
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
			this.material.SetFloat("_Value3", this.SplitX);
			this.material.SetFloat("_Value6", this.SplitY);
			this.material.SetFloat("_Value4", this.Smooth);
			this.material.SetFloat("_Value5", this.Rotation);
			this.material.SetInt("_ForceYSwap", this.ForceYSwap ? 0 : 1);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C41 RID: 3137 RVA: 0x00070C2B File Offset: 0x0006EE2B
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000C42 RID: 3138 RVA: 0x00070C4F File Offset: 0x0006EE4F
	private void OnEnable()
	{
		this.Start();
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x00070C57 File Offset: 0x0006EE57
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

	// Token: 0x04001071 RID: 4209
	private string ShaderName = "CameraFilterPack/Blend2Camera_SplitScreen";

	// Token: 0x04001072 RID: 4210
	public Shader SCShader;

	// Token: 0x04001073 RID: 4211
	public Camera Camera2;

	// Token: 0x04001074 RID: 4212
	private float TimeX = 1f;

	// Token: 0x04001075 RID: 4213
	private Material SCMaterial;

	// Token: 0x04001076 RID: 4214
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001077 RID: 4215
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04001078 RID: 4216
	[Range(-3f, 3f)]
	public float SplitX = 0.5f;

	// Token: 0x04001079 RID: 4217
	[Range(-3f, 3f)]
	public float SplitY = 0.5f;

	// Token: 0x0400107A RID: 4218
	[Range(0f, 2f)]
	public float Smooth = 0.1f;

	// Token: 0x0400107B RID: 4219
	[Range(-3.14f, 3.14f)]
	public float Rotation = 3.14f;

	// Token: 0x0400107C RID: 4220
	private bool ForceYSwap;

	// Token: 0x0400107D RID: 4221
	private RenderTexture Camera2tex;

	// Token: 0x0400107E RID: 4222
	private Vector2 ScreenSize;
}
