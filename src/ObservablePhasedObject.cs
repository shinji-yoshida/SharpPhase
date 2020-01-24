using System;
using UniRx;


namespace SharpPhase {

	public abstract class ObservablePhasedObject<TSelf, TPhase> : PhasedObject<TSelf, TPhase>
		where TSelf : IPhasedObject
		where TPhase : Phase<TSelf>
	{
		Subject<PhaseEvent<TPhase>> phaseEventSubject = new Subject<PhaseEvent<TPhase>>();

		public ObservablePhasedObject (TPhase initialPhase) : base (initialPhase) {
		}

		public ObservablePhasedObject () : base() {
		}
		

		public IObservable<PhaseEvent<TPhase>> OnPhaseEventAsObservable() {
			return phaseEventSubject;
		}

		protected override void MakeEnterPhase (TPhase phase) {
			base.MakeEnterPhase (phase);
			phaseEventSubject.OnNext(new PhaseEvent<TPhase>(PhaseEventEnum.Enter, phase));
		}

		protected override void MakeLeavePhase (TPhase phase) {
			base.MakeLeavePhase (phase);
			phaseEventSubject.OnNext(new PhaseEvent<TPhase>(PhaseEventEnum.Leave, phase));
		}

		protected override void MakeTerminatePhase (TPhase phase) {
			base.MakeTerminatePhase (phase);
			phaseEventSubject.OnNext(new PhaseEvent<TPhase>(PhaseEventEnum.Terminate, phase));
		}
	}
}
