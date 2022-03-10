using System;
using UnityEngine;

// Token: 0x020002B1 RID: 689
[Serializable]
public class Persona
{
	// Token: 0x06001450 RID: 5200 RVA: 0x000C62B2 File Offset: 0x000C44B2
	public Persona(PersonaType type)
	{
		this.type = type;
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x06001451 RID: 5201 RVA: 0x000C62C1 File Offset: 0x000C44C1
	public PersonaType Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04001F3B RID: 7995
	[SerializeField]
	private PersonaType type;

	// Token: 0x04001F3C RID: 7996
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
