using System;
using UnityEngine;

// Token: 0x020000BB RID: 187
public class RPG_Animation_CharacterFadeOnly : MonoBehaviour
{
	// Token: 0x0600097A RID: 2426 RVA: 0x0004B6C2 File Offset: 0x000498C2
	private void Awake()
	{
		RPG_Animation_CharacterFadeOnly.instance = this;
	}

	// Token: 0x0400080A RID: 2058
	public static RPG_Animation_CharacterFadeOnly instance;
}
