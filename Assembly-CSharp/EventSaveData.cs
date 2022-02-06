using System;

// Token: 0x020003F9 RID: 1017
[Serializable]
public class EventSaveData
{
	// Token: 0x06001BF7 RID: 7159 RVA: 0x00145F93 File Offset: 0x00144193
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

	// Token: 0x06001BF8 RID: 7160 RVA: 0x00145FD1 File Offset: 0x001441D1
	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}

	// Token: 0x0400310F RID: 12559
	public bool befriendConversation;

	// Token: 0x04003110 RID: 12560
	public bool event1;

	// Token: 0x04003111 RID: 12561
	public bool event2;

	// Token: 0x04003112 RID: 12562
	public bool kidnapConversation;

	// Token: 0x04003113 RID: 12563
	public bool livingRoom;
}
