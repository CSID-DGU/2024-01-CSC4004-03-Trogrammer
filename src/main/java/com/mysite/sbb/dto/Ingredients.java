package com.mysite.sbb.dto;

public class Ingredients {
	
	private int id;
	private String ingrename;
	private int quantity;
	private String expirationdate;
	
	
	public Ingredients() {
		super();
		// TODO Auto-generated constructor stub
	}

	public Ingredients(int id, String ingrename, int quantity, String expirationdate) {
		super();
		this.id = id;
		this.ingrename = ingrename;
		this.quantity = quantity;
		this.expirationdate = expirationdate;
	}
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getIngrename() {
		return ingrename;
	}
	public void setIngrename(String ingrename) {
		this.ingrename = ingrename;
	}
	public int getQuantity() {
		return quantity;
	}
	public void setQuantity(int quantity) {
		this.quantity = quantity;
	}
	public String getExpirationdate() {
		return expirationdate;
	}
	public void setExpirationdate(String expirationdate) {
		this.expirationdate = expirationdate;
	}
	@Override
	public String toString() {
		return "Ingredients [id=" + id + ", ingrename=" + ingrename + ", quantity=" + quantity + ", expirationdate="
				+ expirationdate + "]";
	}
	

	
}
