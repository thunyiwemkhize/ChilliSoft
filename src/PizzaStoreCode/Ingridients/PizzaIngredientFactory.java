package PizzaStoreCode.Ingridients;

public interface PizzaIngredientFactory extends IVeggies {
	public IDough createDough();
	 public ISauce createSauce();
	 public ICheese createCheese();
	 public IVeggies[] createVeggies();
	 public IPepperoni createPepperoni();
	 public IClams createClam();
	 
}

