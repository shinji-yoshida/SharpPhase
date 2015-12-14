namespace SharpPhase {
	public interface IPhasedObject {
	}

	public interface IPhasedObject<Self> : IPhasedObject where Self : IPhasedObject {
		void InitPhase(Phase<Self> initialPhase);
		void ChangePhase(Phase<Self> newPhase);
	}
}