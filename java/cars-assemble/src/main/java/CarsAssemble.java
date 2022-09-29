public class CarsAssemble {

	private static final int rate = 221;

	public double productionRatePerHour(int speed) {
		return speed * rate * successRate(speed);
	}

	public int workingItemsPerMinute(int speed) {
		return (int) (productionRatePerHour(speed) / 60);
	}

	private double successRate(int speed) {
		if (speed >= 1 && speed <= 4) {
			return 1;
		} else if (speed <= 8) {
			return 0.9;
		} else if (speed <= 9) {
			return 0.8;
		} else {
			return 0.77;
		}
	}
}
