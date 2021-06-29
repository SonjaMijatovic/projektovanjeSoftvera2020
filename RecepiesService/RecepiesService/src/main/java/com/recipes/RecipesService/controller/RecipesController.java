package com.recipes.RecipesService.controller;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import com.recipes.RecipesService.model.Database;
import com.recipes.RecipesService.model.Recipe;
import com.recipes.RecipesService.model.Recipes;

@RestController
@RequestMapping("/recipes")
public class RecipesController {
    
    @GetMapping(path = "/all")
    public ResponseEntity<Recipes> get() {

        return new ResponseEntity<Recipes>(Database.getInstance().getAll(), HttpStatus.OK);

    }

    @PostMapping(path ="/")
    public ResponseEntity<Recipe> add(@RequestBody Recipe recipe) {

        Database.getInstance().getAll().getRecepies().add(recipe);
        Database.getInstance().save();

        return new ResponseEntity<Recipe>(recipe, HttpStatus.OK);
    }

}
