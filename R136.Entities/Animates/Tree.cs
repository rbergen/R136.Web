﻿using Microsoft.Extensions.Primitives;
using R136.Interfaces;
using System;
using System.Collections.Generic;

namespace R136.Entities.Animates
{
	public class Tree : Animate
	{
		public static Animate Create(Initializer initializer)
			=> new Tree(initializer.ID, initializer.StartRoom);
		
		public event Action? Burned;

		private Tree(AnimateID id, RoomID startRoom) : base(id, startRoom) { }

		public override StringValues ProgressStatus()
		{
			var texts = new List<string>();

			var statusTexts = GetTextsForStatus(Status);
			if (statusTexts.Count > 0)
				texts.AddRange(statusTexts);

			if (Status == AnimateStatus.Operating)
			{
				if (!(StatusManager?.IsInPosession(ItemID.HeatSuit) ?? false))
				{
					statusTexts = GetTextsForStatus(AnimateStatus.SelfInjury);
					if (statusTexts.Count > 0)
						texts.AddRange(statusTexts);
				}

				Burned?.Invoke();

				Status = AnimateStatus.Done;
			}

			return texts.Count > 0 ? texts.ToArray() : null;
		}

		public override Result ApplyItem(ItemID item)
		{
			if (item != ItemID.Flamethrower)
				return Result.Error();

			Status = AnimateStatus.Operating;
			IsTriggered = true;
			return Result.Success();
		}
	}
}
