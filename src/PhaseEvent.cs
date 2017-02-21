
namespace SharpPhase {
	public enum PhaseEventEnum {
		Enter, Leave, Terminate
	}

	public class PhaseEvent<TPhase> {
		public readonly PhaseEventEnum eventEnum;
		public readonly TPhase phase;

		public PhaseEvent (PhaseEventEnum eventEnum, TPhase phase) {
			this.eventEnum = eventEnum;
			this.phase = phase;
		}
	}
}