using System;

// Token: 0x0200045E RID: 1118
public enum SubtitleType
{
	// Token: 0x04003BDB RID: 15323
	AcceptFood,
	// Token: 0x04003BDC RID: 15324
	AccidentApology,
	// Token: 0x04003BDD RID: 15325
	AskForHelp,
	// Token: 0x04003BDE RID: 15326
	BloodApology,
	// Token: 0x04003BDF RID: 15327
	BloodReaction,
	// Token: 0x04003BE0 RID: 15328
	BloodAndInsanityReaction,
	// Token: 0x04003BE1 RID: 15329
	BloodPoolReaction,
	// Token: 0x04003BE2 RID: 15330
	BloodyWeaponReaction,
	// Token: 0x04003BE3 RID: 15331
	Custom,
	// Token: 0x04003BE4 RID: 15332
	ClassApology,
	// Token: 0x04003BE5 RID: 15333
	ClubAccept,
	// Token: 0x04003BE6 RID: 15334
	ClubActivity,
	// Token: 0x04003BE7 RID: 15335
	ClubConfirm,
	// Token: 0x04003BE8 RID: 15336
	ClubDeny,
	// Token: 0x04003BE9 RID: 15337
	ClubEarly,
	// Token: 0x04003BEA RID: 15338
	ClubExclusive,
	// Token: 0x04003BEB RID: 15339
	ClubFarewell,
	// Token: 0x04003BEC RID: 15340
	ClubGreeting,
	// Token: 0x04003BED RID: 15341
	ClubGrudge,
	// Token: 0x04003BEE RID: 15342
	ClubJoin,
	// Token: 0x04003BEF RID: 15343
	ClubKick,
	// Token: 0x04003BF0 RID: 15344
	ClubLate,
	// Token: 0x04003BF1 RID: 15345
	ClubCookingInfo,
	// Token: 0x04003BF2 RID: 15346
	ClubDramaInfo,
	// Token: 0x04003BF3 RID: 15347
	ClubOccultInfo,
	// Token: 0x04003BF4 RID: 15348
	ClubArtInfo,
	// Token: 0x04003BF5 RID: 15349
	ClubLightMusicInfo,
	// Token: 0x04003BF6 RID: 15350
	ClubMartialArtsInfo,
	// Token: 0x04003BF7 RID: 15351
	ClubPlaceholderInfo,
	// Token: 0x04003BF8 RID: 15352
	ClubPhotoInfoLight,
	// Token: 0x04003BF9 RID: 15353
	ClubPhotoInfoDark,
	// Token: 0x04003BFA RID: 15354
	ClubScienceInfo,
	// Token: 0x04003BFB RID: 15355
	ClubSportsInfo,
	// Token: 0x04003BFC RID: 15356
	ClubGardenInfo,
	// Token: 0x04003BFD RID: 15357
	ClubGamingInfo,
	// Token: 0x04003BFE RID: 15358
	ClubDelinquentInfo,
	// Token: 0x04003BFF RID: 15359
	ClubNewspaperInfo,
	// Token: 0x04003C00 RID: 15360
	ClubNo,
	// Token: 0x04003C01 RID: 15361
	ClubQuit,
	// Token: 0x04003C02 RID: 15362
	ClubRefuse,
	// Token: 0x04003C03 RID: 15363
	ClubRejoin,
	// Token: 0x04003C04 RID: 15364
	ClubUnwelcome,
	// Token: 0x04003C05 RID: 15365
	ClubYes,
	// Token: 0x04003C06 RID: 15366
	ClubPractice,
	// Token: 0x04003C07 RID: 15367
	ClubPracticeYes,
	// Token: 0x04003C08 RID: 15368
	ClubPracticeNo,
	// Token: 0x04003C09 RID: 15369
	CleaningApology,
	// Token: 0x04003C0A RID: 15370
	CorpseReaction,
	// Token: 0x04003C0B RID: 15371
	CowardGrudge,
	// Token: 0x04003C0C RID: 15372
	CowardMurderReaction,
	// Token: 0x04003C0D RID: 15373
	DelinquentAnnoy,
	// Token: 0x04003C0E RID: 15374
	DelinquentCase,
	// Token: 0x04003C0F RID: 15375
	DelinquentShove,
	// Token: 0x04003C10 RID: 15376
	DelinquentReaction,
	// Token: 0x04003C11 RID: 15377
	DelinquentWeaponReaction,
	// Token: 0x04003C12 RID: 15378
	DelinquentTaunt,
	// Token: 0x04003C13 RID: 15379
	DelinquentThreatened,
	// Token: 0x04003C14 RID: 15380
	DelinquentCalm,
	// Token: 0x04003C15 RID: 15381
	DelinquentFight,
	// Token: 0x04003C16 RID: 15382
	DelinquentAvenge,
	// Token: 0x04003C17 RID: 15383
	DelinquentWin,
	// Token: 0x04003C18 RID: 15384
	DelinquentSurrender,
	// Token: 0x04003C19 RID: 15385
	DelinquentNoSurrender,
	// Token: 0x04003C1A RID: 15386
	DelinquentMurderReaction,
	// Token: 0x04003C1B RID: 15387
	DelinquentCorpseReaction,
	// Token: 0x04003C1C RID: 15388
	DelinquentFriendCorpseReaction,
	// Token: 0x04003C1D RID: 15389
	DelinquentResume,
	// Token: 0x04003C1E RID: 15390
	DelinquentFlee,
	// Token: 0x04003C1F RID: 15391
	DelinquentEnemyFlee,
	// Token: 0x04003C20 RID: 15392
	DelinquentFriendFlee,
	// Token: 0x04003C21 RID: 15393
	DelinquentInjuredFlee,
	// Token: 0x04003C22 RID: 15394
	DelinquentCheer,
	// Token: 0x04003C23 RID: 15395
	DelinquentHmm,
	// Token: 0x04003C24 RID: 15396
	DelinquentGrudge,
	// Token: 0x04003C25 RID: 15397
	Dismissive,
	// Token: 0x04003C26 RID: 15398
	DrownReaction,
	// Token: 0x04003C27 RID: 15399
	Dying,
	// Token: 0x04003C28 RID: 15400
	EavesdropReaction,
	// Token: 0x04003C29 RID: 15401
	EventEavesdropReaction,
	// Token: 0x04003C2A RID: 15402
	EavesdropApology,
	// Token: 0x04003C2B RID: 15403
	Eulogy,
	// Token: 0x04003C2C RID: 15404
	EventApology,
	// Token: 0x04003C2D RID: 15405
	EvilCorpseReaction,
	// Token: 0x04003C2E RID: 15406
	EvilDelinquentCorpseReaction,
	// Token: 0x04003C2F RID: 15407
	EvilGrudge,
	// Token: 0x04003C30 RID: 15408
	EvilMurderReaction,
	// Token: 0x04003C31 RID: 15409
	Forgiving,
	// Token: 0x04003C32 RID: 15410
	ForgivingAccident,
	// Token: 0x04003C33 RID: 15411
	ForgivingInsanity,
	// Token: 0x04003C34 RID: 15412
	GasWarning,
	// Token: 0x04003C35 RID: 15413
	GiveHelp,
	// Token: 0x04003C36 RID: 15414
	Greeting,
	// Token: 0x04003C37 RID: 15415
	GrudgeRefusal,
	// Token: 0x04003C38 RID: 15416
	GrudgeWarning,
	// Token: 0x04003C39 RID: 15417
	HeroMurderReaction,
	// Token: 0x04003C3A RID: 15418
	HmmReaction,
	// Token: 0x04003C3B RID: 15419
	HoldingBloodyClothingApology,
	// Token: 0x04003C3C RID: 15420
	HoldingBloodyClothingReaction,
	// Token: 0x04003C3D RID: 15421
	Impatience,
	// Token: 0x04003C3E RID: 15422
	InfoNotice,
	// Token: 0x04003C3F RID: 15423
	InsanityApology,
	// Token: 0x04003C40 RID: 15424
	InsanityReaction,
	// Token: 0x04003C41 RID: 15425
	InterruptionReaction,
	// Token: 0x04003C42 RID: 15426
	IntrusionReaction,
	// Token: 0x04003C43 RID: 15427
	KilledMood,
	// Token: 0x04003C44 RID: 15428
	LewdApology,
	// Token: 0x04003C45 RID: 15429
	LewdReaction,
	// Token: 0x04003C46 RID: 15430
	LightSwitchReaction,
	// Token: 0x04003C47 RID: 15431
	LimbReaction,
	// Token: 0x04003C48 RID: 15432
	LonerCorpseReaction,
	// Token: 0x04003C49 RID: 15433
	LonerMurderReaction,
	// Token: 0x04003C4A RID: 15434
	LostPhone,
	// Token: 0x04003C4B RID: 15435
	LovestruckCorpseReport,
	// Token: 0x04003C4C RID: 15436
	LovestruckDeathReaction,
	// Token: 0x04003C4D RID: 15437
	LovestruckMurderReport,
	// Token: 0x04003C4E RID: 15438
	MurderReaction,
	// Token: 0x04003C4F RID: 15439
	NoteReaction,
	// Token: 0x04003C50 RID: 15440
	NoteReactionMale,
	// Token: 0x04003C51 RID: 15441
	ObstacleMurderReaction,
	// Token: 0x04003C52 RID: 15442
	ObstaclePoisonReaction,
	// Token: 0x04003C53 RID: 15443
	OfferSnack,
	// Token: 0x04003C54 RID: 15444
	OsanaObstacleDeathReaction,
	// Token: 0x04003C55 RID: 15445
	ParanoidReaction,
	// Token: 0x04003C56 RID: 15446
	PetBloodReaction,
	// Token: 0x04003C57 RID: 15447
	PetBloodReport,
	// Token: 0x04003C58 RID: 15448
	PetCorpseReaction,
	// Token: 0x04003C59 RID: 15449
	PetCorpseReport,
	// Token: 0x04003C5A RID: 15450
	PetLimbReaction,
	// Token: 0x04003C5B RID: 15451
	PetLimbReport,
	// Token: 0x04003C5C RID: 15452
	PetMurderReaction,
	// Token: 0x04003C5D RID: 15453
	PetMurderReport,
	// Token: 0x04003C5E RID: 15454
	PetWeaponReaction,
	// Token: 0x04003C5F RID: 15455
	PetWeaponReport,
	// Token: 0x04003C60 RID: 15456
	PetBloodyWeaponReaction,
	// Token: 0x04003C61 RID: 15457
	PetBloodyWeaponReport,
	// Token: 0x04003C62 RID: 15458
	PhotoAnnoyance,
	// Token: 0x04003C63 RID: 15459
	PickpocketReaction,
	// Token: 0x04003C64 RID: 15460
	PickpocketApology,
	// Token: 0x04003C65 RID: 15461
	PlayerCompliment,
	// Token: 0x04003C66 RID: 15462
	PlayerDistract,
	// Token: 0x04003C67 RID: 15463
	PlayerFarewell,
	// Token: 0x04003C68 RID: 15464
	PlayerFollow,
	// Token: 0x04003C69 RID: 15465
	PlayerGossip,
	// Token: 0x04003C6A RID: 15466
	PlayerLeave,
	// Token: 0x04003C6B RID: 15467
	PlayerLove,
	// Token: 0x04003C6C RID: 15468
	PoisonApology,
	// Token: 0x04003C6D RID: 15469
	PoisonReaction,
	// Token: 0x04003C6E RID: 15470
	PrankReaction,
	// Token: 0x04003C6F RID: 15471
	RaibaruRivalDeathReaction,
	// Token: 0x04003C70 RID: 15472
	RejectFood,
	// Token: 0x04003C71 RID: 15473
	RejectHelp,
	// Token: 0x04003C72 RID: 15474
	RepeatReaction,
	// Token: 0x04003C73 RID: 15475
	RequestMedicine,
	// Token: 0x04003C74 RID: 15476
	ReturningWeapon,
	// Token: 0x04003C75 RID: 15477
	RivalEavesdropReaction,
	// Token: 0x04003C76 RID: 15478
	RivalLostPhone,
	// Token: 0x04003C77 RID: 15479
	RivalLove,
	// Token: 0x04003C78 RID: 15480
	RivalPickpocketReaction,
	// Token: 0x04003C79 RID: 15481
	RivalSplashReaction,
	// Token: 0x04003C7A RID: 15482
	SadApology,
	// Token: 0x04003C7B RID: 15483
	SendToLocker,
	// Token: 0x04003C7C RID: 15484
	SenpaiBloodReaction,
	// Token: 0x04003C7D RID: 15485
	SenpaiCorpseReaction,
	// Token: 0x04003C7E RID: 15486
	SenpaiInsanityReaction,
	// Token: 0x04003C7F RID: 15487
	SenpaiLewdReaction,
	// Token: 0x04003C80 RID: 15488
	SenpaiMurderReaction,
	// Token: 0x04003C81 RID: 15489
	SenpaiStalkingReaction,
	// Token: 0x04003C82 RID: 15490
	SenpaiViolenceReaction,
	// Token: 0x04003C83 RID: 15491
	SenpaiWeaponReaction,
	// Token: 0x04003C84 RID: 15492
	SenpaiRivalDeathReaction,
	// Token: 0x04003C85 RID: 15493
	SocialDeathReaction,
	// Token: 0x04003C86 RID: 15494
	SocialFear,
	// Token: 0x04003C87 RID: 15495
	SocialReport,
	// Token: 0x04003C88 RID: 15496
	SocialTerror,
	// Token: 0x04003C89 RID: 15497
	SplashReaction,
	// Token: 0x04003C8A RID: 15498
	SplashReactionMale,
	// Token: 0x04003C8B RID: 15499
	SuitorLove,
	// Token: 0x04003C8C RID: 15500
	SuspiciousApology,
	// Token: 0x04003C8D RID: 15501
	SuspiciousReaction,
	// Token: 0x04003C8E RID: 15502
	StopFollowApology,
	// Token: 0x04003C8F RID: 15503
	StudentDistract,
	// Token: 0x04003C90 RID: 15504
	StudentDistractRefuse,
	// Token: 0x04003C91 RID: 15505
	StudentDistractBullyRefuse,
	// Token: 0x04003C92 RID: 15506
	StudentFarewell,
	// Token: 0x04003C93 RID: 15507
	StudentFollow,
	// Token: 0x04003C94 RID: 15508
	StudentGossip,
	// Token: 0x04003C95 RID: 15509
	StudentHighCompliment,
	// Token: 0x04003C96 RID: 15510
	StudentLeave,
	// Token: 0x04003C97 RID: 15511
	StudentLowCompliment,
	// Token: 0x04003C98 RID: 15512
	StudentMidCompliment,
	// Token: 0x04003C99 RID: 15513
	StudentMurderReport,
	// Token: 0x04003C9A RID: 15514
	StudentStay,
	// Token: 0x04003C9B RID: 15515
	Task6Line,
	// Token: 0x04003C9C RID: 15516
	Task7Line,
	// Token: 0x04003C9D RID: 15517
	Task8Line,
	// Token: 0x04003C9E RID: 15518
	Task11Line,
	// Token: 0x04003C9F RID: 15519
	Task13Line,
	// Token: 0x04003CA0 RID: 15520
	Task14Line,
	// Token: 0x04003CA1 RID: 15521
	Task15Line,
	// Token: 0x04003CA2 RID: 15522
	Task25Line,
	// Token: 0x04003CA3 RID: 15523
	Task28Line,
	// Token: 0x04003CA4 RID: 15524
	Task30Line,
	// Token: 0x04003CA5 RID: 15525
	Task32Line,
	// Token: 0x04003CA6 RID: 15526
	Task33Line,
	// Token: 0x04003CA7 RID: 15527
	Task34Line,
	// Token: 0x04003CA8 RID: 15528
	Task36Line,
	// Token: 0x04003CA9 RID: 15529
	Task37Line,
	// Token: 0x04003CAA RID: 15530
	Task38Line,
	// Token: 0x04003CAB RID: 15531
	Task46Line,
	// Token: 0x04003CAC RID: 15532
	Task52Line,
	// Token: 0x04003CAD RID: 15533
	Task76Line,
	// Token: 0x04003CAE RID: 15534
	Task77Line,
	// Token: 0x04003CAF RID: 15535
	Task78Line,
	// Token: 0x04003CB0 RID: 15536
	Task79Line,
	// Token: 0x04003CB1 RID: 15537
	Task80Line,
	// Token: 0x04003CB2 RID: 15538
	Task81Line,
	// Token: 0x04003CB3 RID: 15539
	TaskGenericLine,
	// Token: 0x04003CB4 RID: 15540
	TaskGenericLineMale,
	// Token: 0x04003CB5 RID: 15541
	TaskGenericLineFemale,
	// Token: 0x04003CB6 RID: 15542
	TaskGenericEightiesLine,
	// Token: 0x04003CB7 RID: 15543
	TaskGenericEightiesLineMale,
	// Token: 0x04003CB8 RID: 15544
	TaskGenericEightiesLineFemale,
	// Token: 0x04003CB9 RID: 15545
	TaskInquiry,
	// Token: 0x04003CBA RID: 15546
	TeacherAttackReaction,
	// Token: 0x04003CBB RID: 15547
	TeacherBloodHostile,
	// Token: 0x04003CBC RID: 15548
	TeacherBloodReaction,
	// Token: 0x04003CBD RID: 15549
	TeacherCorpseInspection,
	// Token: 0x04003CBE RID: 15550
	TeacherCorpseReaction,
	// Token: 0x04003CBF RID: 15551
	TeacherCoverUpHostile,
	// Token: 0x04003CC0 RID: 15552
	TeacherInsanityHostile,
	// Token: 0x04003CC1 RID: 15553
	TeacherInsanityReaction,
	// Token: 0x04003CC2 RID: 15554
	TeacherLateReaction,
	// Token: 0x04003CC3 RID: 15555
	TeacherLewdReaction,
	// Token: 0x04003CC4 RID: 15556
	TeacherMurderReaction,
	// Token: 0x04003CC5 RID: 15557
	TeacherPoliceReport,
	// Token: 0x04003CC6 RID: 15558
	TeacherPrankReaction,
	// Token: 0x04003CC7 RID: 15559
	TeacherReportReaction,
	// Token: 0x04003CC8 RID: 15560
	TeacherTheftReaction,
	// Token: 0x04003CC9 RID: 15561
	TeacherTrespassingReaction,
	// Token: 0x04003CCA RID: 15562
	TeacherWeaponHostile,
	// Token: 0x04003CCB RID: 15563
	TeacherWeaponReaction,
	// Token: 0x04003CCC RID: 15564
	TheftApology,
	// Token: 0x04003CCD RID: 15565
	TheftReaction,
	// Token: 0x04003CCE RID: 15566
	TutorialApology,
	// Token: 0x04003CCF RID: 15567
	TutorialReaction,
	// Token: 0x04003CD0 RID: 15568
	ViolenceApology,
	// Token: 0x04003CD1 RID: 15569
	ViolenceReaction,
	// Token: 0x04003CD2 RID: 15570
	WeaponApology,
	// Token: 0x04003CD3 RID: 15571
	WeaponReaction,
	// Token: 0x04003CD4 RID: 15572
	WeaponAndBloodApology,
	// Token: 0x04003CD5 RID: 15573
	WeaponAndBloodReaction,
	// Token: 0x04003CD6 RID: 15574
	WeaponAndInsanityReaction,
	// Token: 0x04003CD7 RID: 15575
	WeaponAndBloodAndInsanityReaction,
	// Token: 0x04003CD8 RID: 15576
	WetBloodReaction,
	// Token: 0x04003CD9 RID: 15577
	YandereWhimper,
	// Token: 0x04003CDA RID: 15578
	StrictReport,
	// Token: 0x04003CDB RID: 15579
	CasualReport,
	// Token: 0x04003CDC RID: 15580
	GraceReport,
	// Token: 0x04003CDD RID: 15581
	EdgyReport,
	// Token: 0x04003CDE RID: 15582
	BreakingUp,
	// Token: 0x04003CDF RID: 15583
	Spraying,
	// Token: 0x04003CE0 RID: 15584
	Shoving,
	// Token: 0x04003CE1 RID: 15585
	Chasing,
	// Token: 0x04003CE2 RID: 15586
	CouncilCorpseReaction,
	// Token: 0x04003CE3 RID: 15587
	CouncilToCounselor
}
