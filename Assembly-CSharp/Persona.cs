using System;
using UnityEngine;

// Token: 0x020002AE RID: 686
[Serializable]
public class Persona
{
	// Token: 0x0600143D RID: 5181 RVA: 0x000C4EF2 File Offset: 0x000C30F2
	public Persona(PersonaType type)
	{
		this.type = type;
	}

	// Token: 0x17000366 RID: 870
	// (get) Token: 0x0600143E RID: 5182 RVA: 0x000C4F01 File Offset: 0x000C3101
	public PersonaType Type
	{
		get
		{
			return this.type;
		}
	}

	// Token: 0x04001F10 RID: 7952
	[SerializeField]
	private PersonaType type;

	// Token: 0x04001F11 RID: 7953
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
