namespace SharpPhase {
	public class DelegatePhasedObject<TDelegator> : IPhasedObject<TDelegator> where TDelegator : IPhasedObject {
		TDelegator delegator;
		Phase<TDelegator> currentPhase;

		public DelegatePhasedObject(TDelegator delegator, Phase<TDelegator> initialPhase) {
			this.delegator = delegator;
			this.currentPhase = initialPhase;
			initialPhase.EnterPhase(delegator);
		}

		public Phase<TDelegator> CurrentPhase {
			get {
				return currentPhase;
			}
		}

		public void ChangePhase (Phase<TDelegator> newPhase) {
			currentPhase.LeavePhase(delegator);
			currentPhase = newPhase;
			currentPhase.EnterPhase(delegator);
		}
	}
}
