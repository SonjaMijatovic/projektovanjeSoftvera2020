package com.recipes.RecipesService.model;

import java.io.Serializable;
import java.util.ArrayList;

public class Recipes  implements Serializable  {

    private ArrayList<Recipe> recepies = new ArrayList<>();

    public Recipes() {
        recepies = new ArrayList<>();
    }

    public ArrayList<Recipe> getRecepies() {
        return recepies;
    }

    public void setRecepies(ArrayList<Recipe> recepies) {
        this.recepies = recepies;
    }
}
