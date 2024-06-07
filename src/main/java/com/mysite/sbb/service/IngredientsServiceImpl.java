package com.mysite.sbb.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.mysite.sbb.dto.Ingredients;
import com.mysite.sbb.mapper.IngredientsMapper;

@Service
public class IngredientsServiceImpl implements IngredientsService{
	
	@Autowired
	private IngredientsMapper ingredientsMapper;
	
	public Ingredients postingredient(Ingredients ingredients)	{
		ingredientsMapper.postingredient(ingredients);
		return ingredients;
	}
	
	public Ingredients putingredient(Ingredients ingredients)	{
		ingredientsMapper.putingredient(ingredients);
		return ingredients;
	}
	
	public void delingredient(int id)	{
		ingredientsMapper.delingredient(id);
	}
	
	public List<Ingredients> selingredient() {
		return ingredientsMapper.selingredient();
	}

}
 