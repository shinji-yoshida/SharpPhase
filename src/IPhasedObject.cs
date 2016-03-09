namespace SharpPhase {
	public interface IPhasedObject {
		
	}

	public interface IPhasedObject<Self, TPhase> : IPhasedObject where Self : IPhasedObject where TPhase : Phase<Self> {
		TPhase CurrentPhase { get; }

		void ChangePhase(TPhase newPhase);
		void TerminatePhase();
	}

	public interface IPhasedObject<Self> : IPhasedObject<Self, Phase<Self>> where Self : IPhasedObject {
	}
}