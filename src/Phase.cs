using UniRx;

namespace SharpPhase {
	public abstract class Phase<T> where T : IPhasedObject {
		CompositeDisposable phaseDisposables;

		public CompositeDisposable PhaseDisposables {
			get {
				return phaseDisposables;
			}
		}

		public virtual bool IsTerminatable {
			get {
				return false;
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

		public void TerminatePhase(T phasedObject) {
			if (!IsTerminatable)
				throw new System.Exception (this + " is not terminatable phase");
			
			OnTerminatePhase (phasedObject);
			phaseDisposables.Dispose ();
		}

		protected virtual void OnTerminatePhase (T phasedObject) {
		}
	}
}