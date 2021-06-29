package com.recipes.RecipesService.model;

import java.io.Serializable;

public class Medicine implements Serializable {
	
    private String name;

    public Medicine(){}

    public Medicine(String name) {
        this.name = name;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
