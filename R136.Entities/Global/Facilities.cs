﻿
using R136.Entities.General;
using System;

namespace R136.Entities.Global
{
	public static class Facilities
	{
		public static IServiceProvider? ServiceProvider { get; set; }
		public static Random Randomizer { get; }
		public static TypedTextsMap<int> TextsMap { get; }
		public static TypedTextsMap<AnimateStatus> AnimateStatusTextsMap { get; }
		public static TypedTextsMap<Item.TextType> ItemTextsMap { get; }
		public static KeyedTextsMap<CommandID, int> CommandTextsMap { get; }
		public static Configuration Configuration { get; set; }

		static Facilities()
		{
			Randomizer = new Random();
			TextsMap = new TypedTextsMap<int>();
			AnimateStatusTextsMap = new TypedTextsMap<AnimateStatus>();
			ItemTextsMap = new TypedTextsMap<Item.TextType>();
			CommandTextsMap = new KeyedTextsMap<CommandID, int>();
			Configuration = new Configuration();
		}
	}
}