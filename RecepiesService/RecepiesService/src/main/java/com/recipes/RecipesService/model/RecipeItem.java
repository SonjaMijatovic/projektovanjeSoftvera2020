package com.recipes.RecipesService.model;

import java.io.Serializable;

public class RecipeItem implements Serializable  {

    private Medicine medicine;
    private double count;

    public RecipeItem() {}
    public RecipeItem(Medicine medicine, double count) {
        this.medicine = medicine;
        this.count = count;
    }

    public Medicine getMedicine() {
        return medicine;
    }

    public void setMedicine(Medicine medicine) {
        this.medicine = medicine;
    }

    public double getCount() {
        return count;
    }

    public void setCount(double count) {
        this.count = count;
    }
}
