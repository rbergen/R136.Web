﻿using System;

namespace R136.Entities.General
{
	interface INotifyRoomChangeRequested
	{
		bool RoomChangeRequested(RoomID from, RoomID to);
	}
}