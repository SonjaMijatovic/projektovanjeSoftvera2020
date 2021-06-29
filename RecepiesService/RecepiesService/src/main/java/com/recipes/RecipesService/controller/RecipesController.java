package com.recipes.RecipesService.controller;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.recipes.RecipesService.model.Recipe;
import com.recipes.RecipesService.model.Recipes;

@RestController
@RequestMapping("/recipes")
public class RecipesController {
    
    @GetMapping(path = "/all")
    public ResponseEntity<Recipes> get() {

        throw new UnsupportedOperationException("Method not yet implemented.");
    }

    @PostMapping(path ="/")
    public ResponseEntity<Recipe> add(@RequestBody Recipe recipe) {

        throw new UnsupportedOperationException("Method not yet implemented.");
    }

}
