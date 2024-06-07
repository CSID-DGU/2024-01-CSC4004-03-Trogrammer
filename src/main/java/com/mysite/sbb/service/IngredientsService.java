package com.mysite.sbb.service;

import java.util.List;

import com.mysite.sbb.dto.Ingredients;

public interface IngredientsService {
	Ingredients postingredient(Ingredients ingredients);
	Ingredients putingredient(Ingredients ingredients);
	void delingredient(int id);
	List<Ingredients> selingredient();
}
