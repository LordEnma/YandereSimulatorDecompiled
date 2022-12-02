using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkinnedMeshUpdater : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public SkinnedMeshRenderer newMeshRenderer;

		public int boneOrder;

		public Predicate<Transform> _003C_003E9__0;

		internal bool _003CUpdateMeshRenderer_003Eb__0(Transform c)
		{
			return c.name == newMeshRenderer.bones[boneOrder].name;
		}
	}

	public SkinnedMeshRenderer MyRenderer;

	public GameObject TransformEffect;

	public GameObject[] Characters;

	public PromptScript Prompt;

	public GameObject BreastR;

	public GameObject BreastL;

	public GameObject FumiGlasses;

	public GameObject NinaGlasses;

	private SkinnedMeshRenderer TempRenderer;

	public Texture[] Bodies;

	public Texture[] Faces;

	public float Timer;

	public int ID;

	public void Start()
	{
		GlassesCheck();
	}

	public void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			UnityEngine.Object.Instantiate(TransformEffect, Prompt.Yandere.Hips.position, Quaternion.identity);
			Prompt.Yandere.CharacterAnimation.Play(Prompt.Yandere.IdleAnim);
			Prompt.Yandere.CanMove = false;
			Prompt.Yandere.Egg = true;
			BreastR.name = "RightBreast";
			BreastL.name = "LeftBreast";
			Timer = 1f;
			ID++;
			if (ID == Characters.Length)
			{
				ID = 1;
			}
			Prompt.Yandere.Hairstyle = 120 + ID;
			Prompt.Yandere.UpdateHair();
			GlassesCheck();
			UpdateSkin();
		}
		if (Timer > 0f)
		{
			Timer = Mathf.MoveTowards(Timer, 0f, Time.deltaTime);
			if (Timer == 0f)
			{
				Prompt.Yandere.CanMove = true;
			}
		}
	}

	public void UpdateSkin()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(Characters[ID], Vector3.zero, Quaternion.identity);
		TempRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		UpdateMeshRenderer(TempRenderer);
		UnityEngine.Object.Destroy(gameObject);
		MyRenderer.materials[0].mainTexture = Bodies[ID];
		MyRenderer.materials[1].mainTexture = Bodies[ID];
		MyRenderer.materials[2].mainTexture = Faces[ID];
	}

	private void UpdateMeshRenderer(SkinnedMeshRenderer newMeshRenderer)
	{
		_003C_003Ec__DisplayClass16_0 _003C_003Ec__DisplayClass16_ = new _003C_003Ec__DisplayClass16_0();
		_003C_003Ec__DisplayClass16_.newMeshRenderer = newMeshRenderer;
		SkinnedMeshRenderer myRenderer = Prompt.Yandere.MyRenderer;
		myRenderer.sharedMesh = _003C_003Ec__DisplayClass16_.newMeshRenderer.sharedMesh;
		Transform[] componentsInChildren = Prompt.Yandere.transform.GetComponentsInChildren<Transform>(true);
		Transform[] array = new Transform[_003C_003Ec__DisplayClass16_.newMeshRenderer.bones.Length];
		_003C_003Ec__DisplayClass16_.boneOrder = 0;
		while (_003C_003Ec__DisplayClass16_.boneOrder < _003C_003Ec__DisplayClass16_.newMeshRenderer.bones.Length)
		{
			array[_003C_003Ec__DisplayClass16_.boneOrder] = Array.Find(componentsInChildren, _003C_003Ec__DisplayClass16_._003C_003E9__0 ?? (_003C_003Ec__DisplayClass16_._003C_003E9__0 = _003C_003Ec__DisplayClass16_._003CUpdateMeshRenderer_003Eb__0));
			_003C_003Ec__DisplayClass16_.boneOrder++;
		}
		myRenderer.bones = array;
	}

	private void GlassesCheck()
	{
		FumiGlasses.SetActive(false);
		NinaGlasses.SetActive(false);
		if (ID == 7)
		{
			FumiGlasses.SetActive(true);
		}
		else if (ID == 8)
		{
			NinaGlasses.SetActive(true);
		}
	}
}
