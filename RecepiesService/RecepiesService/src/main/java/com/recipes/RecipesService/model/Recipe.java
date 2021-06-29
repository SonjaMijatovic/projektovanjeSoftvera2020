package com.recipes.RecipesService.model;

import java.io.Serializable;
import java.util.ArrayList;

public class Recipe implements Serializable  {

    private int id;
    private Patient patient;
    private ArrayList<RecipeItem> items = new ArrayList<>();

    public Recipe() {}
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setPatient(int id, Patient patient) {
        this.patient = patient;
        this.id = id;
    }

    public void setItems(ArrayList<RecipeItem> items) {
        this.items = items;
    }

    public Patient getPatient() {
        return patient;
    }

    public ArrayList<RecipeItem> getItems() {
        return items;
    }

    public Recipe(Patient patient) {
        this.patient = patient;
    }
}
