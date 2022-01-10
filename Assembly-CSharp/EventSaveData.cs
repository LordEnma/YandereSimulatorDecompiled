using System;

// Token: 0x020003F8 RID: 1016
[Serializable]
public class EventSaveData
{
	// Token: 0x06001BF2 RID: 7154 RVA: 0x001441AB File Offset: 0x001423AB
	public static EventSaveData ReadFromGlobals()
	{
		return new EventSaveData
		{
			befriendConversation = EventGlobals.BefriendConversation,
			event1 = EventGlobals.Event1,
			event2 = EventGlobals.Event2,
			kidnapConversation = EventGlobals.KidnapConversation,
			livingRoom = EventGlobals.LivingRoom
		};
	}

	// Token: 0x06001BF3 RID: 7155 RVA: 0x001441E9 File Offset: 0x001423E9
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x04003100 RID: 12544
	public bool befriendConversation;

	// Token: 0x04003101 RID: 12545
	public bool event1;

	// Token: 0x04003102 RID: 12546
	public bool event2;

	// Token: 0x04003103 RID: 12547
	public bool kidnapConversation;

	// Token: 0x04003104 RID: 12548
	public bool livingRoom;
}
