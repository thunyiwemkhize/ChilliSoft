package Starbuzz;

public class Soy extends CondimentDecorator{
	Beverage beverage;
	Size size ;
	
	public Soy(Beverage beverage) {
		this.beverage = beverage;
	}
	
	public String getDescription() {
		return beverage.getDescription() + ", Soy";
	}
	public double cost() {
		double currentCost =beverage.cost() + 0.15;
		if(beverage.getSize() == Size.VENTI)
			currentCost+=.10;
		if(beverage.getSize() == Size.GRANDE)
			currentCost+=.20;
		if(beverage.getSize() == Size.GRANDE)
			currentCost+=.30;
		return currentCost;
	}
}
