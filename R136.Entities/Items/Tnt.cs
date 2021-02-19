﻿using R136.Entities.General;
using System.Collections.Generic;

namespace R136.Entities.Items
{
	class Tnt : Item
	{
#pragma warning disable IDE0060 // Remove unused parameter
		public static Tnt FromInitializer
			(
			Initializer initializer, 
			IDictionary<AnimateID, Animate> animates, 
			IDictionary<ItemID, Item> items
			)
#pragma warning restore IDE0060 // Remove unused parameter
			=> new Tnt(initializer.ID, initializer.Name, initializer.Description, initializer.StartRoom, initializer.Wearable, !initializer.BlockPutdown);

		private Tnt
			(
			ItemID id,
			string name,
			string description,
			RoomID startRoom,
			bool isWearable,
			bool isPutdownAllowed
			) 
			: base(id, name, description, startRoom, isWearable, isPutdownAllowed) { }

		public override Result Use()
		{
			StatusManager?.DecreaseHealth();

			return base.Use();
		}
	}
}
