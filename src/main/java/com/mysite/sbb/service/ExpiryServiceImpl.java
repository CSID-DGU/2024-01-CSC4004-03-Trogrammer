package com.mysite.sbb.service;

import java.util.List;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.mysite.sbb.mapper.IngredientsMapper;

@Service
public class ExpiryServiceImpl implements ExpiryService{
	
	@Autowired
	private IngredientsMapper ingredientMapper;

	@Override
	public List<Map<String,Object>> get_past() {
		return ingredientMapper.past_Ingredients();
	}

	@Override
	public List<Map<String, Object>> get_three() {
		return ingredientMapper.three_Ingredients();
	}

	@Override
	public List<Map<String, Object>> get_threetofive() {
		return ingredientMapper.threetofive_Ingredients();
	}

	@Override
	public List<Map<String, Object>> get_overfive() {
		return ingredientMapper.overfive_Ingredients();
	} 


}
