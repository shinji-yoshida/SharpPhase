namespace SharpPhase {

	public abstract class PhasedObject<TSelf, TPhase>
		: IPhasedObject<TSelf, TPhase>
			where TSelf : IPhasedObject
		where TPhase : Phase<TSelf>
	{
		TPhase currentPhase;

		protected abstract TSelf Self {
			get;
		}

		protected PhasedObject(TPhase initialPhase) {
			InitPhase (initialPhase);
		}

		/// <summary>
		/// Should call InitPhase(TPhase) after constructed.
		/// </summary>
		protected PhasedObject() {
		}

		protected void InitPhase(TPhase initialPhase) {
			this.currentPhase = initialPhase;
			MakeEnterPhase (initialPhase);
		}

		public void ChangePhase (TPhase newPhase) {
			if (currentPhase == null)
				throw new System.Exception ("already terminated");

			MakeLeavePhase (currentPhase);
			currentPhase = newPhase;
			MakeEnterPhase (currentPhase);
		}

		public void TerminatePhase () {
			MakeTerminatePhase (currentPhase);
			currentPhase = null;
		}

		protected virtual void MakeEnterPhase(TPhase phase) {
			phase.EnterPhase(Self);
		}

		protected virtual void MakeLeavePhase(TPhase phase) {
			phase.LeavePhase(Self);
		}

		protected virtual void MakeTerminatePhase(TPhase phase) {
			phase.TerminatePhase(Self);
		}

		public TPhase CurrentPhase {
			get {
				return currentPhase;
			}
		}
	}

	public abstract class PhasedObject<TSelf> : PhasedObject<TSelf, Phase<TSelf>> where TSelf : IPhasedObject {
		protected PhasedObject(Phase<TSelf> initialPhase)
			: base(initialPhase)
		{
		}
	}
}
