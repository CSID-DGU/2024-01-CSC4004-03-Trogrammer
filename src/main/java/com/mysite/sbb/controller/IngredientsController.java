package com.mysite.sbb.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.mysite.sbb.dto.Ingredients;
import com.mysite.sbb.service.IngredientsService;

@RestController
@RequestMapping("/ingredient")
public class IngredientsController {
	
	@Autowired
	IngredientsService ingredientsService;
	
	@GetMapping("/selectAll")
	public ResponseEntity<List<Ingredients>> selingredient()	{
		List<Ingredients> newingredient = ingredientsService.selingredient();
		return new ResponseEntity<>(newingredient, HttpStatus.OK);
	}
	
	@DeleteMapping("/remove")
	public ResponseEntity<Integer> delingredient(@RequestParam(value= "id") int id)	{
		ingredientsService.delingredient(id);
		return new ResponseEntity<>(id, HttpStatus.OK);
	}
	
	@PutMapping("/modify")
	public ResponseEntity<Ingredients> putingredient(@RequestBody Ingredients ingredients)	{
		Ingredients newingredient = ingredientsService.putingredient(ingredients);
		return new ResponseEntity<>(ingredients, HttpStatus.OK);
	}
	
	@PostMapping("/add")
	public ResponseEntity<Ingredients> postingredient(@RequestBody Ingredients ingredients)	{
		System.out.println(ingredients);
		Ingredients newingredient = ingredientsService.postingredient(ingredients);
		System.out.println(newingredient);
		return new ResponseEntity<>(ingredients, HttpStatus.OK);
		
	
	
	}
}
