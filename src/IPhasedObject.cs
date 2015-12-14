namespace SharpPhase {
	public interface IPhasedObject {
		
	}

	public interface IPhasedObject<Self> : IPhasedObject where Self : IPhasedObject {
		Phase<Self> CurrentPhase { get; }

		void ChangePhase(Phase<Self> newPhase);
	}
}