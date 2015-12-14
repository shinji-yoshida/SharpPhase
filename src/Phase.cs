using UniRx;

namespace SharpPhase {
	public abstract class Phase<T> where T : IPhasedObject {
		CompositeDisposable phaseDisposables;

		public CompositeDisposable PhaseDisposables {
			get {
				return phaseDisposables;
			}
		}

		public void EnterPhase(T phasedObject) {
			phaseDisposables = new CompositeDisposable();
			OnEnterPhase(phasedObject);
		}

		protected abstract void OnEnterPhase(T phasedObject);

		public void LeavePhase(T phasedObject) {
			OnLeavePhase(phasedObject);
			phaseDisposables.Dispose();
		}

		protected abstract void OnLeavePhase(T phasedObject);
	}
}