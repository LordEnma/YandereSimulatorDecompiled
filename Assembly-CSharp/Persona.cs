using System;
using UnityEngine;

// Token: 0x020002B1 RID: 689
[Serializable]
public class Persona
{
	// Token: 0x06001450 RID: 5200 RVA: 0x000C6166 File Offset: 0x000C4366
	public Persona(PersonaType type)
	{
		this.type = type;
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x06001451 RID: 5201 RVA: 0x000C6175 File Offset: 0x000C4375
	public PersonaType Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04001F32 RID: 7986
	[SerializeField]
	private PersonaType type;

	// Token: 0x04001F33 RID: 7987
	public static readonly PersonaTypeAndStringDictionary PersonaNames = new PersonaTypeAndStringDictionary
	{
		{
			PersonaType.None,
			"None"
		},
		{
			PersonaType.Loner,
			"Loner"
		},
		{
			PersonaType.TeachersPet,
			"Teacher's Pet"
		},
		{
			PersonaType.Heroic,
			"Heroic"
		},
		{
			PersonaType.Coward,
			"Coward"
		},
		{
			PersonaType.Evil,
			"Evil"
		},
		{
			PersonaType.SocialButterfly,
			"Social Butterfly"
		},
		{
			PersonaType.Lovestruck,
			"Lovestruck"
		},
		{
			PersonaType.Dangerous,
			"Dangerous"
		},
		{
			PersonaType.Strict,
			"Strict"
		},
		{
			PersonaType.PhoneAddict,
			"Phone Addict"
		},
		{
			PersonaType.Fragile,
			"Fragile"
		},
		{
			PersonaType.Spiteful,
			"Spiteful"
		},
		{
			PersonaType.Sleuth,
			"Sleuth"
		},
		{
			PersonaType.Vengeful,
			"Vengeful"
		},
		{
			PersonaType.Protective,
			"Protective"
		},
		{
			PersonaType.Violent,
			"Violent"
		},
		{
			PersonaType.LandlineUser,
			"Snitch"
		},
		{
			PersonaType.Nemesis,
			"?????"
		}
	};
}
