namespace SharpPhase {
	public interface IPhasedObject {
		
	}

	public interface IPhasedObject<Self> : IPhasedObject where Self : IPhasedObject {
		Phase<Self> CurrentPhase { get; }

		void ChangePhase(Phase<Self> newPhase);
	}

	public interface IPhasedObject<Self, TPhase> : IPhasedObject where Self : IPhasedObject where TPhase : Phase<Self> {
		TPhase CurrentPhase { get; }

		void ChangePhase(TPhase newPhase);
	}
}