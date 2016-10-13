namespace SharpPhase {

	public class DelegatePhasedObject<TDelegator, TPhase>
		: PhasedObject<TDelegator, TPhase>
			where TDelegator : IPhasedObject
			where TPhase : Phase<TDelegator>
	{
		TDelegator delegator;

		protected override TDelegator Self {
			get {
				return delegator;
			}
		}

		public DelegatePhasedObject(TDelegator delegator, TPhase initialPhase) {
			this.delegator = delegator;

			InitPhase (initialPhase);
		}
	}

	public class DelegatePhasedObject<TDelegator>
		: DelegatePhasedObject<TDelegator, Phase<TDelegator>>
			where TDelegator : IPhasedObject
	{
		public DelegatePhasedObject(TDelegator delegator, Phase<TDelegator> initialPhase)
			: base(delegator, initialPhase)
		{
		}
	}
}
