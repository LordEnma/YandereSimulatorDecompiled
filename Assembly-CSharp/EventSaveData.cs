using System;

// Token: 0x020003F6 RID: 1014
[Serializable]
public class EventSaveData
{
	// Token: 0x06001BE9 RID: 7145 RVA: 0x00143A3B File Offset: 0x00141C3B
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

	// Token: 0x06001BEA RID: 7146 RVA: 0x00143A79 File Offset: 0x00141C79
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x040030F3 RID: 12531
	public bool befriendConversation;

	// Token: 0x040030F4 RID: 12532
	public bool event1;

	// Token: 0x040030F5 RID: 12533
	public bool event2;

	// Token: 0x040030F6 RID: 12534
	public bool kidnapConversation;

	// Token: 0x040030F7 RID: 12535
	public bool livingRoom;
}
