package ObserverPattern;
import java.util.Observable;



@SuppressWarnings("deprecation")
public class WeatherData extends Observable {
	 //private ArrayList<Observer> observers;
	 private float temperature;
	 private float humidity;
	 private float pressure;
	 
	 public WeatherData() {
		 
	 }
	 
	 public void measurementsChanged() {
		 setChanged();
		 notifyObservers();
	 }
	 
	 public void setMeasurements(float temperature, float humidity, float pressure) {
		 this.temperature = temperature;
		 this.humidity = humidity;
		 this.pressure = pressure;
		 measurementsChanged();
	 }
	 public void setMeasurements1(float temperature, float humidity, float pressure) {
		 this.temperature = temperature;
		 this.humidity = humidity;
		 this.pressure = pressure;
		 measurementsChanged();
		 }
	 
	 public float getTemperature() {
		 return temperature;
	 }
	 
	 public float getHumidity() {
		 return humidity;
	 }
	 
	 public float getPressure() {
		 return pressure;
	 }
	 // other WeatherData methods here
	}