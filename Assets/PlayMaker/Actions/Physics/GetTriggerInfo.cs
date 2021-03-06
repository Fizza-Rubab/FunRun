// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Physics)]
	[Tooltip("Gets info on the last trigger event. Typically used after a TRIGGER ENTER, TRIGGER STAY, or TRIGGER EXIT system event or a {{Trigger Event}} action. The owner of the FSM must have a trigger collider.")]
	public class GetTriggerInfo : FsmStateAction
	{
		[UIHint(UIHint.Variable)]
        [Tooltip("The game object that collided with the owner's trigger.")]
		public FsmGameObject gameObjectHit;

		[UIHint(UIHint.Variable)]
		[Tooltip("Useful for triggering different effects. Audio, particles...")]
		public FsmString physicsMaterialName;

		public override void Reset()
		{
			gameObjectHit = null;
			physicsMaterialName = null;
		}

		void StoreTriggerInfo()
		{
			if (Fsm.TriggerCollider == null) return;
			
			gameObjectHit.Value = Fsm.TriggerCollider.gameObject;
			physicsMaterialName.Value = Fsm.TriggerCollider.material.name;
		}

		public override void OnEnter()
		{
			StoreTriggerInfo();
			
			Finish();
		}
	}
}