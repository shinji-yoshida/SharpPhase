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
			initialPhase.EnterPhase (Self);
		}

		public void ChangePhase (TPhase newPhase) {
			if (currentPhase == null)
				throw new System.Exception ("already terminated");

			currentPhase.LeavePhase(Self);
			currentPhase = newPhase;
			currentPhase.EnterPhase(Self);
		}

		public void TerminatePhase () {
			currentPhase.TerminatePhase (Self);
			currentPhase = null;
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
