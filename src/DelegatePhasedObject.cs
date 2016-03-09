namespace SharpPhase {

	public class DelegatePhasedObject<TDelegator, TPhase> : IPhasedObject<TDelegator, TPhase> where TDelegator : IPhasedObject where TPhase : Phase<TDelegator> {
		TDelegator delegator;
		TPhase currentPhase;

		public DelegatePhasedObject(TDelegator delegator, TPhase initialPhase) {
			this.delegator = delegator;
			this.currentPhase = initialPhase;
			initialPhase.EnterPhase(delegator);
		}

		public void ChangePhase (TPhase newPhase) {
			if (currentPhase == null)
				throw new System.Exception ("already terminated");
			
			currentPhase.LeavePhase(delegator);
			currentPhase = newPhase;
			currentPhase.EnterPhase(delegator);
		}

		public void TerminatePhase () {
			currentPhase.LeavePhase (delegator);
			currentPhase = null;
		}

		public TPhase CurrentPhase {
			get {
				return currentPhase;
			}
		}
	}

	public class DelegatePhasedObject<TDelegator> : DelegatePhasedObject<TDelegator, Phase<TDelegator>> where TDelegator : IPhasedObject {
		public DelegatePhasedObject(TDelegator delegator, Phase<TDelegator> initialPhase)
			: base(delegator, initialPhase)
		{
		}
	}
}
