package com.mysite.sbb.mapper;

import java.util.List;
import java.util.Map;

import org.apache.ibatis.annotations.Mapper;

import com.mysite.sbb.dto.Ingredients;

@Mapper
public interface IngredientsMapper {

	List<Map<String,Object>> past_Ingredients();
	List<Map<String,Object>> three_Ingredients();
	List<Map<String,Object>> threetofive_Ingredients();
	List<Map<String,Object>> overfive_Ingredients();
	List<Ingredients> selingredient();
	int postingredient(Ingredients ingredients);
	int putingredient(Ingredients ingredients);
	void delingredient(int id);
}
