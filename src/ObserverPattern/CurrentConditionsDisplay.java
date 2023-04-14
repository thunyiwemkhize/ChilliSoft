package ObserverPattern;

import java.util.Observable;

@SuppressWarnings("deprecation")
public class CurrentConditionsDisplay implements Observer, DisplayElement,HeatIndexDisplay {
	 Observable observable;
	 private float temperature;
	 private float humidity;
	 
	 public CurrentConditionsDisplay(Observable observable) {
		 this.observable = observable;
		 observable.addObserver((java.util.Observer) this);
		 }
	 
	 public void updateTemperature(float temperature, float humidity, float pressure) {
	 this.temperature = temperature;
	 this.humidity = humidity;
	 display();
	 }
	 
	 public void update(Observable obs, Object arg) {
		 if (obs instanceof WeatherData) {
		 WeatherData weatherData = (WeatherData)obs;
		 this.temperature = weatherData.getTemperature();
		 this.humidity = weatherData.getHumidity();
		 display();
		 }
	 }
	 
	 public void display() {
		 System.out.println("Current conditions: " + temperature 
				 + "F degrees and " + humidity + "% humidity");
	 }

	@Override
	public double CalculateIdex(double T, double RH) {
		// TODO Auto-generated method stub
		double heatindex =16.923 + 1.85212 * powerOfInt(10,-1) * T + 5.37941 * RH - 1.00254 * powerOfInt(10,-1) * 
				T * RH + 9.41695 * powerOfInt(10,-3) * powerOfInt(T,2) + 7.28898 * powerOfInt(10,-3) * powerOfInt(RH,2) + 3.45372 * 
				powerOfInt(10,-4)* powerOfInt(T,2) * RH - 8.14971 * powerOfInt(10,-4) * T * powerOfInt(RH,2) + 1.02102 * powerOfInt(10,-5) * powerOfInt(T,2) * 
				powerOfInt(RH,2) - 3.8646 * powerOfInt(10,-5) * powerOfInt(T,3) + 2.91583 * powerOfInt(10,-5) * powerOfInt(RH,3) + 1.42721 * powerOfInt(10,-6)
				* powerOfInt(T,3) * RH + 1.97483 * powerOfInt(10,-8) * T * powerOfInt(RH,3) - 2.18429 * powerOfInt(10,-8) * powerOfInt(T,3) * powerOfInt(RH,2) 
				+ 8.43296 * powerOfInt(10,-10) * powerOfInt(T,2) * powerOfInt(RH,3) - 4.81975 * powerOfInt(10,-11) * powerOfInt(T,3) * powerOfInt(RH,3);
		return heatindex;
	}
	double powerOfInt(double input,int powerValue) {
		 return Math.pow(input, powerValue);
	 }
	}